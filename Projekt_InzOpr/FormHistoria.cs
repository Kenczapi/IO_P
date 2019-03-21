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
        public FormHistoria()
        {
            InitializeComponent();
        }

        private void FormHistoria_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'serwerHistoriaDataSet1.Tabela' table. You can move, or remove it, as needed.
            this.tabelaTableAdapter.Fill(this.serwerHistoriaDataSet1.Tabela);
            // TODO: This line of code loads data into the 'serwerHistoriaDataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.serwerHistoriaDataSet.Table);

        }
    }
}
