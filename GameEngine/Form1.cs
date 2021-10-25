using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace GameEngine
{
    public partial class Form1 : Form
    {
        private Stopwatch _deltaTimeStopwatch = new Stopwatch();
        public Form1()
        {
            InitializeComponent();

            
            Width = 1980;
            Height = 1080;
            Engine.form = this;
            //SetStyle(ControlStyles.OptimizedDoubleBuffer |
            //    ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            UpdateStyles();
            GraphicsChanged += UpdateGraphics;
            using (Graphics graphics = pictureBox1.CreateGraphics())
            {

                Engine.graphicsBuffer = BufferedGraphicsManager.Current.Allocate(graphics, new Rectangle(0, 0, Width, Height));
            }
            _deltaTimeStopwatch.Start();
        }
        delegate void GraphicsChangingHandler();
        event GraphicsChangingHandler GraphicsChanged;
        async void StartGameCycle()
        {
            while (true)
            {
                DateTime startTime = DateTime.Now;
                
                Engine.graphicsBuffer.Graphics.Clear(Color.White);
                Engine.graphicsBuffer.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                Engine.graphicsBuffer.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
                Engine.graphicsBuffer.Graphics.SmoothingMode = SmoothingMode.None;
                
                    
                
                pictureBox1.Show();


                _deltaTimeStopwatch.Stop();
                Time.deltaTime = (float)_deltaTimeStopwatch.Elapsed.TotalSeconds;
                _deltaTimeStopwatch.Restart();
                await Task.Run(() =>
                {
                    
                    
                        Engine.Update();

                    
                });
                

                GraphicsChanged?.Invoke();
                DateTime endTime = DateTime.Now;
                label1.Text = ((int)(new TimeSpan(0, 0, 0, 1) / (endTime - startTime))).ToString();
                
                
                if (GC.GetTotalMemory(true) == 7340032000)
                {
                    Task task = new Task(() =>
                    {
                        GC.Collect();
                    });
                    task.Start();
                }
            }
            
        }
        private void UpdateGraphics()
        {
            pictureBox1.Invalidate();
            pictureBox1.Update();
        }
        
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            StartGameCycle();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.KeyDown(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.KeyUp(e);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            lock(Engine.graphicsBuffer)
                Engine.graphicsBuffer.Render(e.Graphics);
        }
    }
}
