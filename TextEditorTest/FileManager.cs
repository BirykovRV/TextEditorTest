using System.IO;
using System.Text;

namespace TextEditorTest
{
    class FileManager : IFileManager
    {
        private readonly Encoding defaultEncoding = Encoding.Default;

        public string GetContent(string path)
        {
            string content = File.ReadAllText(path, defaultEncoding);
            return content;
        }

        public int GetStringCount(string content)
        {
            return content.Length;
        }

        public bool IsExist(string path)
        {
            return File.Exists(path);
        }

        public void SaveContent(string path, string contents)
        {
            File.WriteAllText(path, contents, defaultEncoding);
        }
    }
}
