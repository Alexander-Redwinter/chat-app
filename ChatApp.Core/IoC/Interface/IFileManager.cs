using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ChatApp.Core
{
    public interface IFileManager
    {
        /// <summary>
        /// Writes text to file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="text">Text to write</param>
        /// <param name="append">True to append text, false to overwrite</param>
        /// <returns></returns>
        Task WriteTextToFileAsync(string path, string text, bool append = false);

        string NormalizePath(string path);

        string ResolvePath(string path);

    }
}
