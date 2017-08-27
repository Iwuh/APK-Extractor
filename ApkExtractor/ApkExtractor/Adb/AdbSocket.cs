using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApkExtractor.Adb
{
    class AdbSocket : IDisposable
    {
        private TcpClient _socket;
        private readonly Encoding _ascii;

        public AdbSocket()
        {
            // Initialise a new connection to the ADB server port, with a buffer size of 64 KB.
            _socket = new TcpClient("localhost", 5037) { ReceiveBufferSize = 64 * 1024 };
            _ascii = Encoding.ASCII;
        }

        public NetworkStream Stream => _socket.GetStream();

        /// <summary>
        /// Asynchronously transmits data to the socket.
        /// </summary>
        /// <param name="data">The formatted data to transmit.</param>
        public async Task WriteAsync(byte[] data) => await _socket.GetStream().WriteAsync(data, 0, data.Length);

        /// <summary>
        /// Asynchronously sends a request to the ADB file transfer ("sync") service.
        /// </summary>
        /// <param name="request">The sync request (i.e.: RECV, STAT, etc)</param>
        /// <param name="absolutePath">The absolute path to the file.</param>
        public async Task SendSyncRequestAsync(string request, string absolutePath)
        {
            // The path length in a sync request must be a little endian 4 byte integer.
            byte[] lengthBytes = BitConverter.GetBytes(absolutePath.Length);
            if (!BitConverter.IsLittleEndian)
            {
                // Switch the array to little-endian if the program is running on a big-endian system.
                Array.Reverse(lengthBytes);
            }

            await WriteAsync(_ascii.GetBytes(request));
            await WriteAsync(lengthBytes);
            await WriteAsync(_ascii.GetBytes(absolutePath));
        }

        /// <summary>
        /// Gets the 4 character ADB response header.
        /// </summary>
        /// <returns>The response header as a string.</returns>
        public async Task<string> ReadResponseAsync()
        {
            var resp = new byte[4];
            await ReadAsync(resp);
            return _ascii.GetString(resp);
        }

        /// <summary>
        /// Get the ADB response body.
        /// </summary>
        /// <returns>The response body as a string.</returns>
        public async Task<string> ReadAdbStringAsync()
        {
            // The first 4 bytes of a response string are a hex number representing the response length.
            var lengthBytes = new byte[4];
            await ReadAsync(lengthBytes);

            int responseLength = int.Parse(_ascii.GetString(lengthBytes), NumberStyles.HexNumber);
            var responseBytes = new byte[responseLength];
            await ReadAsync(responseBytes);
            return _ascii.GetString(responseBytes);
        }

        public async Task<string> ReadSyncStringAsync()
        {
            // The response length is a 4 byte little endian integer.
            var lengthBytes = new byte[4];
            await ReadAsync(lengthBytes);
            if (!BitConverter.IsLittleEndian)
            {
                // Switch the array from little to big endian if the system is big-endian.
                Array.Reverse(lengthBytes);
            }

            int responseLength = BitConverter.ToInt32(lengthBytes, 0);
            var response = new byte[responseLength];
            await ReadAsync(response);
            return _ascii.GetString(response);
        }

        /// <summary>
        /// Asynchronously reads a number of bytes from the socket to a byte array.
        /// </summary>
        /// <param name="bytes">The byte array to write to.</param>
        /// <param name="length">The number of bytes to read.</param>
        /// <param name="cancel">The <see cref="CancellationToken"/> that can be used to cancel the read operation.</param>
        /// <returns>The number of bytes read.</returns>
        /// <exception cref="OperationCanceledException">Thrown if <paramref name="cancel"/> is cancelled.</exception>
        public async Task<int> ReadAsync(byte[] bytes, int length, CancellationToken cancel)
        {
            // The number of bytes read in the last read operation.
            int readOnCurrentPass = -1;
            // The total number of bytes that have been read.
            int totalRead = 0;

            // As long as the latest read retrieved data and we have not read the requested number of bytes...
            while (readOnCurrentPass != 0 && totalRead < length)
            {
                // If the read operation was cancelled, throw an exception so that the caller can clean up.
                cancel.ThrowIfCancellationRequested();

                int bytesRemaining = length - totalRead;
                // If the amount of bytes remaining is lower than the recieve buffer size, use it, otherwise use the recieve buffer size.
                int amountToRead = bytesRemaining < _socket.ReceiveBufferSize ? bytesRemaining : _socket.ReceiveBufferSize;

                // Read from the stream into the buffer.
                var buffer = new byte[amountToRead];
                readOnCurrentPass = await _socket.GetStream().ReadAsync(buffer, 0, readOnCurrentPass);

                // Copy the buffer into the output byte array.
                Array.Copy(buffer, 0, bytes, totalRead, readOnCurrentPass);
                // Update the total number of bytes read.
                totalRead += readOnCurrentPass;
            }

            // Return the number of bytes read.
            return totalRead;
        }

        /// <summary>
        /// Asynchronously reads a number of bytes from the socket to a byte array.
        /// </summary>
        /// <param name="bytes">The byte array to write to.</param>
        /// <param name="cancel">The <see cref="CancellationToken"/> that can be used to cancel the read operation.</param>
        /// <returns>The number of bytes read.</returns>
        /// <exception cref="OperationCanceledException">Thrown if <paramref name="cancel"/> is cancelled.</exception>
        public async Task<int> ReadAsync(byte[] bytes, CancellationToken cancel) => await ReadAsync(bytes, bytes.Length, cancel);

        /// <summary>
        /// Asynchronously reads a number of bytes from the socket to a byte array.
        /// </summary>
        /// <param name="bytes">The byte array to write to.</param>
        /// <returns>The number of bytes read.</returns>
        public async Task<int> ReadAsync(byte[] bytes) => await ReadAsync(bytes, bytes.Length, CancellationToken.None);

        /// <summary>
        /// Sets the default device for the current <see cref="AdbSocket"/> instance.
        /// </summary>
        /// <param name="deviceSerial">The device's serial number.</param>
        /// <returns>Whether or not the device was successfully set.</returns>
        public async Task<bool> SetDeviceAsync(Device device)
        {
            // Set the default device for the current socket.
            await WriteAsync(AdbClient.FormAdbRequest($"host:transport:{device.Serial}"));
            string resp = await ReadResponseAsync();

            if (resp != "OKAY")
            {
                // Clear the error message from the stream.
                await ReadAdbStringAsync();
                return false;
            }
            return true;
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
