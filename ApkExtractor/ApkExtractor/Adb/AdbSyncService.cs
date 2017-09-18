using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApkExtractor.Adb
{
    public class AdbSyncService : IDisposable
    {
        private AdbSocket _socket;
        private Encoding _ascii;

        public AdbSyncService()
        {
            _socket = new AdbSocket();
            _ascii = Encoding.ASCII;
        }

        /// <summary>
        /// Begins the sync (file transfer) service on the current socket.
        /// </summary>
        /// <returns>The <see cref="AdbSyncService"/> instance.</returns>
        public async Task BeginSyncAsync(Device device)
        {
            await _socket.SetDeviceAsync(device);
            await _socket.WriteAsync(AdbClient.FormAdbRequest("sync:"));
            var resp = await _socket.ReadResponseAsync();

            if (resp != "OKAY") throw new AdbException("An error occurred when beginning the sync service.");
        }

        /// <summary>
        /// Gets the size of a file, in bytes.
        /// </summary>
        /// <param name="absolutePath">The absolute path to the file.</param>
        /// <returns>The file size in bytes.</returns>
        public async Task<int> GetFileSizeAsync(string absolutePath)
        {
            await _socket.SendSyncRequestAsync("STAT", absolutePath);
            var resp = await _socket.ReadResponseAsync();

            // The server will respond "STAT" to a STAT request.
            if (resp != "STAT") throw new AdbException("An error occurred when retrieving file statistics.");

            // The response is always 12 bytes.
            var statResp = new byte[12];
            await _socket.ReadAsync(statResp);

            // First 4 bytes: file mode.
            // Middle 4 bytes: file size (we only want this one).
            // Last 4 bytes: file creation date.
            if (!BitConverter.IsLittleEndian)
            {
                // Convert the file size bytes to big-endian if the system is big-endian.
                Array.Reverse(statResp, 4, 4);
            }

            return BitConverter.ToInt32(statResp, 4);
        }

        /// <summary>
        /// Asynchronously pulls a file from the device to a stream.
        /// </summary>
        /// <param name="absolutePath">The absolute path of the file to pull.</param>
        /// <param name="output">A <see cref="Stream"/> that the file contents should be written to.</param>
        /// <param name="cancel">A <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
        /// <param name="transferProgress">A function that takes the current amount of transfered bytes and the total amount of bytes to transfer.</param>
        public async Task PullFileAsync(string absolutePath, Stream output, CancellationToken cancel, Action<int, int> transferProgress)
        {
            // Get the file size, used for displaying transfer progress.
            int fileSize = await GetFileSizeAsync(absolutePath);

            // Tell the server that we want to recieve a file.
            await _socket.SendSyncRequestAsync("RECV", absolutePath);

            int totalBytesRead = 0;
            string resp = await _socket.ReadResponseAsync();

            // The server will keep sending a "DATA" response as long as the file has not finished transmitting.
            while (resp == "DATA")
            {
                // NB: There is no need to check for a cancellation, that will be handled in a read operation later on in the loop.

                var replyLengthBytes = new byte[4];
                await _socket.ReadAsync(replyLengthBytes);

                if (!BitConverter.IsLittleEndian)
                {
                    // Switch the byte order if the system is big-endian.
                    Array.Reverse(replyLengthBytes);
                }
                int replyLength = BitConverter.ToInt32(replyLengthBytes, 0);

                // Get the data and update the total read count.
                var data = new byte[replyLength];
                int bytesRead = await _socket.ReadAsync(data, cancel);
                totalBytesRead += replyLength;

                // Write the data to the output stream, advancing the position for the next write.
                output.Write(data, 0, bytesRead);

                // Pass the number of bytes read so far and the total number of bytes to read to an updater function.
                transferProgress(totalBytesRead, fileSize);

                // Read the response for the next loop.
                resp = await _socket.ReadResponseAsync();
            }

            // The server will send "DONE" when the transfer completes successfully.
            if (resp != "DONE")
            {
                throw new AdbException($"An error occurred while retrieving the file {absolutePath}");
            }
        }

        public void Dispose()
        {
            if (_socket != null)
            {
                _socket.Dispose();
                _socket = null;
            }
        }
    }
}
