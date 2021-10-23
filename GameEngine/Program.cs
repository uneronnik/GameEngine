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




            GameObject spriteTest = new GameObject($"spriteTest");
            spriteTest.Location = new Point(0, 0);
            spriteTest.Size = new Point(900, 900);
            spriteTest.AddComponent(new SpriteRenderer("aqua staff.png"));
            spriteTest.AddComponent(new CameraMover(10));
            Engine.CreateObject(spriteTest);
            
            for (int i = 0; i < 5; i++)
            {
                GameObject spriteTest2 = new GameObject($"spriteTest{i}");
                spriteTest2.Location = new Point(i * 900 - 300, 0);
                spriteTest2.Size = new Point(900, 900);
                spriteTest2.AddComponent(new SpriteRenderer("aqua staff.png"));
                Engine.CreateObject(spriteTest2);
            }

            
            Engine.Camera.Location = new Point(0, 0);
            Application.Run(new Form1());



        }
        

    }
}
