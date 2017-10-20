
namespace TextEditorTest
{
    public interface IFileManager
    {
        string GetContent(string path);
        void SaveContent(string path, string contents);
        int GetStringCount(string content);
        bool IsExist(string path);
    }
}
