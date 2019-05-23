using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SolidEdge_Macro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog(); // .asm .psm
            string inputPath = null;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                inputPath = folderBrowser.SelectedPath;
            }

            label2.Text = inputPath;

            List<string> prtList = new List<string>();
            List<string> asmList = new List<string>();
            prtList.Clear();
            asmList.Clear();

            string[] files = Directory.GetFiles(inputPath, "*.par", SearchOption.AllDirectories);
            prtList.AddRange(files);
            
            files = Directory.GetFiles(inputPath, "*.asm", SearchOption.AllDirectories);
            asmList.AddRange(files);

            foreach (string file in prtList)
            {
                listBox1.Items.Add(Path.GetFileName(file));
            }

            foreach (string file in asmList)
            {
                listBox1.Items.Add(Path.GetFileName(file));
            }

            MessageBox.Show(listBox1.Items.Count.ToString());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog broseFolder = new FolderBrowserDialog {ShowNewFolderButton = true};
            string outPutFolder=null;

            if (broseFolder.ShowDialog() == DialogResult.OK)
            {
                outPutFolder = broseFolder.SelectedPath;
            }

            label5.Text = outPutFolder;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
