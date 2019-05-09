﻿using System;
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
        private bool czyYT = false;
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
            szukanie1.Clicked += YouTube_Play;
        }

        private void Form1_Load(object sender, EventArgs e) //nie pokazuje w ogole okna aplikacji
        {
            Wyglad();

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

        private void ButtonPlay_Click(object sender, EventArgs e)
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

        private void ButtonOtworz_Click(object sender, EventArgs e)
        {
            czyYT = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentVideoPath = openFileDialog1.FileName;
                Player.URL = CurrentVideoPath;
                Czas();
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

        private void Czas()
        {
            var clip = Player.newMedia(CurrentVideoPath);
            if (!czyYT)
            {
                lTime.Text = TimeSpan.FromSeconds(clip.duration).ToString();
                trackBarCzas.Maximum = (int)clip.duration + 1;
            }
            else
            {
                lTime.Text = TimeSpan.FromSeconds(Duration(szukanie1.Url)).ToString();
                trackBarCzas.Maximum = (int)Duration(szukanie1.Url) + 1;
            }
            timer1.Start();
        }

        private double Duration(String url)
        {
            int index = url.IndexOf("dur");
            String str1 = szukanie1.Url.Remove(0, index + 4);

            index = 0;
            while(!Char.IsLetter(str1[index]))
            {
                ++index;
            }

            return double.Parse(str1.Remove(index - 1), System.Globalization.CultureInfo.InvariantCulture);
           
            
        }
        private void ButtonZamknij_Click(object sender, EventArgs e)
        {
            this.Close();
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


        private void Timer1_Tick(object sender, EventArgs e)
        {
            trackBarCzas.Value = Player.Ctlcontrols.currentPosition;
        
            lATime.Text = Player.Ctlcontrols.currentPositionString;

            if (lATime.Text == lTime.Text)
            {
                timer1.Stop();
            }

            if ((int)this.Player.Ctlcontrols.currentPosition % 30 == 0)
                UpdateCzasZatrzymania();
        }

        private void TrackBarCzas_MouseCaptureChanged(object sender, EventArgs e)
        {
            
            Player.Ctlcontrols.currentPosition = trackBarCzas.Value;
           
        }

        private void ButtonFull_Click(object sender, EventArgs e)
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
            Wyglad();
        }
        private void Wyglad()
        {
            buttonOtworz.Location = new Point(panelSterowanie.Width - buttonOtworz.Width - 10, buttonOtworz.Location.Y);
            buttonZamknij.Location = new Point(buttonOtworz.Location.X, buttonZamknij.Location.Y);
            trackBarDzwiek.Location = new Point(buttonOtworz.Location.X - trackBarDzwiek.Width - 10, trackBarDzwiek.Location.Y);
            lTime.Location = new Point(trackBarDzwiek.Location.X - lTime.Width - 10, lTime.Location.Y);
            label1.Location = new Point(lTime.Location.X - label1.Width - 5, label1.Location.Y);
            lATime.Location = new Point(label1.Location.X - lATime.Width - 5, lATime.Location.Y);
            trackBarCzas.Width = lATime.Location.X - trackBarCzas.Location.X - 10;

        }

        private void TrackBarDzwiek_MouseCaptureChanged(object sender, EventArgs e)
        {
            Player.settings.volume = (int)trackBarDzwiek.Value;
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

        private void Okno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("", "Jesteś pewien?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

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

        private void YouTube_Play()
        {
            
            czyYT = true;
            Czas();
            Player.URL = szukanie1.Url;

        }

        private void ButtonYT_Click(object sender, EventArgs e)
        {
            szukanie1.Visible = true;
        }
    }
}
