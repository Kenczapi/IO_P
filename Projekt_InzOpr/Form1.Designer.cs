﻿using System;
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
            this.panelSterowanie = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonYT = new System.Windows.Forms.Button();
            this.buttonPoprzedni = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.lATime = new System.Windows.Forms.Label();
            this.buttonFull = new System.Windows.Forms.Button();
            this.ButtonZamknij = new System.Windows.Forms.Button();
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
            this.panelYT = new System.Windows.Forms.Panel();
            this.buttonYTWczytaj = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uRLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.momentZatrzymaniaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.historiaYoutubeDataSet = new Projekt_InzOpr.HistoriaYoutubeDataSet();
            this.yTTableAdapter = new Projekt_InzOpr.HistoriaYoutubeDataSetTableAdapters.YTTableAdapter();
            this.Player = new AxWMPLib.AxWindowsMediaPlayer();
            this.szukanie1 = new Projekt_InzOpr.Szukanie();
            this.trackBarDzwiek = new Projekt_InzOpr.ColorSlider();
            this.trackBarCzas = new Projekt_InzOpr.ColorSlider();
            this.button2 = new System.Windows.Forms.Button();
            this.panelSterowanie.SuspendLayout();
            this.panelHistoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obejrzaneFilmyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historiaOgladaniaDataSet)).BeginInit();
            this.panelYT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historiaYoutubeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSterowanie
            // 
            this.panelSterowanie.AutoSize = true;
            this.panelSterowanie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSterowanie.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSterowanie.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSterowanie.BackgroundImage")));
            this.panelSterowanie.Controls.Add(this.button2);
            this.panelSterowanie.Controls.Add(this.button1);
            this.panelSterowanie.Controls.Add(this.trackBarDzwiek);
            this.panelSterowanie.Controls.Add(this.buttonYT);
            this.panelSterowanie.Controls.Add(this.buttonPoprzedni);
            this.panelSterowanie.Controls.Add(this.label1);
            this.panelSterowanie.Controls.Add(this.lTime);
            this.panelSterowanie.Controls.Add(this.lATime);
            this.panelSterowanie.Controls.Add(this.buttonFull);
            this.panelSterowanie.Controls.Add(this.ButtonZamknij);
            this.panelSterowanie.Controls.Add(this.buttonOtworz);
            this.panelSterowanie.Controls.Add(this.buttonPlay);
            this.panelSterowanie.Controls.Add(this.trackBarCzas);
            this.panelSterowanie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSterowanie.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelSterowanie.Location = new System.Drawing.Point(0, 871);
            this.panelSterowanie.Name = "panelSterowanie";
            this.panelSterowanie.Size = new System.Drawing.Size(1256, 46);
            this.panelSterowanie.TabIndex = 1;
            this.panelSterowanie.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonYT
            // 
            this.buttonYT.Location = new System.Drawing.Point(826, 20);
            this.buttonYT.Name = "buttonYT";
            this.buttonYT.Size = new System.Drawing.Size(30, 23);
            this.buttonYT.TabIndex = 15;
            this.buttonYT.Text = "YT";
            this.buttonYT.UseVisualStyleBackColor = true;
            this.buttonYT.Click += new System.EventHandler(this.ButtonYT_Click);
            // 
            // buttonPoprzedni
            // 
            this.buttonPoprzedni.Location = new System.Drawing.Point(513, 20);
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
            this.label1.Location = new System.Drawing.Point(1086, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "/";
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(1104, 25);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(34, 13);
            this.lTime.TabIndex = 7;
            this.lTime.Text = "00:00";
            // 
            // lATime
            // 
            this.lATime.AutoSize = true;
            this.lATime.Location = new System.Drawing.Point(1046, 25);
            this.lATime.Name = "lATime";
            this.lATime.Size = new System.Drawing.Size(34, 13);
            this.lATime.TabIndex = 6;
            this.lATime.Text = "00:00";
            // 
            // buttonFull
            // 
            this.buttonFull.Location = new System.Drawing.Point(0, 20);
            this.buttonFull.Name = "buttonFull";
            this.buttonFull.Size = new System.Drawing.Size(66, 23);
            this.buttonFull.TabIndex = 3;
            this.buttonFull.Text = "Fullscreen";
            this.buttonFull.UseVisualStyleBackColor = true;
            this.buttonFull.Click += new System.EventHandler(this.ButtonFull_Click);
            // 
            // ButtonZamknij
            // 
            this.ButtonZamknij.Location = new System.Drawing.Point(1177, 20);
            this.ButtonZamknij.Name = "ButtonZamknij";
            this.ButtonZamknij.Size = new System.Drawing.Size(75, 23);
            this.ButtonZamknij.TabIndex = 2;
            this.ButtonZamknij.Text = "Zamknij";
            this.ButtonZamknij.UseVisualStyleBackColor = true;
            this.ButtonZamknij.Click += new System.EventHandler(this.ButtonZamknij_Click);
            // 
            // buttonOtworz
            // 
            this.buttonOtworz.Location = new System.Drawing.Point(675, 20);
            this.buttonOtworz.Name = "buttonOtworz";
            this.buttonOtworz.Size = new System.Drawing.Size(75, 23);
            this.buttonOtworz.TabIndex = 1;
            this.buttonOtworz.Text = "Otwórz";
            this.buttonOtworz.UseVisualStyleBackColor = true;
            this.buttonOtworz.Click += new System.EventHandler(this.ButtonOtworz_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(594, 20);
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
            this.panelHistoria.Location = new System.Drawing.Point(1006, 0);
            this.panelHistoria.Name = "panelHistoria";
            this.panelHistoria.Size = new System.Drawing.Size(250, 871);
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
            // panelYT
            // 
            this.panelYT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelYT.Controls.Add(this.buttonYTWczytaj);
            this.panelYT.Controls.Add(this.dataGridView2);
            this.panelYT.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelYT.Location = new System.Drawing.Point(0, 0);
            this.panelYT.Name = "panelYT";
            this.panelYT.Size = new System.Drawing.Size(239, 871);
            this.panelYT.TabIndex = 4;
            // 
            // buttonYTWczytaj
            // 
            this.buttonYTWczytaj.Location = new System.Drawing.Point(57, 573);
            this.buttonYTWczytaj.Name = "buttonYTWczytaj";
            this.buttonYTWczytaj.Size = new System.Drawing.Size(75, 23);
            this.buttonYTWczytaj.TabIndex = 1;
            this.buttonYTWczytaj.Text = "Wczytaj";
            this.buttonYTWczytaj.UseVisualStyleBackColor = true;
            this.buttonYTWczytaj.Click += new System.EventHandler(this.buttonYTWczytaj_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn2,
            this.uRLDataGridViewTextBoxColumn,
            this.momentZatrzymaniaDataGridViewTextBoxColumn1,
            this.titleDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.yTBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(239, 421);
            this.dataGridView2.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn2
            // 
            this.idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn2.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
            this.idDataGridViewTextBoxColumn2.Visible = false;
            // 
            // uRLDataGridViewTextBoxColumn
            // 
            this.uRLDataGridViewTextBoxColumn.DataPropertyName = "URL";
            this.uRLDataGridViewTextBoxColumn.HeaderText = "URL";
            this.uRLDataGridViewTextBoxColumn.Name = "uRLDataGridViewTextBoxColumn";
            this.uRLDataGridViewTextBoxColumn.Visible = false;
            // 
            // momentZatrzymaniaDataGridViewTextBoxColumn1
            // 
            this.momentZatrzymaniaDataGridViewTextBoxColumn1.DataPropertyName = "MomentZatrzymania";
            this.momentZatrzymaniaDataGridViewTextBoxColumn1.HeaderText = "MomentZatrzymania";
            this.momentZatrzymaniaDataGridViewTextBoxColumn1.Name = "momentZatrzymaniaDataGridViewTextBoxColumn1";
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // yTBindingSource
            // 
            this.yTBindingSource.DataMember = "YT";
            this.yTBindingSource.DataSource = this.historiaYoutubeDataSet;
            // 
            // historiaYoutubeDataSet
            // 
            this.historiaYoutubeDataSet.DataSetName = "HistoriaYoutubeDataSet";
            this.historiaYoutubeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // yTTableAdapter
            // 
            this.yTTableAdapter.ClearBeforeFill = true;
            // 
            // Player
            // 
            this.Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Player.Enabled = true;
            this.Player.Location = new System.Drawing.Point(0, 0);
            this.Player.Name = "Player";
            this.Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player.OcxState")));
            this.Player.Size = new System.Drawing.Size(1256, 917);
            this.Player.TabIndex = 0;
            this.Player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.Player_PlayStateChange1);
            this.Player.ClickEvent += new AxWMPLib._WMPOCXEvents_ClickEventHandler(this.Player_ClickEvent);
            this.Player.MouseMoveEvent += new AxWMPLib._WMPOCXEvents_MouseMoveEventHandler(this.Player_MouseMoveEvent);
            // 
            // szukanie1
            // 
            this.szukanie1.Location = new System.Drawing.Point(262, 82);
            this.szukanie1.Name = "szukanie1";
            this.szukanie1.Size = new System.Drawing.Size(587, 420);
            this.szukanie1.TabIndex = 3;
            this.szukanie1.Visible = false;
            // 
            // trackBarDzwiek
            // 
            this.trackBarDzwiek.BackColor = System.Drawing.Color.Transparent;
            this.trackBarDzwiek.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarDzwiek.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarDzwiek.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarDzwiek.ColorSchema = Projekt_InzOpr.ColorSlider.ColorSchemas.RedColors;
            this.trackBarDzwiek.ElapsedInnerColor = System.Drawing.Color.Red;
            this.trackBarDzwiek.ElapsedPenColorBottom = System.Drawing.Color.Salmon;
            this.trackBarDzwiek.ElapsedPenColorTop = System.Drawing.Color.LightCoral;
            this.trackBarDzwiek.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarDzwiek.ForeColor = System.Drawing.Color.White;
            this.trackBarDzwiek.LargeChange = ((uint)(5u));
            this.trackBarDzwiek.Location = new System.Drawing.Point(902, 20);
            this.trackBarDzwiek.Name = "trackBarDzwiek";
            this.trackBarDzwiek.ScaleDivisions = 10;
            this.trackBarDzwiek.ScaleSubDivisions = 5;
            this.trackBarDzwiek.ShowDivisionsText = true;
            this.trackBarDzwiek.ShowSmallScale = false;
            this.trackBarDzwiek.Size = new System.Drawing.Size(109, 23);
            this.trackBarDzwiek.SmallChange = ((uint)(1u));
            this.trackBarDzwiek.TabIndex = 13;
            this.trackBarDzwiek.Text = "colorSlider1";
            this.trackBarDzwiek.ThumbInnerColor = System.Drawing.Color.Red;
            this.trackBarDzwiek.ThumbPenColor = System.Drawing.Color.Red;
            this.trackBarDzwiek.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.trackBarDzwiek.ThumbSize = new System.Drawing.Size(16, 16);
            this.trackBarDzwiek.TickAdd = 0F;
            this.trackBarDzwiek.TickColor = System.Drawing.Color.White;
            this.trackBarDzwiek.TickDivide = 0F;
            this.trackBarDzwiek.Value = 30D;
            this.trackBarDzwiek.MouseCaptureChanged += new System.EventHandler(this.TrackBarDzwiek_MouseCaptureChanged);
            // 
            // trackBarCzas
            // 
            this.trackBarCzas.BackColor = System.Drawing.Color.Transparent;
            this.trackBarCzas.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.trackBarCzas.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.trackBarCzas.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.trackBarCzas.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.trackBarCzas.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.trackBarCzas.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.trackBarCzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.trackBarCzas.ForeColor = System.Drawing.Color.White;
            this.trackBarCzas.LargeChange = ((uint)(5u));
            this.trackBarCzas.Location = new System.Drawing.Point(12, 0);
            this.trackBarCzas.Name = "trackBarCzas";
            this.trackBarCzas.ScaleDivisions = 10;
            this.trackBarCzas.ScaleSubDivisions = 5;
            this.trackBarCzas.ShowDivisionsText = true;
            this.trackBarCzas.ShowSmallScale = false;
            this.trackBarCzas.Size = new System.Drawing.Size(1232, 23);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(363, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Okno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1256, 917);
            this.Controls.Add(this.panelYT);
            this.Controls.Add(this.szukanie1);
            this.Controls.Add(this.panelHistoria);
            this.Controls.Add(this.panelSterowanie);
            this.Controls.Add(this.Player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(1276, 960);
            this.Name = "Okno";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Okno_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Okno_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Okno_KeyPress);
            this.panelSterowanie.ResumeLayout(false);
            this.panelSterowanie.PerformLayout();
            this.panelHistoria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obejrzaneFilmyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historiaOgladaniaDataSet)).EndInit();
            this.panelYT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historiaYoutubeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonZamknij;
        private System.Windows.Forms.Button buttonOtworz;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonFull;
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
        private System.Windows.Forms.Panel panelSterowanie;
        private Panel panelYT;
        private Button buttonYTWczytaj;
        private DataGridView dataGridView2;
        private HistoriaYoutubeDataSet historiaYoutubeDataSet;
        private BindingSource yTBindingSource;
        private HistoriaYoutubeDataSetTableAdapters.YTTableAdapter yTTableAdapter;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn uRLDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn momentZatrzymaniaDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private Button button1;
        private Button button2;
    }
}

