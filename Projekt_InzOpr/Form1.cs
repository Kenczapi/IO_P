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
            wyglad();

            this.obejrzaneFilmyTableAdapter.Fill(this.historiaOgladaniaDataSet.ObejrzaneFilmy);

            if (dataGridView1.Rows.Count > 1) //jest cos w tabeli
            {
                ID_Filmu = Convert.ToInt32(dataGridView1[0, 0].Value) + 1;
                Player.URL = CurrentVideoPath = dataGridView1[0, 1].Value.ToString();
                this.Player.Ctlcontrols.currentPosition = Convert.ToDouble(dataGridView1[0, 2].Value);
                if (SetCurrentTitle())
                    this.Text = Title;
                trackBarDzwiek.Value = Player.settings.volume;
            }


            CheckPlayPauseButton();

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
                if(SetCurrentTitle())
                {
                    this.Text = Title;
                }
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


        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBarCzas.Value = Player.Ctlcontrols.currentPosition;
        
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
            
            Player.Ctlcontrols.currentPosition = trackBarCzas.Value;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Fullscreen")
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                button4.Text = "Normal";

            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.WindowState = FormWindowState.Normal;
                button4.Text = "Fullscreen";
            }
            wyglad();
        }
        private void wyglad()
        {
            buttonOtworz.Location = new Point(panelSterowanie.Width - buttonOtworz.Width - 10, buttonOtworz.Location.Y);
            buttonZamknij.Location = new Point(buttonOtworz.Location.X, buttonZamknij.Location.Y);
            trackBarDzwiek.Location = new Point(buttonOtworz.Location.X - trackBarDzwiek.Width - 10, trackBarDzwiek.Location.Y);
            lTime.Location = new Point(trackBarDzwiek.Location.X - lTime.Width - 10, lTime.Location.Y);
            label1.Location = new Point(lTime.Location.X - label1.Width - 5, label1.Location.Y);
            lATime.Location = new Point(label1.Location.X - lATime.Width - 5, lATime.Location.Y);
            trackBarCzas.Width = lATime.Location.X - trackBarCzas.Location.X - 10;

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
                MessageBox.Show("PPPPP");
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.WindowState = FormWindowState.Normal;
                button4.Text = "Fullscreen";
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
        }

        private void Okno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("", "Jesteś pewien?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
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
                if (SetCurrentTitle())
                    this.Text = Title;
                if (dataGridView1[2, dataGridView1.CurrentRow.Index].Value == null)
                {
                    this.Player.Ctlcontrols.currentPosition = 0;
                }
                else
                {
                    this.Player.Ctlcontrols.currentPosition = Convert.ToDouble(dataGridView1[2, dataGridView1.CurrentRow.Index].Value);
                }
                timer1.Start();

                czas();

                przesunElementHistorii(Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value));

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
            else if(e.newState == 1)
            {
                buttonPlay.Text = "Play";
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

        private void buttonPoprzedni_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 2) //puste badz 1 film
            {
                return;
            }

            timer1.Stop();
            Player.URL = CurrentVideoPath = dataGridView1[1, dataGridView1.RowCount - 2].Value.ToString();
            if (SetCurrentTitle())
                this.Text = Title;
            if (dataGridView1[2, dataGridView1.RowCount - 2].Value == null)
            {
                this.Player.Ctlcontrols.currentPosition = 0;
            }
            else
            {
                this.Player.Ctlcontrols.currentPosition = Convert.ToDouble(dataGridView1[2, dataGridView1.RowCount - 2].Value);
            }
            timer1.Start();

            czas();

            przesunElementHistorii(Convert.ToInt32(dataGridView1[0, dataGridView1.RowCount - 2].Value));
        }

        private void Okno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) //wcisniecie escape
            {
              
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.WindowState = FormWindowState.Normal;
                button4.Text = "Fullscreen";
            }
        }
    }
}
