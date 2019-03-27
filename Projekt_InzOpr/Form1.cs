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

            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Descending);
        }

        private void Form1_Load(object sender, EventArgs e) //nie pokazuje w ogole okna aplikacji
        {

                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "UDT.txt")) //zeby bylo widoczne tylko lokalnie
                {
                    string line = sr.ReadLine();
                    if (File.Exists(line))
                    {
                        Player.URL = CurrentVideoPath = line;
                        line = sr.ReadLine();
                        Player.Ctlcontrols.currentPosition = Convert.ToDouble(line);
                        line = sr.ReadLine();
                        ID_Filmu = Convert.ToInt32(line);

                        trackBarDzwiek.Value = Player.settings.volume;
                        czas();
                    }
                }

            CheckPlayPauseButton();
            if (SetCurrentTitle())
                this.Text = Title;

            this.panelHistoria.Height = Player.Height;
            this.dataGridView1.Height = panelHistoria.Height - 100;

            buttonWczytaj.Location = new Point(panelHistoria.Width / 2 - buttonWczytaj.Width / 2, panelHistoria.Height - 50 - buttonWczytaj.Height / 2);
            CzyByloZmieniane = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Player.URL == string.Empty)
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
                SetCurrentTitle();
                this.Text = Title;
                CzyByloZmieniane = true;
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
            string jakiesInfo;

            if (Player.playState == WMPLib.WMPPlayState.wmppsPaused || Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                jakiesInfo = CurrentVideoPath + "\n" + //sciezka do pliku aktualnie odtwarzanego
                    Player.Ctlcontrols.currentPosition + //aktualny czas odtwarzanego filmu/czegokolwiek
                    "\n" + ID_Filmu.ToString() +
                    "\n==END==\n";

                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "UDT.txt", jakiesInfo);
            }

            this.Close();
        }

        private string CurrentVideoPath { get; set; }

        private string Title { get; set; }

        private bool CzyByloZmieniane { get; set; }

        private bool SetCurrentTitle()
        {
            if (this.CurrentVideoPath == null)
            {
                MessageBox.Show("Pusta sciezka, nie mozna okreslic tytulu");
                Title = string.Empty;
                return false;
            }

            int lastBackslash = CurrentVideoPath.LastIndexOf('\\', CurrentVideoPath.Length - 1);
            if (lastBackslash < 0)
            {
                MessageBox.Show("Nie mozna okreslic tytulu");
                Title = string.Empty;
                return false;
            }

            Title = CurrentVideoPath.Substring(lastBackslash + 1);
            return true;
        }


        private void Player_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
            if (!Player.fullScreen)
            {
                //panel od sterowania
                if (e.fY > Player.Height - panelSterowanie.Height)
                {
                    panelSterowanie.Visible = true;
                }
                else
                {
                    panelSterowanie.Visible = false;
                }

                //panel od historii odtwarzania
                if(e.fX > Player.Width - panelHistoria.Width)
                {
                    dataGridView1.Height = panelHistoria.Height - 100;
                    this.obejrzaneFilmyTableAdapter.Fill(this.historiaOgladaniaDataSet.ObejrzaneFilmy);
                    buttonWczytaj.Location = new Point(panelHistoria.Width / 2 - buttonWczytaj.Width / 2, panelHistoria.Height - 50 - buttonWczytaj.Height / 2);
                    panelHistoria.Visible = true;
                }
                else
                {
                    panelHistoria.Visible = false;
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

            if ((int)this.Player.Ctlcontrols.currentPosition % 30 == 0)
                updateCzasZatrzymania();
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
            if (Player.playState == WMPLib.WMPPlayState.wmppsReady || Player.playState == WMPLib.WMPPlayState.wmppsPlaying || Player.playState == WMPLib.WMPPlayState.wmppsTransitioning)
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
            if (e.KeyChar == (char)27) //wcisniecie escape
            {
                //to do: wylaczenie fullscreena
            }
        }

        private static int ID_Filmu = 1;

        private void DodajDoHistorii()
        {
            if (this.Player.currentMedia != null)
            {
                try
                {
                    using (DataClasses1DataContext PolaczenieZBaza = new DataClasses1DataContext())
                    {
                        var Dane = new ObejrzaneFilmy();
                        Dane.Id = ID_Filmu++;
                        Dane.MomentZatrzymania = this.Player.Ctlcontrols.currentPosition;
                        Dane.SciezkaDoPliku = CurrentVideoPath;
                        if (Title.Length < 50)
                            Dane.Tytul = Title;
                        else
                            Dane.Tytul = Title.Substring(0, 50);

                        PolaczenieZBaza.ObejrzaneFilmies.InsertOnSubmit(Dane);
                        PolaczenieZBaza.SubmitChanges();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
            else
                MessageBox.Show("Nic nie jest odtwarzane");
        }

        private void Okno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("", "Jesteś pewien?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            if (this.CurrentVideoPath != null)
            {
                string jakiesInfo;

                if (Player.playState == WMPLib.WMPPlayState.wmppsPaused || Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    jakiesInfo = CurrentVideoPath + "\n" + //sciezka do pliku aktualnie odtwarzanego
                    Player.Ctlcontrols.currentPosition + //aktualny czas odtwarzanego filmu/czegokolwiek
                    "\n" + ID_Filmu.ToString() +
                    "\n==END==\n";

                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "UDT.txt", jakiesInfo);
                }
            }
        }

        private void buttonWczytaj_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1 || dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("Nic nie wybrales");
                return;
            }

            try
            {
                timer1.Stop();
                Player.URL = CurrentVideoPath = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                SetCurrentTitle();
                if (dataGridView1[2, dataGridView1.CurrentRow.Index].Value == null)
                {
                    this.Player.Ctlcontrols.currentPosition = 0;
                }
                else
                {     
                    this.Player.Ctlcontrols.currentPosition = Convert.ToDouble(dataGridView1[2, dataGridView1.CurrentRow.Index].Value);
                }
                lTime.Text = Player.currentMedia.durationString;
                timer1.Start();

                przesunElementHistorii(Convert.ToInt32(dataGridView1[0,dataGridView1.CurrentRow.Index].Value));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void przesunElementHistorii(int old_id)
        {
            using (DataClasses1DataContext Polaczenie = new DataClasses1DataContext())
            {
                var query =
                    from Film in Polaczenie.ObejrzaneFilmies
                    where Film.Id == old_id
                    select Film; //znajduje film o podanym ID

                ObejrzaneFilmy nowy = new ObejrzaneFilmy();
                foreach (ObejrzaneFilmy FM in query)
                {
                    nowy.Id = ID_Filmu++;
                    nowy.MomentZatrzymania = FM.MomentZatrzymania;
                    nowy.SciezkaDoPliku = FM.SciezkaDoPliku;
                    nowy.Tytul = FM.Tytul;
                    try
                    {
                        Polaczenie.ObejrzaneFilmies.InsertOnSubmit(nowy);
                        Polaczenie.ObejrzaneFilmies.DeleteOnSubmit(FM);
                        Polaczenie.SubmitChanges();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString());
                    }
                }

            }
            dataGridView1.Update();
        }


        private void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {         
            if(e.newState == 3 && CzyByloZmieniane == true)//odtwarza i media byly zmienione
            {
                CzyByloZmieniane = false;
                DodajDoHistorii();
            }
        }

        private void updateCzasZatrzymania()
        {
            DataClasses1DataContext Polaczenie = new DataClasses1DataContext();
            var query =
                    from Film in Polaczenie.ObejrzaneFilmies
                    where Film.Id == ID_Filmu-1
                    select Film; //znajduje ostatni dodany do historii film

            ObejrzaneFilmy nowy = new ObejrzaneFilmy();
            foreach (ObejrzaneFilmy FM in query)
            {
                FM.MomentZatrzymania = this.Player.Ctlcontrols.currentPosition;
                try
                {
                    Polaczenie.SubmitChanges();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
        }
    }
}
