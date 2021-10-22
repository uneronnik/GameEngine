using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameEngine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            Width = 1920;
            Height = 1080;
            Engine.graphics = Graphics.FromImage(new Bitmap(Width, Height));
        }
        void StartGameCycle()
        {

            while (true)
            {

                Engine.graphics.Clear(Color.White);
                Engine.Update();
                BackgroundImage = new Bitmap(Width, Height, Engine.graphics);
                this.Refresh();
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
    }
}
