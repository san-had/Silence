namespace Mp3CutterWinFormsUI
{
    using System;
    using System.Windows.Forms;
    using Mp3CutterExtensibility;
    using Mp3CutterExtensibility.Dto;
    using Mp3CutterService;

    public partial class Form1 : Form
    {
        private const string Mp3Extension = ".mp3";
        private const string InvalidFileMessage = "Hibás típusú file!";
        private const string SuccessFileMessage = "File sikeresen megvágva!";

        private int index = 0;

        private IMp3InputSetter mp3InputSetter;
        private Mp3Cutter mp3Cutter;

        public Form1()
        {
            InitializeComponent();
            mp3InputSetter = new Mp3InputSetter();
            mp3Cutter = new Mp3Cutter();
        }

        private void btnFileSelection_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtMp3FileName.Text = openFileDialog1.FileName;
            }
        }

        public bool IsTextboxBoxNotEmpty(string textBoxContent, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (textBoxContent.Length == 0)
            {
                errorMessage = "Empty TextBox content";
                return false;
            }
            return true;
        }

        private void btnExecution_Click(object sender, EventArgs e)
        {
            if (!IsFileNameValid())
            {
                MessageBox.Show(InvalidFileMessage, "Hiba!!");
            }

            var mp3Input = CreateInput();

            var mp3Output = mp3Cutter.ExecuteCut(mp3Input);

            txtMp3FileName.Text = mp3Output.Mp3OutputFileName;

            MessageBox.Show(SuccessFileMessage, "Ok");
        }

        private Mp3InputDto CreateInput()
        {
            var cuttingTimeDto = new CuttingTimeDto();

            cuttingTimeDto.BeginHour = Int32.Parse(txtBeginHour.Text);
            cuttingTimeDto.BeginMinute = Int32.Parse(txtBeginMinute.Text);
            cuttingTimeDto.BeginSecond = Int32.Parse(txtBeginSecond.Text);

            cuttingTimeDto.EndHour = Int32.Parse(txtEndHour.Text);
            cuttingTimeDto.EndMinute = Int32.Parse(txtEndMinute.Text);
            cuttingTimeDto.EndSecond = Int32.Parse(txtEndSecond.Text);

            index++;
            var mp3Input = mp3InputSetter.SetMp3InputDto(cuttingTimeDto, txtMp3FileName.Text, index);

            return mp3Input;
        }

        private bool IsFileNameValid()
        {
            return txtMp3FileName.Text.ToLower().EndsWith(Mp3Extension);
        }
    }
}