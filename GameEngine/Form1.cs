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

namespace GameEngine
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            
            Width = 1980;
            Height = 1080;
            Engine.form = this;
            
            
        }
        async void StartGameCycle()
        {
            while (true)
            {

                using (Bitmap bitmap = new Bitmap(Width, Height))
                {

                    using (Graphics graphics = CreateGraphics())
                    {
                        Engine.graphicsBuffer = BufferedGraphicsManager.Current.Allocate(graphics, new Rectangle(0, 0, Width, Height));
                        Engine.graphicsBuffer.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                        Engine.graphicsBuffer.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    }
                    await Task.Run(() =>
                    {
                        Engine.Update();
                    });

                    pictureBox1.Refresh();
                }
                
            }
            
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
            Engine.graphicsBuffer.Render(e.Graphics);
        }
    }
}
