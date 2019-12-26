namespace Mp3CutterWinFormsUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExecution = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBeginHour = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBeginMinute = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBeginSecond = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndSecond = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndMinute = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndHour = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtMp3FileName = new System.Windows.Forms.TextBox();
            this.btnFileSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExecution
            // 
            this.btnExecution.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecution.Location = new System.Drawing.Point(164, 321);
            this.btnExecution.Name = "btnExecution";
            this.btnExecution.Size = new System.Drawing.Size(146, 49);
            this.btnExecution.TabIndex = 0;
            this.btnExecution.Text = "Vágás";
            this.btnExecution.UseVisualStyleBackColor = true;
            this.btnExecution.Click += new System.EventHandler(this.btnExecution_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vágás kezdete:";
            // 
            // txtBeginHour
            // 
            this.txtBeginHour.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeginHour.Location = new System.Drawing.Point(181, 73);
            this.txtBeginHour.MaxLength = 2;
            this.txtBeginHour.Name = "txtBeginHour";
            this.txtBeginHour.Size = new System.Drawing.Size(29, 35);
            this.txtBeginHour.TabIndex = 3;
            this.txtBeginHour.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(228, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = ":";
            // 
            // txtBeginMinute
            // 
            this.txtBeginMinute.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeginMinute.Location = new System.Drawing.Point(270, 76);
            this.txtBeginMinute.MaxLength = 2;
            this.txtBeginMinute.Name = "txtBeginMinute";
            this.txtBeginMinute.Size = new System.Drawing.Size(29, 35);
            this.txtBeginMinute.TabIndex = 5;
            this.txtBeginMinute.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(327, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = ":";
            // 
            // txtBeginSecond
            // 
            this.txtBeginSecond.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeginSecond.Location = new System.Drawing.Point(369, 76);
            this.txtBeginSecond.MaxLength = 2;
            this.txtBeginSecond.Name = "txtBeginSecond";
            this.txtBeginSecond.Size = new System.Drawing.Size(31, 35);
            this.txtBeginSecond.TabIndex = 7;
            this.txtBeginSecond.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(158, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 34);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mp3 vágás";
            // 
            // txtEndSecond
            // 
            this.txtEndSecond.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndSecond.Location = new System.Drawing.Point(369, 159);
            this.txtEndSecond.MaxLength = 2;
            this.txtEndSecond.Name = "txtEndSecond";
            this.txtEndSecond.Size = new System.Drawing.Size(31, 35);
            this.txtEndSecond.TabIndex = 14;
            this.txtEndSecond.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(327, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = ":";
            // 
            // txtEndMinute
            // 
            this.txtEndMinute.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndMinute.Location = new System.Drawing.Point(270, 159);
            this.txtEndMinute.MaxLength = 2;
            this.txtEndMinute.Name = "txtEndMinute";
            this.txtEndMinute.Size = new System.Drawing.Size(29, 35);
            this.txtEndMinute.TabIndex = 12;
            this.txtEndMinute.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(228, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = ":";
            // 
            // txtEndHour
            // 
            this.txtEndHour.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndHour.Location = new System.Drawing.Point(181, 156);
            this.txtEndHour.MaxLength = 2;
            this.txtEndHour.Name = "txtEndHour";
            this.txtEndHour.Size = new System.Drawing.Size(29, 35);
            this.txtEndHour.TabIndex = 10;
            this.txtEndHour.Text = "00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 29);
            this.label7.TabIndex = 9;
            this.label7.Text = "Vágás vége:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtMp3FileName
            // 
            this.txtMp3FileName.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMp3FileName.Location = new System.Drawing.Point(95, 246);
            this.txtMp3FileName.MaxLength = 255;
            this.txtMp3FileName.Name = "txtMp3FileName";
            this.txtMp3FileName.Size = new System.Drawing.Size(326, 35);
            this.txtMp3FileName.TabIndex = 17;
            // 
            // btnFileSelection
            // 
            this.btnFileSelection.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileSelection.Location = new System.Drawing.Point(32, 246);
            this.btnFileSelection.Name = "btnFileSelection";
            this.btnFileSelection.Size = new System.Drawing.Size(57, 35);
            this.btnFileSelection.TabIndex = 18;
            this.btnFileSelection.Text = "File:";
            this.btnFileSelection.UseVisualStyleBackColor = true;
            this.btnFileSelection.Click += new System.EventHandler(this.btnFileSelection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 417);
            this.Controls.Add(this.btnFileSelection);
            this.Controls.Add(this.txtMp3FileName);
            this.Controls.Add(this.txtEndSecond);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEndMinute);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEndHour);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBeginSecond);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBeginMinute);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBeginHour);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExecution);
            this.Name = "Form1";
            this.Text = "Mp3 vágó";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBeginHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBeginMinute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBeginSecond;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEndSecond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndMinute;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEndHour;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtMp3FileName;
        private System.Windows.Forms.Button btnFileSelection;
    }
}

