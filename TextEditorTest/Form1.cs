using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditorTest
{
    public partial class Form1 : Form, IMainWindow
    {
        public event EventHandler OnOpened;
        public event EventHandler OnSave;
        public event EventHandler ContentChanget;

        public Form1()
        {
            InitializeComponent();
            txtContent.TextChanged += TxtContent_TextChanged;
        }

        private void TxtContent_TextChanged(object sender, EventArgs e)
        {
            ContentChanget?.Invoke(this, e);
        }

        public string Path { get { return txtPath.Text; } }

        public string Contents
        {
            get { return txtContent.Text; }
            set { txtContent.Text = value; }
        }

        public void SetSymbolCount(int count)
        {
            statusLable.Text = count.ToString();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dialog.FileName;
                OnOpened?.Invoke(this, e);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            OnSave?.Invoke(this, e);
        }
    }
}
