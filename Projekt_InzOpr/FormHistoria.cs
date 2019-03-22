using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_InzOpr
{
    public partial class FormHistoria : Form
    {
        private Okno parentW;

        public FormHistoria(Okno parentWindow)
        {
            InitializeComponent();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.MultiSelect = false;
            this.parentW = parentWindow;
        }

        private void FormHistoria_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'serwerHistoriaDataSet1.Tabela' table. You can move, or remove it, as needed.
            this.tabelaTableAdapter.Fill(this.serwerHistoriaDataSet1.Tabela);
            // TODO: This line of code loads data into the 'serwerHistoriaDataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.serwerHistoriaDataSet.Table);
        }

        private void buttonWczytajZaznaczone_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
                parentW.cl = Convert.ToDouble(dataGridView1[2, dataGridView1.CurrentRow.Index].Value);
                if(dataGridView1[3,dataGridView1.CurrentRow.Index].Value == null)
                {
                    parentW.zt = 0;
                }
                else
                {
                    parentW.zt = Convert.ToDouble(dataGridView1[3, dataGridView1.CurrentRow.Index].Value);
                }
                parentW.sc = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            parentW.ZmienOdtwarzane();
            this.Close();
        }
    }
}
