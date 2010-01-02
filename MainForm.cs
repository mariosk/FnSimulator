using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using gma.System.Windows;

namespace FnSimulation 
{
	class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonStart;
        private NotifyIcon notifyIcon;
        private System.ComponentModel.IContainer components;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem startToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button buttonStop;

		public MainForm()
		{
			InitializeComponent();
		}
	
		// THIS METHOD IS MAINTAINED BY THE FORM DESIGNER
		// DO NOT EDIT IT MANUALLY! YOUR CHANGES ARE LIKELY TO BE LOST
		void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStop
            // 
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Location = new System.Drawing.Point(85, 3);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
            // 
            // buttonStart
            // 
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Location = new System.Drawing.Point(4, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "FnSimulator";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(104, 76);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(384, 75);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

		}
			
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Run(new MainForm());
		}
		
		void ButtonStartClick(object sender, System.EventArgs e)
		{
			actHook.Start();
		}
		
		void ButtonStopClick(object sender, System.EventArgs e)
		{
			actHook.Stop();
		}
				
		KeyboardHook actHook;
		void MainFormLoad(object sender, System.EventArgs e)
		{
            actHook = new KeyboardHook(); // crate an instance with global hooks
			// hang on events
			actHook.OnMouseActivity+=new MouseEventHandler(MouseMoved);
			actHook.KeyDown+=new KeyEventHandler(MyKeyDown);
			actHook.KeyPress+=new KeyPressEventHandler(MyKeyPress);
			actHook.KeyUp+=new KeyEventHandler(MyKeyUp);
            AssemblyInfo ainfo = new AssemblyInfo();
            this.Text = ainfo.Title + " v" + ainfo.Version + " by " + ainfo.Copyright;
            startToolStripMenuItem_Click(sender, e);
            this.Visible = false;
            this.notifyIcon.Text = this.Text;
		}
		
		public void MouseMoved(object sender, MouseEventArgs e)
		{
			//labelMousePosition.Text=String.Format("x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta);
			if (e.Clicks>0) LogWrite("MouseButton 	- " + e.Button.ToString());
		}
		
		public void MyKeyDown(object sender, KeyEventArgs e)
		{
			LogWrite("KeyDown 	- " + e.KeyData.ToString());
		}
		
		public void MyKeyPress(object sender, KeyPressEventArgs e)
		{
			LogWrite("KeyPress 	- " + e.KeyChar);
		}
		
		public void MyKeyUp(object sender, KeyEventArgs e)
		{
			LogWrite("KeyUp 		- " + e.KeyData.ToString());
		}
		
		private void LogWrite(string txt)
		{
            //Console.WriteLine(txt);
			//textBox.AppendText(txt + Environment.NewLine);
			//textBox.SelectionStart = textBox.Text.Length;
		}

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                Hide();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            //Show();
            //WindowState = FormWindowState.Normal;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.stopToolStripMenuItem_Click(sender, e);
            Application.Exit();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.stopToolStripMenuItem.Enabled = false;
            this.startToolStripMenuItem.Enabled = true;
            actHook.Stop();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.stopToolStripMenuItem.Enabled = true;
            this.startToolStripMenuItem.Enabled = false;
            actHook.Start();
        }

	}			
}
