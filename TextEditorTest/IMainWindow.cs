using System;

namespace TextEditorTest
{
    interface IMainWindow
    {
        string Path { get; }
        string Contents { get; set; }
        void SetSymbolCount(int count);
        event EventHandler OnOpened;
        event EventHandler OnSave;
        event EventHandler ContentChanget;
    }
}
