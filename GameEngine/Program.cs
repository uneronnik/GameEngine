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





            for (int i = 0; i < 1; i++)
            {
                GameObject spriteTest = new GameObject($"spriteTest{i}");
                spriteTest.Location = new Point(i * 10, 0);
                spriteTest.Size = new Point(900, 900);
                spriteTest.AddComponent(new SpriteRenderer("aqua staff.png"));
                Engine.CreateObject(spriteTest);
            }

            
            Engine.Camera.Location = new Point(-50, -100);
            Engine.Camera.AddComponent(new CameraMover(10));
            Application.Run(new Form1());



        }
        

    }
}
