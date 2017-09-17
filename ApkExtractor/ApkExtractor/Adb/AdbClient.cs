using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkExtractor.Adb
{
    public class AdbClient
    {
        /// <summary>
        /// Starts the ADB server if it's not already running.
        /// </summary>
        /// <param name="adbPath">The path to the ADB executable.</param>
        /// <returns>The client instance.</returns>
        public AdbClient StartAdbServer(string adbPath)
        {
            if (!File.Exists(adbPath) || !string.Equals(Path.GetFileName(adbPath), "adb.exe", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"The file {adbPath} does not exist or is not a valid ADB executable.");
            }

            var psi = new ProcessStartInfo(adbPath, "start-server")
            {
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            // Run the process using the above settings
            using (var p = Process.Start(psi))
            {
                // If the process doesn't exit on its own within 5 seconds, kill it.
                if (!p.WaitForExit(5000))
                {
                    p.Kill();
                }
            }

            return this;
        }

        /// <summary>
        /// Gets all the devices currently connected to the computer.
        /// </summary>
        /// <returns>A collection of <see cref="Device"/>.</returns>
        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            using (var socket = new AdbSocket())
            {
                // Send the request and verify the response code.
                await socket.WriteAsync(FormAdbRequest("host:devices-l"));
                var resp = await socket.ReadResponseAsync();

                // If the exception is thrown we don't need to worry about reading the rest of the incoming data because the socket will get closed.
                if (resp != "OKAY") throw new AdbException("An error occurred when getting the connected devices.");

                // Get the response and split it into individual lines (in the event of multiple devices).
                var deviceStrings = (await socket.ReadAdbStringAsync()).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                // Generate a device from each line.
                return deviceStrings.Select(s => Device.FromString(s));
            }
        }

        public async Task<string> ExecuteShellCommandAsync(Device device, string command)
        {
            using (var socket = new AdbSocket())
            {
                // Set the device that the command should be executed on.
                await socket.SetDeviceAsync(device);
                // Send the command.
                await socket.WriteAsync(FormAdbRequest($"shell:{command}"));

                // Read and verify the response.
                var resp = await socket.ReadResponseAsync();
                if (resp != "OKAY") throw new AdbException($"An error occurred when executing the remote shell command: {command}");

                // The response to a shell command doesn't have a length header so we just read and return the entire thing.
                using (var reader = new StreamReader(socket.Stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        /// <summary>
        /// Formats an ADB request to be transmitted to the server.
        /// </summary>
        /// <param name="request">The request to format.</param>
        /// <returns>The formatted request as a byte array.</returns>
        public static byte[] FormAdbRequest(string request) => Encoding.ASCII.GetBytes(request.Length.ToString("X4") + request);
    }
}
