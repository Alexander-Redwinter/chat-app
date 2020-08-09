using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ChatApp.Core
{
    public class FileManager : IFileManager
    {
        /// <summary>
        /// Writes text to file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="text">Text to write</param>
        /// <param name="append">True to append text, false to overwrite</param>
        /// <returns></returns>
        public async Task WriteTextToFileAsync(string path, string text, bool append = false)
        {
            path = NormalizePath(path);

            path = ResolvePath(path);

            try
            {
                await AsyncAwaiter.AwaitAsync((nameof(FileManager) + path), async () =>
                {
                    await Container.Task.Run(() =>
                    {
                        using (var fileStream = (TextWriter)new StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create)))
                            fileStream.Write(text);


                    });
                });

            }
            catch
            {
                Debugger.Break();
                throw;
            }
        }

        public string NormalizePath(string path)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return path?.Replace("/", "\\").Trim();
            else
                return path?.Replace("\\", "/").Trim();

        }

        public string ResolvePath(string path)
        {
            return Path.GetFullPath(path);
        }
    }
}
