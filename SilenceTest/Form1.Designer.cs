namespace SilenceTest
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buOpen = new System.Windows.Forms.Button();
            this.buPlay = new System.Windows.Forms.Button();
            this.buStop = new System.Windows.Forms.Button();
            this.Volume = new System.Windows.Forms.TrackBar();
            this.Pan = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Position = new System.Windows.Forms.TrackBar();
            this.buExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Position)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buOpen
            // 
            this.buOpen.Location = new System.Drawing.Point(12, 12);
            this.buOpen.Name = "buOpen";
            this.buOpen.Size = new System.Drawing.Size(266, 67);
            this.buOpen.TabIndex = 0;
            this.buOpen.Text = "Open";
            this.buOpen.UseVisualStyleBackColor = true;
            this.buOpen.Click += new System.EventHandler(this.buOpen_Click);
            // 
            // buPlay
            // 
            this.buPlay.Location = new System.Drawing.Point(12, 85);
            this.buPlay.Name = "buPlay";
            this.buPlay.Size = new System.Drawing.Size(266, 74);
            this.buPlay.TabIndex = 1;
            this.buPlay.Text = "Play";
            this.buPlay.UseVisualStyleBackColor = true;
            this.buPlay.Click += new System.EventHandler(this.buPlay_Click);
            // 
            // buStop
            // 
            this.buStop.Location = new System.Drawing.Point(12, 165);
            this.buStop.Name = "buStop";
            this.buStop.Size = new System.Drawing.Size(266, 74);
            this.buStop.TabIndex = 2;
            this.buStop.Text = "Stop";
            this.buStop.UseVisualStyleBackColor = true;
            this.buStop.Click += new System.EventHandler(this.buStop_Click);
            // 
            // Volume
            // 
            this.Volume.Location = new System.Drawing.Point(284, 12);
            this.Volume.Name = "Volume";
            this.Volume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Volume.Size = new System.Drawing.Size(45, 227);
            this.Volume.TabIndex = 3;
            this.Volume.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // Pan
            // 
            this.Pan.Location = new System.Drawing.Point(368, 12);
            this.Pan.Name = "Pan";
            this.Pan.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Pan.Size = new System.Drawing.Size(45, 227);
            this.Pan.TabIndex = 4;
            this.Pan.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Pan.Value = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(405, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 219);
            this.label1.TabIndex = 5;
            this.label1.Text = "R             0            L";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(329, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 219);
            this.label2.TabIndex = 6;
            this.label2.Tag = " ";
            this.label2.Text = "100%                                                                             " +
    "                                                  0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Volume";
            // 
            // Position
            // 
            this.Position.Location = new System.Drawing.Point(12, 293);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(402, 45);
            this.Position.TabIndex = 9;
            this.Position.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // buExit
            // 
            this.buExit.Location = new System.Drawing.Point(12, 245);
            this.buExit.Name = "buExit";
            this.buExit.Size = new System.Drawing.Size(266, 28);
            this.buExit.TabIndex = 10;
            this.buExit.Text = "Exit";
            this.buExit.UseVisualStyleBackColor = true;
            this.buExit.Click += new System.EventHandler(this.buExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 329);
            this.Controls.Add(this.buExit);
            this.Controls.Add(this.Position);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Volume);
            this.Controls.Add(this.buStop);
            this.Controls.Add(this.buPlay);
            this.Controls.Add(this.buOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestSilence";
             ((System.ComponentModel.ISupportInitialize)(this.Volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Position)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buOpen;
        private System.Windows.Forms.Button buPlay;
        private System.Windows.Forms.Button buStop;
        private System.Windows.Forms.TrackBar Volume;
        private System.Windows.Forms.TrackBar Pan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar Position;
        private System.Windows.Forms.Button buExit;
    }
}

