using System;
using System.Drawing;
using System.Windows.Forms;

namespace Projekt_InzOpr
{
    partial class Okno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Okno));
            this.Player = new AxWMPLib.AxWindowsMediaPlayer();
            this.panelSterowanie = new System.Windows.Forms.Panel();
            this.trackBarCzas = new Projekt_InzOpr.ColorSlider();
            this.trackBarDzwiek = new Projekt_InzOpr.ColorSlider();
            this.buttonPoprzedni = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.lATime = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonZamknij = new System.Windows.Forms.Button();
            this.buttonOtworz = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelHistoria = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sciezkaDoPlikuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.momentZatrzymaniaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tytulDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obejrzaneFilmyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.historiaOgladaniaDataSet = new Projekt_InzOpr.HistoriaOgladaniaDataSet();
            this.buttonWczytaj = new System.Windows.Forms.Button();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tytulDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czasCalyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czasZatrzymaniaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sciezkaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obejrzaneFilmyTableAdapter = new Projekt_InzOpr.HistoriaOgladaniaDataSetTableAdapters.ObejrzaneFilmyTableAdapter();
            this.szukanie1 = new Projekt_InzOpr.Szukanie();
            this.buttonYT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.panelSterowanie.SuspendLayout();
            this.panelHistoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obejrzaneFilmyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historiaOgladaniaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Player
            // 
            this.Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Player.Enabled = true;
            this.Player.Location = new System.Drawing.Point(0, 0);
            this.Player.Name = "Player";
            this.Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player.OcxState")));
            this.Player.Size = new System.Drawing.Size(1276, 917);
            this.Player.TabIndex = 0;
            this.Player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.Player_PlayStateChange);
            this.Player.MouseMoveEvent += new AxWMPLib._WMPOCXEvents_MouseMoveEventHandler(this.Player_MouseMoveEvent);
            // 
            // panelSterowanie
            // 
            this.panelSterowanie.AutoSize = true;
            this.panelSterowanie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSterowanie.BackColor = System.Drawing.Color.Transparent;
            this.panelSterowanie.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSterowanie.BackgroundImage")));
            this.panelSterowanie.Controls.Add(this.buttonYT);
            this.panelSterowanie.Controls.Add(this.trackBarCzas);
            this.panelSterowanie.Controls.Add(this.trackBarDzwiek);
            this.panelSterowanie.Controls.Add(this.buttonPoprzedni);
            this.panelSterowanie.Controls.Add(this.label1);
            this.panelSterowanie.Controls.Add(this.lTime);
            this.panelSterowanie.Controls.Add(this.lATime);
            this.panelSterowanie.Controls.Add(this.button4);
            this.panelSterowanie.Controls.Add(this.buttonZamknij);
            this.panelSterowanie.Controls.Add(this.buttonOtworz);
            this.panelSterowanie.Controls.Add(this.buttonPlay);
            this.panelSterowanie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSterowanie.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelSterowanie.Location = new System.Drawing.Point(0, 833);
            this.panelSterowanie.Name = "panelSterowanie";
            this.panelSterowanie.Size = new System.Drawing.Size(1276, 84);
            this.panelSterowanie.TabIndex = 1;
            this.panelSterowanie.Visible = false;
            // 
            // trackBarCzas
            // 
            this.trackBarCzas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            this.trackBarCzas.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarCzas.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarCzas.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarCzas.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarCzas.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarCzas.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarCzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarCzas.ForeColor = System.Drawing.Color.White;
            this.trackBarCzas.LargeChange = ((uint)(5u));
            this.trackBarCzas.Location = new System.Drawing.Point(322, 34);
            this.trackBarCzas.Name = "trackBarCzas";
            this.trackBarCzas.ScaleDivisions = 10;
            this.trackBarCzas.ScaleSubDivisions = 5;
            this.trackBarCzas.ShowDivisionsText = true;
            this.trackBarCzas.ShowSmallScale = false;
            this.trackBarCzas.Size = new System.Drawing.Size(75, 23);
            this.trackBarCzas.SmallChange = ((uint)(1u));
            this.trackBarCzas.TabIndex = 14;
            this.trackBarCzas.Text = "colorSlider1";
            this.trackBarCzas.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarCzas.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarCzas.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarCzas.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarCzas.TickAdd = 0F;
            this.trackBarCzas.TickColor = System.Drawing.Color.White;
            this.trackBarCzas.TickDivide = 0F;
            this.trackBarCzas.Value = 30D;
            this.trackBarCzas.MouseCaptureChanged += new System.EventHandler(this.TrackBarCzas_MouseCaptureChanged);
            // 
            // trackBarDzwiek
            // 
            this.trackBarDzwiek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            this.trackBarDzwiek.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarDzwiek.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarDzwiek.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarDzwiek.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarDzwiek.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarDzwiek.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarDzwiek.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarDzwiek.ForeColor = System.Drawing.Color.White;
            this.trackBarDzwiek.LargeChange = ((uint)(5u));
            this.trackBarDzwiek.Location = new System.Drawing.Point(1118, 6);
            this.trackBarDzwiek.Name = "trackBarDzwiek";
            this.trackBarDzwiek.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarDzwiek.ScaleDivisions = 10;
            this.trackBarDzwiek.ScaleSubDivisions = 5;
            this.trackBarDzwiek.ShowDivisionsText = true;
            this.trackBarDzwiek.ShowSmallScale = false;
            this.trackBarDzwiek.Size = new System.Drawing.Size(23, 75);
            this.trackBarDzwiek.SmallChange = ((uint)(1u));
            this.trackBarDzwiek.TabIndex = 13;
            this.trackBarDzwiek.Text = "colorSlider1";
            this.trackBarDzwiek.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarDzwiek.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarDzwiek.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarDzwiek.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarDzwiek.TickAdd = 0F;
            this.trackBarDzwiek.TickColor = System.Drawing.Color.White;
            this.trackBarDzwiek.TickDivide = 0F;
            this.trackBarDzwiek.Value = 30D;
            this.trackBarDzwiek.MouseCaptureChanged += new System.EventHandler(this.TrackBarDzwiek_MouseCaptureChanged);
            // 
            // buttonPoprzedni
            // 
            this.buttonPoprzedni.Location = new System.Drawing.Point(3, 49);
            this.buttonPoprzedni.Name = "buttonPoprzedni";
            this.buttonPoprzedni.Size = new System.Drawing.Size(75, 23);
            this.buttonPoprzedni.TabIndex = 12;
            this.buttonPoprzedni.Text = "Poprzedni";
            this.buttonPoprzedni.UseVisualStyleBackColor = true;
            this.buttonPoprzedni.Click += new System.EventHandler(this.ButtonPoprzedni_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1041, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "/";
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(1059, 14);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(34, 13);
            this.lTime.TabIndex = 7;
            this.lTime.Text = "00:00";
            // 
            // lATime
            // 
            this.lATime.AutoSize = true;
            this.lATime.Location = new System.Drawing.Point(990, 14);
            this.lATime.Name = "lATime";
            this.lATime.Size = new System.Drawing.Size(34, 13);
            this.lATime.TabIndex = 6;
            this.lATime.Text = "00:00";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(101, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Fullscreen";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ButtonFull_Click);
            // 
            // buttonZamknij
            // 
            this.buttonZamknij.Location = new System.Drawing.Point(1161, 49);
            this.buttonZamknij.Name = "buttonZamknij";
            this.buttonZamknij.Size = new System.Drawing.Size(75, 23);
            this.buttonZamknij.TabIndex = 2;
            this.buttonZamknij.Text = "Zamknij";
            this.buttonZamknij.UseVisualStyleBackColor = true;
            this.buttonZamknij.Click += new System.EventHandler(this.ButtonZamknij_Click);
            // 
            // buttonOtworz
            // 
            this.buttonOtworz.Location = new System.Drawing.Point(1162, 4);
            this.buttonOtworz.Name = "buttonOtworz";
            this.buttonOtworz.Size = new System.Drawing.Size(75, 23);
            this.buttonOtworz.TabIndex = 1;
            this.buttonOtworz.Text = "Otwórz";
            this.buttonOtworz.UseVisualStyleBackColor = true;
            this.buttonOtworz.Click += new System.EventHandler(this.ButtonOtworz_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(3, 4);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Pause";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panelHistoria
            // 
            this.panelHistoria.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelHistoria.Controls.Add(this.dataGridView1);
            this.panelHistoria.Controls.Add(this.buttonWczytaj);
            this.panelHistoria.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelHistoria.Location = new System.Drawing.Point(1026, 0);
            this.panelHistoria.Name = "panelHistoria";
            this.panelHistoria.Size = new System.Drawing.Size(250, 833);
            this.panelHistoria.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.sciezkaDoPlikuDataGridViewTextBoxColumn,
            this.momentZatrzymaniaDataGridViewTextBoxColumn,
            this.tytulDataGridViewTextBoxColumn1});
            this.dataGridView1.DataSource = this.obejrzaneFilmyBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(250, 421);
            this.dataGridView1.TabIndex = 2;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.idDataGridViewTextBoxColumn1.Visible = false;
            // 
            // sciezkaDoPlikuDataGridViewTextBoxColumn
            // 
            this.sciezkaDoPlikuDataGridViewTextBoxColumn.DataPropertyName = "SciezkaDoPliku";
            this.sciezkaDoPlikuDataGridViewTextBoxColumn.HeaderText = "SciezkaDoPliku";
            this.sciezkaDoPlikuDataGridViewTextBoxColumn.Name = "sciezkaDoPlikuDataGridViewTextBoxColumn";
            this.sciezkaDoPlikuDataGridViewTextBoxColumn.ReadOnly = true;
            this.sciezkaDoPlikuDataGridViewTextBoxColumn.Visible = false;
            // 
            // momentZatrzymaniaDataGridViewTextBoxColumn
            // 
            this.momentZatrzymaniaDataGridViewTextBoxColumn.DataPropertyName = "MomentZatrzymania";
            this.momentZatrzymaniaDataGridViewTextBoxColumn.HeaderText = "MomentZatrzymania";
            this.momentZatrzymaniaDataGridViewTextBoxColumn.Name = "momentZatrzymaniaDataGridViewTextBoxColumn";
            this.momentZatrzymaniaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tytulDataGridViewTextBoxColumn1
            // 
            this.tytulDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tytulDataGridViewTextBoxColumn1.DataPropertyName = "Tytul";
            this.tytulDataGridViewTextBoxColumn1.HeaderText = "Tytul";
            this.tytulDataGridViewTextBoxColumn1.Name = "tytulDataGridViewTextBoxColumn1";
            this.tytulDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // obejrzaneFilmyBindingSource
            // 
            this.obejrzaneFilmyBindingSource.DataMember = "ObejrzaneFilmy";
            this.obejrzaneFilmyBindingSource.DataSource = this.historiaOgladaniaDataSet;
            // 
            // historiaOgladaniaDataSet
            // 
            this.historiaOgladaniaDataSet.DataSetName = "HistoriaOgladaniaDataSet";
            this.historiaOgladaniaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonWczytaj
            // 
            this.buttonWczytaj.Location = new System.Drawing.Point(83, 573);
            this.buttonWczytaj.Name = "buttonWczytaj";
            this.buttonWczytaj.Size = new System.Drawing.Size(75, 23);
            this.buttonWczytaj.TabIndex = 1;
            this.buttonWczytaj.Text = "Wczytaj";
            this.buttonWczytaj.UseVisualStyleBackColor = true;
            this.buttonWczytaj.Click += new System.EventHandler(this.ButtonWczytaj_Click);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // tytulDataGridViewTextBoxColumn
            // 
            this.tytulDataGridViewTextBoxColumn.Name = "tytulDataGridViewTextBoxColumn";
            // 
            // czasCalyDataGridViewTextBoxColumn
            // 
            this.czasCalyDataGridViewTextBoxColumn.Name = "czasCalyDataGridViewTextBoxColumn";
            // 
            // czasZatrzymaniaDataGridViewTextBoxColumn
            // 
            this.czasZatrzymaniaDataGridViewTextBoxColumn.Name = "czasZatrzymaniaDataGridViewTextBoxColumn";
            // 
            // sciezkaDataGridViewTextBoxColumn
            // 
            this.sciezkaDataGridViewTextBoxColumn.Name = "sciezkaDataGridViewTextBoxColumn";
            // 
            // obejrzaneFilmyTableAdapter
            // 
            this.obejrzaneFilmyTableAdapter.ClearBeforeFill = true;
            // 
            // szukanie1
            // 
            this.szukanie1.Location = new System.Drawing.Point(262, 82);
            this.szukanie1.Name = "szukanie1";
            this.szukanie1.Size = new System.Drawing.Size(587, 420);
            this.szukanie1.TabIndex = 3;
            this.szukanie1.Visible = false;
            // 
            // buttonYT
            // 
            this.buttonYT.Location = new System.Drawing.Point(1063, 49);
            this.buttonYT.Name = "buttonYT";
            this.buttonYT.Size = new System.Drawing.Size(30, 23);
            this.buttonYT.TabIndex = 15;
            this.buttonYT.Text = "YT";
            this.buttonYT.UseVisualStyleBackColor = true;
            this.buttonYT.Click += new System.EventHandler(this.ButtonYT_Click);
            // 
            // Okno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1276, 917);
            this.Controls.Add(this.szukanie1);
            this.Controls.Add(this.panelHistoria);
            this.Controls.Add(this.panelSterowanie);
            this.Controls.Add(this.Player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(1280, 960);
            this.Name = "Okno";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Okno_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Okno_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.panelSterowanie.ResumeLayout(false);
            this.panelSterowanie.PerformLayout();
            this.panelHistoria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obejrzaneFilmyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historiaOgladaniaDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelSterowanie;
        private System.Windows.Forms.Button buttonZamknij;
        private System.Windows.Forms.Button buttonOtworz;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Label label1;
        private Label lTime;
        private Label lATime;
        private Timer timer1;
        private AxWMPLib.AxWindowsMediaPlayer Player;
        private Panel panelHistoria;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tytulDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn czasCalyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn czasZatrzymaniaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sciezkaDataGridViewTextBoxColumn;
        private Button buttonWczytaj;
        private DataGridView dataGridView1;
        private HistoriaOgladaniaDataSet historiaOgladaniaDataSet;
        private BindingSource obejrzaneFilmyBindingSource;
        private HistoriaOgladaniaDataSetTableAdapters.ObejrzaneFilmyTableAdapter obejrzaneFilmyTableAdapter;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn sciezkaDoPlikuDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn momentZatrzymaniaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tytulDataGridViewTextBoxColumn1;
        private Button buttonPoprzedni;
        private ColorSlider trackBarDzwiek;
        private ColorSlider trackBarCzas;
        private Szukanie szukanie1;
        private Button buttonYT;
    }
}

