using System;
using System.Windows.Forms;
using gma.System.Windows;

namespace FnSimulation 
{
	class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;

		public MainForm()
		{
			InitializeComponent();
		}
	
		// THIS METHOD IS MAINTAINED BY THE FORM DESIGNER
		// DO NOT EDIT IT MANUALLY! YOUR CHANGES ARE LIKELY TO BE LOST
		void InitializeComponent() {
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
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
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(165, 31);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "mariosk - Fn button";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainFormLoad);
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

	}			
}
