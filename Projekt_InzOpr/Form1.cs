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

        }

        private void Form1_Load(object sender, EventArgs e) //nie pokazuje w ogole okna aplikacji
        {

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "UDT.dt")) //istnieje pliczek
            {
                //https://docs.microsoft.com/en-us/windows/desktop/wmp/wmplibiwmpcontrols-iwmpcontrols-currentposition--vb-and-c
                //https://docs.microsoft.com/pl-pl/dotnet/api/system.io.streamreader?view=netframework-4.7.2

                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "UDT.dt")) //zeby bylo widoczne tylko lokalnie
                {
                    string line = sr.ReadLine();
                    if (File.Exists(line)) //plik ktory chcemy otworzyc istnieje
                    {
                        Player.URL = CurrentVideoPath = line;
                        line = sr.ReadLine();                  
                        Player.Ctlcontrols.currentPosition = Convert.ToDouble(line);
                        lATime.Text = Player.Ctlcontrols.currentPositionString;
                        button1_Click(null, null);
                    }
                }
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Player.playState == WMPLib.WMPPlayState.wmppsPlaying && button1.Text == "Play")
            {
                button1.Text = "Pause";
                return;
            }

            if(Player.playState == WMPLib.WMPPlayState.wmppsPaused) //przycisk nacisniety gdy jest zapauzowane
            {
                button1.Text = "Pause";
                Player.Ctlcontrols.play();
            }
            else if(Player.playState == WMPLib.WMPPlayState.wmppsPlaying) //przycisk nacisniety gdy cos leci
            {
                button1.Text = "Play";
                Player.Ctlcontrols.pause();
            }
            else if(Player.playState == WMPLib.WMPPlayState.wmppsUndefined)
            {
                MessageBox.Show("undefined");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentVideoPath = openFileDialog1.FileName;
                Player.URL = CurrentVideoPath;
                var clip = Player.newMedia(CurrentVideoPath);
                this.lTime.Text = TimeSpan.FromSeconds(clip.duration).ToString();
                timer1.Start();
            }
            else
                return;
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

                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "UDT.dt", jakiesInfo);
            }

            this.Close();

        }

        private string CurrentVideoPath { get; set; }


        private void panel2_MouseHover(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
        }

        private void Player_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
            this.panel1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lATime.Text = Player.Ctlcontrols.currentPositionString;
        }
    }

    //bedzie mi potrzebne do zrobienia historii ogladanych prawdopodobnie
    public class HistoriaOgladania
    {
        string sciezka;
        double czasZatrzymania;

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