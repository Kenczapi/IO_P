namespace Projekt_InzOpr
{
    partial class FormHistoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serwerHistoriaDataSet = new Projekt_InzOpr.SerwerHistoriaDataSet();
            this.tableTableAdapter = new Projekt_InzOpr.SerwerHistoriaDataSetTableAdapters.TableTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.serwerHistoriaDataSet1 = new Projekt_InzOpr.SerwerHistoriaDataSet1();
            this.tabelaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabelaTableAdapter = new Projekt_InzOpr.SerwerHistoriaDataSet1TableAdapters.TabelaTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tytulDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czasCalyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czasZatrzymaniaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sciezkaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serwerHistoriaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serwerHistoriaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataMember = "Table";
            this.tableBindingSource.DataSource = this.serwerHistoriaDataSet;
            // 
            // serwerHistoriaDataSet
            // 
            this.serwerHistoriaDataSet.DataSetName = "SerwerHistoriaDataSet";
            this.serwerHistoriaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableTableAdapter
            // 
            this.tableTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.tytulDataGridViewTextBoxColumn,
            this.czasCalyDataGridViewTextBoxColumn,
            this.czasZatrzymaniaDataGridViewTextBoxColumn,
            this.sciezkaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tabelaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 396);
            this.dataGridView1.TabIndex = 0;
            // 
            // serwerHistoriaDataSet1
            // 
            this.serwerHistoriaDataSet1.DataSetName = "SerwerHistoriaDataSet1";
            this.serwerHistoriaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabelaBindingSource
            // 
            this.tabelaBindingSource.DataMember = "Tabela";
            this.tabelaBindingSource.DataSource = this.serwerHistoriaDataSet1;
            // 
            // tabelaTableAdapter
            // 
            this.tabelaTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // tytulDataGridViewTextBoxColumn
            // 
            this.tytulDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tytulDataGridViewTextBoxColumn.DataPropertyName = "Tytul";
            this.tytulDataGridViewTextBoxColumn.HeaderText = "Tytul";
            this.tytulDataGridViewTextBoxColumn.Name = "tytulDataGridViewTextBoxColumn";
            // 
            // czasCalyDataGridViewTextBoxColumn
            // 
            this.czasCalyDataGridViewTextBoxColumn.DataPropertyName = "CzasCaly";
            this.czasCalyDataGridViewTextBoxColumn.HeaderText = "CzasCaly";
            this.czasCalyDataGridViewTextBoxColumn.Name = "czasCalyDataGridViewTextBoxColumn";
            // 
            // czasZatrzymaniaDataGridViewTextBoxColumn
            // 
            this.czasZatrzymaniaDataGridViewTextBoxColumn.DataPropertyName = "CzasZatrzymania";
            this.czasZatrzymaniaDataGridViewTextBoxColumn.HeaderText = "CzasZatrzymania";
            this.czasZatrzymaniaDataGridViewTextBoxColumn.Name = "czasZatrzymaniaDataGridViewTextBoxColumn";
            // 
            // sciezkaDataGridViewTextBoxColumn
            // 
            this.sciezkaDataGridViewTextBoxColumn.DataPropertyName = "Sciezka";
            this.sciezkaDataGridViewTextBoxColumn.HeaderText = "Sciezka";
            this.sciezkaDataGridViewTextBoxColumn.Name = "sciezkaDataGridViewTextBoxColumn";
            // 
            // FormHistoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormHistoria";
            this.Text = "FormHistoria";
            this.Load += new System.EventHandler(this.FormHistoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serwerHistoriaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serwerHistoriaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private SerwerHistoriaDataSet serwerHistoriaDataSet;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private SerwerHistoriaDataSetTableAdapters.TableTableAdapter tableTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SerwerHistoriaDataSet1 serwerHistoriaDataSet1;
        private System.Windows.Forms.BindingSource tabelaBindingSource;
        private SerwerHistoriaDataSet1TableAdapters.TabelaTableAdapter tabelaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tytulDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn czasCalyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn czasZatrzymaniaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sciezkaDataGridViewTextBoxColumn;
    }
}