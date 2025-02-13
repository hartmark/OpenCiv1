﻿namespace OpenCiv1
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.cmdPause = new System.Windows.Forms.ToolStripButton();
			this.cmdRun = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.lblScreens = new System.Windows.Forms.ToolStripLabel();
			this.tsScreens = new System.Windows.Forms.ToolStripSplitButton();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tmrRefresh
			// 
			this.tmrRefresh.Enabled = true;
			this.tmrRefresh.Interval = 50;
			this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
			// 
			// tsMain
			// 
			this.tsMain.BackColor = System.Drawing.SystemColors.Control;
			this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdPause,
            this.cmdRun,
            this.toolStripSeparator1,
            this.lblScreens,
            this.tsScreens});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.tsMain.Size = new System.Drawing.Size(580, 27);
			this.tsMain.TabIndex = 0;
			this.tsMain.Text = "toolStrip1";
			// 
			// cmdPause
			// 
			this.cmdPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdPause.Enabled = false;
			this.cmdPause.Image = ((System.Drawing.Image)(resources.GetObject("cmdPause.Image")));
			this.cmdPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdPause.Name = "cmdPause";
			this.cmdPause.Size = new System.Drawing.Size(24, 24);
			this.cmdPause.Text = "Pause";
			this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click);
			// 
			// cmdRun
			// 
			this.cmdRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdRun.Enabled = false;
			this.cmdRun.Image = ((System.Drawing.Image)(resources.GetObject("cmdRun.Image")));
			this.cmdRun.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdRun.Name = "cmdRun";
			this.cmdRun.Size = new System.Drawing.Size(24, 24);
			this.cmdRun.Text = "Run";
			this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
			// 
			// lblScreens
			// 
			this.lblScreens.BackColor = System.Drawing.SystemColors.Control;
			this.lblScreens.Name = "lblScreens";
			this.lblScreens.Size = new System.Drawing.Size(47, 24);
			this.lblScreens.Text = "Screens";
			// 
			// tsScreens
			// 
			this.tsScreens.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsScreens.Enabled = false;
			this.tsScreens.Image = ((System.Drawing.Image)(resources.GetObject("tsScreens.Image")));
			this.tsScreens.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsScreens.Name = "tsScreens";
			this.tsScreens.Size = new System.Drawing.Size(36, 24);
			this.tsScreens.Text = "Plane list";
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(580, 340);
			this.Controls.Add(this.tsMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.Text = "OpenCiv1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer tmrRefresh;
		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ToolStripButton cmdPause;
		private System.Windows.Forms.ToolStripButton cmdRun;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel lblScreens;
		private System.Windows.Forms.ToolStripSplitButton tsScreens;
	}
}