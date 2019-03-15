using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace Projekt_InzOpr
{
    public partial class Okno : Form
    {

        public Okno()
        {
            InitializeComponent();
            this.Player.uiMode = "none"; //musi byc ustawione tutau, bo jak zmieniam we wlasciwosciach to nie dziala
            this.WindowState = FormWindowState.Normal;
            Player.stretchToFit = true;         
        }

        private void Form1_Load(object sender, EventArgs e) //nie pokazuje w ogole okna aplikacji
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "UDT.txt")) //istnieje pliczek
            {
                //https://docs.microsoft.com/en-us/windows/desktop/wmp/wmplibiwmpcontrols-iwmpcontrols-currentposition--vb-and-c
                //https://docs.microsoft.com/pl-pl/dotnet/api/system.io.streamreader?view=netframework-4.7.2

                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "UDT.txt")) //zeby bylo widoczne tylko lokalnie
                {
                    string line = sr.ReadLine();
                    if (File.Exists(line)) //plik ktory chcemy otworzyc istnieje
                    {
                        Player.URL = CurrentVideoPath = line;
                        line = sr.ReadLine();
                        Player.Ctlcontrols.currentPosition = Convert.ToDouble(line);
                        
                        trackBarDzwiek.Value = Player.settings.volume;
                        czas();
                    }
                }
            }
            CheckPlayPauseButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Player.URL == string.Empty)
            {
                MessageBox.Show("Nie podano scieżki do żadnego filmu.", "Brak filmu.", MessageBoxButtons.OK);
                return;
            }

            if (Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Player.Ctlcontrols.pause();
                buttonPlay.Text = "Play";
                timer1.Stop();
            }
            else //przycisk nacisniety gdy jest zapauzowane
            {
                Player.Ctlcontrols.play();
                buttonPlay.Text = "Pause";
                timer1.Start();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentVideoPath = openFileDialog1.FileName;
                Player.URL = CurrentVideoPath;
                czas();
                CheckPlayPauseButton();
            }
            else
                return;
        }

        private void czas()
        {
            var clip = Player.newMedia(CurrentVideoPath);
            this.lTime.Text = TimeSpan.FromSeconds(clip.duration).ToString();
            trackBarCzas.Maximum = (int)clip.duration + 1;
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // https://docs.microsoft.com/en-us/windows/desktop/wmp/player-playstate

            string jakiesInfo;

            if (Player.playState == WMPLib.WMPPlayState.wmppsPaused || Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                jakiesInfo = CurrentVideoPath + "\n" + //sciezka do pliku aktualnie odtwarzanego
                Player.Ctlcontrols.currentPosition + //aktualny czas odtwarzanego filmu/czegokolwiek
                "\n==END==\n";

                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "UDT.txt", jakiesInfo);
            }

            this.Close();

        }

        private string CurrentVideoPath { get; set; }


        private void Player_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
            if (!Player.fullScreen)
            {
                if (e.fY > Player.Height - panelSterowanie.Height)
                {
                    panelSterowanie.Visible = true;
                }
                else
                {
                    panelSterowanie.Visible = false;
                }
            }
            else
            {


            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBarCzas.Value = (int)Player.Ctlcontrols.currentPosition;
            lATime.Text = Player.Ctlcontrols.currentPositionString;

            if (lATime.Text == lTime.Text)
            {
                timer1.Stop();
            }
        }

        private void trackBar1_MouseCaptureChanged(object sender, EventArgs e)
        {
            Player.Ctlcontrols.currentPosition = (double)trackBarCzas.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;         
        }

        private void trackBar2_MouseCaptureChanged(object sender, EventArgs e)
        {
            Player.settings.volume = trackBarDzwiek.Value;
        }

        private void CheckPlayPauseButton()
        {
            if(Player.playState == WMPLib.WMPPlayState.wmppsReady || Player.playState == WMPLib.WMPPlayState.wmppsPlaying || Player.playState == WMPLib.WMPPlayState.wmppsTransitioning)
            {
                //gotowe do odtwarzania , odtwarza, przygotowuje sie do odtworzenia
                buttonPlay.Text = "Pause";
            }
            else
            {
                //Uzywalem do testowania stanow odtwarzacza MessageBox.Show("Current Player.playState: " + Player.playState.ToString());
                buttonPlay.Text = "Play";
            }
        }

        private void Okno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)27) //wcisniecie escape
            {
                //to do: wylaczenie fullscreena
            }
        }
    }

    public class HistoriaOgladania
    {
            string sciezka;
            double czasZatrzymania;

            //bedzie mi potrzebne do zrobienia historii ogladanych prawdopodobnie
            public HistoriaOgladania()
            {
                this.sciezka = string.Empty;
                this.czasZatrzymania = 0;
            }

            public HistoriaOgladania(string s, double c)
            {
                this.sciezka = s;
                this.czasZatrzymania = c;
            }

            public override string ToString()
            {
                return (sciezka + "\n"
                    + czasZatrzymania
                    + "\n==END==\n");
            }
    }
}
