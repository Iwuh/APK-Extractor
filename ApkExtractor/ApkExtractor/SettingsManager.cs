using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkExtractor
{
    public class SettingsManager
    {
        private const string SETTINGS_FILE = @".\ApkExtractorSettings.txt";

        private readonly UTF8Encoding _encoding;

        public SettingsManager()
        {
            _encoding = new UTF8Encoding(false);

            if (File.Exists(SETTINGS_FILE))
            {
                // Read the file contents and set the property.
                using (var fs = File.OpenRead(SETTINGS_FILE))
                {
                    var contents = new byte[fs.Length];
                    fs.Read(contents, 0, (int)fs.Length);

                    AdbPath = _encoding.GetString(contents);
                }
            }
        }

        /// <summary>
        /// The currently set path to the ADB executable, or null if no path is set.
        /// </summary>
        public string AdbPath { get; private set; }

        /// <summary>
        /// Writes to the settings file and updates <see cref="AdbPath"/>.
        /// </summary>
        /// <param name="path">The text to write.</param>
        public void SetPath(string path)
        {
            // Write the selected path.
            using (var fs = File.Open(SETTINGS_FILE, FileMode.OpenOrCreate))
            {
                var bytes = _encoding.GetBytes(path);
                fs.Write(bytes, 0, bytes.Length);
            }

            AdbPath = path;
        }

        /// <summary>
        /// Gets the set path, or null if no path is set.
        /// </summary>
        /// <param name="str">The variable to output to. Will be the path if one is set, otherwise null.</param>
        /// <returns>Whether or not a path was set.</returns>
        public bool TryGetPath(out string str)
        {
            str = AdbPath;
            return AdbPath != null;
        }
    }
}
