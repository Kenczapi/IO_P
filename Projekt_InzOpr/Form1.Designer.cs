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
            this.SelectingFileDialog = new System.Windows.Forms.OpenFileDialog();

            this.panelSterowanie = new System.Windows.Forms.Panel();



            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.lATime = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonZamknij = new System.Windows.Forms.Button();
            this.buttonOtworz = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.panelSterowanie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // Player
            // 
            this.Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Player.Enabled = true;
            this.Player.Location = new System.Drawing.Point(0, 0);
            this.Player.Name = "Player";
            this.Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player.OcxState")));
            this.Player.Size = new System.Drawing.Size(1264, 681);
            this.Player.TabIndex = 0;
            this.Player.MouseMoveEvent += new AxWMPLib._WMPOCXEvents_MouseMoveEventHandler(this.Player_MouseMoveEvent);
            // 
            // SelectingFileDialog
            // 
            this.SelectingFileDialog.FileName = "openFileDialog1";
            // 

            // panelSterowanie
            // 
            this.panelSterowanie.AutoSize = true;
            this.panelSterowanie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSterowanie.BackColor = System.Drawing.SystemColors.Control;
            this.panelSterowanie.Controls.Add(this.trackBar2);
            this.panelSterowanie.Controls.Add(this.trackBar1);
            this.panelSterowanie.Controls.Add(this.label1);
            this.panelSterowanie.Controls.Add(this.lTime);
            this.panelSterowanie.Controls.Add(this.lATime);
            this.panelSterowanie.Controls.Add(this.button4);
            this.panelSterowanie.Controls.Add(this.buttonZamknij);
            this.panelSterowanie.Controls.Add(this.buttonOtworz);
            this.panelSterowanie.Controls.Add(this.buttonPlay);
            this.panelSterowanie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSterowanie.Location = new System.Drawing.Point(0, 602);
            this.panelSterowanie.Name = "panelSterowanie";
            this.panelSterowanie.Size = new System.Drawing.Size(1264, 79);
            this.panelSterowanie.TabIndex = 1;
            this.panelSterowanie.Visible = false;

          
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(98, 28);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(881, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.MouseCaptureChanged += new System.EventHandler(this.trackBar1_MouseCaptureChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1036, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "/";
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(1054, 28);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(35, 13);
            this.lTime.TabIndex = 7;
            this.lTime.Text = "label1";
            // 
            // lATime
            // 
            this.lATime.AutoSize = true;
            this.lATime.Location = new System.Drawing.Point(985, 28);
            this.lATime.Name = "lATime";
            this.lATime.Size = new System.Drawing.Size(35, 13);
            this.lATime.TabIndex = 6;
            this.lATime.Text = "label1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 49);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Poprzedni";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonZamknij
            // 
            this.buttonZamknij.Location = new System.Drawing.Point(1161, 49);
            this.buttonZamknij.Name = "buttonZamknij";
            this.buttonZamknij.Size = new System.Drawing.Size(75, 23);
            this.buttonZamknij.TabIndex = 2;
            this.buttonZamknij.Text = "Zamknij";
            this.buttonZamknij.UseVisualStyleBackColor = true;
            this.buttonZamknij.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonOtworz
            // 
            this.buttonOtworz.Location = new System.Drawing.Point(1162, 4);
            this.buttonOtworz.Name = "buttonOtworz";
            this.buttonOtworz.Size = new System.Drawing.Size(75, 23);
            this.buttonOtworz.TabIndex = 1;
            this.buttonOtworz.Text = "Otwórz";
            this.buttonOtworz.UseVisualStyleBackColor = true;
            this.buttonOtworz.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(3, 4);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Pause";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(1111, 4);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 72);
            this.trackBar2.TabIndex = 10;
            this.trackBar2.MouseCaptureChanged += new System.EventHandler(this.trackBar2_MouseCaptureChanged);
            // 
            // Okno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelSterowanie);
            this.Controls.Add(this.Player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Okno";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.panelSterowanie.ResumeLayout(false);
            this.panelSterowanie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog SelectingFileDialog;
        private System.Windows.Forms.Panel panelSterowanie;
        private System.Windows.Forms.Button buttonZamknij;
        private System.Windows.Forms.Button buttonOtworz;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private TrackBar trackBar1;
        private Label label1;
        private Label lTime;
        private Label lATime;
        private Timer timer1;
        private AxWMPLib.AxWindowsMediaPlayer Player;
        private TrackBar trackBar2;
    }
}

