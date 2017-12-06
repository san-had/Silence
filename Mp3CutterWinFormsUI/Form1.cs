namespace Mp3CutterWinFormsUI
{
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFileSelection_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtMp3FileName.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtMp3FileName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        public bool IsTextboxBoxNotEmpty(string textBoxContent, out string errorMessage)
        {
            if (textBoxContent.Length == 0)
            {
                errorMessage = "Empty TextBox content";
                return false;
            }
        }
    }
}