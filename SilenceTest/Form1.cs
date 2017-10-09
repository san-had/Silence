#region © Copyright 2012, Luca Farias
/* Copyright (c) 2012, Luca Farias 
L'autorizzazione è concessa, a titolo gratuito, a chiunque ottenga una copia
di questo software e dei file di documentazione associati , per utilizzare
il Software senza limitazioni, compresi, senza esclusione, i diritti
di usare, copiare, modificare, unire, pubblicare, distribuire, concedere in licenza e / o vendere
copie del Software, e di consentire alle persone a cui il software è
fornito le stesse, fatte salve le seguenti condizioni:

L'avviso di copyright e l'avviso di autorizzazione devono essere incluse in
tutte le copie o parti sostanziali del Software.

IL SOFTWARE VIENE FORNITO "COSÌ COM'È", SENZA GARANZIE DI ALCUN TIPO, ESPRESSE O
IMPLICITE, INCLUSE, MA NON SOLO, LE GARANZIE DI COMMERCIABILITÀ,
IDONEITÀ PER UN PARTICOLARE SCOPO E NON VIOLAZIONE. 
IN NESSUN CASO L'AUTORI O TITOLARI DEL COPYRIGHT POTRANNO ESSERE RITENUTI RESPONSABILI 
PER EVENTUALI RECLAMI, DANNI O ALTRE RESPONSABILITÀ, SIA IN UN'AZIONE DI CONTRATTO, 
TORTO O ALTRO, DERIVANTI DA ESSO, O IN CONNESSIONE CON IL SOFTWARE STESSO O L'USO 
 */
/* Copyright (c) 2012, Luca Farias 

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files , to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SilenceTest
{
    public partial class Form1 : Form
    {
        Silence.Audio PlayFile;   // Classe che esegue il Play del file
        private Timer CurrentTimer = new Timer();    // timer per la gestione del cursore della posizione attuale nella traccia 
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);  // Gestione Evento Chiusura della finestra
            Pan.ValueChanged  += new  EventHandler(Pan_EditValueChanged);        // Evento variazione TrackBar del Volume
            Volume.ValueChanged  += new EventHandler(Volume_EditValueChanged);   // Evento varione valore Trac Bar bilanciamento dei canali
            CurrentTimer.Tick += new EventHandler(CurrentTime_Tick);             // Evento per la gestione della barra di avanzamento Attuale Posizione
            Position.ValueChanged  += new EventHandler(Position_Scroll);         // Gestione del posizionamento nella traccia
        }

        private void Position_Scroll(object sender, EventArgs e)
        {
            if (PlayFile != null)
            {
                PlayFile.TimePosition = TimeSpan.FromSeconds(Position.Value);
            }
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            // La dispose della classe è necessaria chiudere i flussi ed evitare errori
            PlayFile.Dispose();
        }
        private void Pan_EditValueChanged(object sender, EventArgs e)
        {
            // il valore varia tra -1.0 e 1.0
            System.Diagnostics.Debug.Print("PAN = " + (float)Pan.Value / 10);  
            PlayFile.Pan = (float)Pan.Value / 10;
        }
        private void Volume_EditValueChanged(object sender, EventArgs e)
        {
            // il valore varia tra 1.0 (max) e 0 (mute)
            float a = (float)(Volume.Value) / 10;
            PlayFile.Volume = a;
        }
        private void CurrentTime_Tick(object sender, EventArgs e)
        {
            if (PlayFile != null)
            {
                TimeSpan currentTime = (PlayFile.State == Silence.Audio.PlayBackState.Stopped) ? TimeSpan.Zero : PlayFile.TimePosition;
           
                Position.Value = (int)currentTime.TotalSeconds;

            }
        }

        private void buOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();


            PlayFile  = new Silence.Audio (openFileDialog1.FileName);
            this.Text = "TestSilence -" + openFileDialog1.FileName;  
        }

        private void buStop_Click(object sender, EventArgs e)
        {
            PlayFile.Stop(); 
        }

        private void buPlay_Click(object sender, EventArgs e)
        {
            if (PlayFile == null) return;

            switch (PlayFile.State ) 
            {
                case Silence.Audio.PlayBackState.Paused :
                    buPlay.Text = "Pausa"; 
                    PlayFile.Play (); 
                    break; 
                case Silence.Audio.PlayBackState.Playing :
                    buPlay.Text = "Play"; 
                    PlayFile.Pause ();
                    break;
                case Silence.Audio.PlayBackState.Stopped :

                     buPlay.Text = "Pausa";
                     Pan.Minimum  = -10;
                     Pan.Maximum = 10;

                     CurrentTimer.Interval = 3000; // il valore dipende dal livello di compressione nel caso di file Mp3
                     CurrentTimer.Enabled = true;

                     Pan.Value = 0;


                     Position.Maximum = (int)PlayFile.TotalDuration.TotalSeconds;
                     Position.TickFrequency = Position.Maximum / 30;

                     PlayFile.Play();

                     Volume.Value = 5;

                    break; 
            }

        }

        private void buExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
