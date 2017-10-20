using System;
using System.Windows.Forms;

namespace TextEditorTest
{
    class FileViewModel
    {
        private readonly IFileManager fileManager;
        private readonly IMainWindow mainWindow;

        private string currentPath;

        public FileViewModel(IMainWindow main, IFileManager manager)
        {
            fileManager = manager;
            mainWindow = main;

            mainWindow.SetSymbolCount(0);

            mainWindow.OnOpened += MainWindow_OnOpened;
            mainWindow.OnSave += MainWindow_OnSave;
            mainWindow.ContentChanget += MainWindow_ContentChanget;
        }

        private void MainWindow_ContentChanget(object sender, EventArgs e)
        {
            string content = mainWindow.Contents;
            int count = content.Length;
            mainWindow.SetSymbolCount(count);
        }

        private void MainWindow_OnSave(object sender, EventArgs e)
        {
            if (fileManager.IsExist(currentPath))
            {
                string content = mainWindow.Contents;
                fileManager.SaveContent(currentPath, content);
                MessageBox.Show("Файл успешно сохранен!");
            }
            MessageBox.Show("Файл не найден!");
        }

        private void MainWindow_OnOpened(object sender, EventArgs e)
        {
            try
            {
                string path = mainWindow.Path;
                bool isExist = fileManager.IsExist(path);

                if (!isExist)
                {
                    MessageBox.Show("Файл не найден!");
                    return;
                }

                currentPath = path;

                string content = fileManager.GetContent(path);
                int count = fileManager.GetStringCount(content);

                mainWindow.Contents = content;
                mainWindow.SetSymbolCount(count);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
