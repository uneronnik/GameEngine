using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine
{
    class Program
    {
        static Form1 form;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            

            
            

            GameObject spriteTest = new GameObject("spriteTest");
            spriteTest.Size = new Point(1920, 1080);
            spriteTest.AddComponent(new SpriteRenderer("png-clipart-dot-dot.png"));
            Engine.CreateObject(spriteTest);

            Application.Run(new Form1());



        }
        

    }
}
