using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GameEngine
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            
            Width = 1920;
            Height = 1080;
            Engine.form = this;
            
            
        }
        async void StartGameCycle()
        {
            while (true)
            {
                
                using (Bitmap bitmap = new Bitmap(Width, Height))
                {
                    Engine.graphics = Graphics.FromImage(bitmap);
                    Engine.graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    Engine.Update();
                    if (pictureBox1.Image != bitmap)
                    {
                        pictureBox1.Image = bitmap;
                        pictureBox1.Refresh();
                    }

                }
                
                await Task.Delay(1);  
            }
            
        }
        
        private void ChangeImage(Bitmap bitmap)
        {
            
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
    }
}
