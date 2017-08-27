using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkExtractor.Adb
{
    struct Device
    {
        /// <summary>
        /// The device's serial number.
        /// </summary>
        public string Serial { get; private set; }
        /// <summary>
        /// The device's current status.
        /// </summary>
        public string Status { get; private set; }
        /// <summary>
        /// The product name.
        /// </summary>
        public string Product { get; private set; }
        /// <summary>
        /// The model name.
        /// </summary>
        public string Model { get; private set; }
        /// <summary>
        /// The device's name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Creates an instance of <see cref="Device"/> from an ADB device info string.
        /// </summary>
        /// <param name="data">The info string, as output by ADB.</param>
        /// <returns>An instance of <see cref="Device"/> with properties set using <paramref name="data"/>.</returns>
        public static Device FromString(string data)
        {
            var device = new Device();

            var split = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Set the serial no. and status.
            device.Serial = split[0];
            device.Status = split[1];

            // Set the rest of the values (each one has the form of prefix:value).
            foreach (var item in split.Skip(2))
            {
                // First item = prefix, second item = value
                var pair = item.Split(':');
                switch (pair[0])
                {
                    case "product":
                        device.Product = pair[1];
                        break;
                    case "model":
                        device.Model = pair[1];
                        break;
                    case "device":
                        device.Name = pair[1];
                        break;
                    default:
                        break;
                }
            }

            // Return the device info.
            return device;
        }
    }
}
