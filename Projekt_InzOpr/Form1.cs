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
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "UDT.dt")) //istnieje pliczek
            {
                //https://docs.microsoft.com/en-us/windows/desktop/wmp/wmplibiwmpcontrols-iwmpcontrols-currentposition--vb-and-c
                //https://docs.microsoft.com/pl-pl/dotnet/api/system.io.streamreader?view=netframework-4.7.2

                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "UDT.dt")) //zeby bylo widoczne tylko lokalnie
                {          
                    string line = sr.ReadLine();
                    if (File.Exists(line)) //plik ktory chcemy otworzyc istnieje
                    {
                        //MessageBox.Show(line);  //testing only
                        Player.URL = CurrentVideoPath = line;
                        line = sr.ReadLine();
                        //MessageBox.Show(line);
                        Player.Ctlcontrols.currentPosition = Convert.ToDouble(line);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Pause")
            {
                Player.Ctlcontrols.pause();
                button1.Text = "Play";
            }
            else
            {
                Player.Ctlcontrols.play();
                button1.Text = "Pause";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentVideoPath = openFileDialog1.FileName;
                Player.URL = CurrentVideoPath;
            }
            else
                return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // https://docs.microsoft.com/en-us/windows/desktop/wmp/player-playstate

            string jakiesInfo;
            
            if(Player.playState == WMPLib.WMPPlayState.wmppsPaused || Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                jakiesInfo = CurrentVideoPath + "\n" + //sciezka do pliku aktualnie odtwarzanego
                Player.Ctlcontrols.currentPosition + //aktualny czas odtwarzanego filmu/czegokolwiek
                "\n==END==\n";

                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "UDT.dt", jakiesInfo);
            }

            this.Close();
            
        }

        private void buttonTime(object sender)
        {
            ///https://stackoverflow.com/questions/25864958/how-to-update-a-label-by-windows-media-player-current-position-live-without-usi
            /// byc moze skorzystam z tego

            (sender as Button).Text = "Current time:\n" + Player.Ctlcontrols.currentPositionString;
        }

        private string CurrentVideoPath { get; set; }
    }

}