using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_InzOpr
{
    public partial class Okno
    {
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

        private static int ID_Filmu = 1;

        private void DodajDoHistorii()
        {
            if (this.Player.currentMedia != null)
            {
                try
                {
                    using (DataClasses1DataContext PolaczenieZBaza = new DataClasses1DataContext())
                    {
                        var Dane = new ObejrzaneFilmy
                        {
                            Id = ID_Filmu++,
                            MomentZatrzymania = this.Player.Ctlcontrols.currentPosition,
                            SciezkaDoPliku = CurrentVideoPath
                        };
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

        private void ButtonWczytaj_Click(object sender, EventArgs e)
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

                Czas();

                PrzesunElementHistorii(Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value));

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void PrzesunElementHistorii(int old_id)
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
            if (e.newState == 3 && CzyByloZmieniane == true)//odtwarza i media byly zmienione
            {
                CzyByloZmieniane = false;
                DodajDoHistorii();
            }
            else if (e.newState == 1)
            {
                buttonPlay.Text = "Play";
            }
        }

        private void UpdateCzasZatrzymania()
        {
            DataClasses1DataContext Polaczenie = new DataClasses1DataContext();
            var query =
                    from Film in Polaczenie.ObejrzaneFilmies
                    where Film.Id == ID_Filmu - 1
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

        private void ButtonPoprzedni_Click(object sender, EventArgs e)
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

            Czas();

            PrzesunElementHistorii(Convert.ToInt32(dataGridView1[0, dataGridView1.RowCount - 2].Value));
        }
    }
}
