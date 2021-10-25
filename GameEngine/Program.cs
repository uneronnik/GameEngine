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
            spriteTest.Location = new Point(-300, -300);
            spriteTest.Scale = new Point(1000, 1000);
            spriteTest.AddComponent(new SpriteRenderer("aqua staff.png", 0));
            spriteTest.AddComponent(new CameraMover(5));
            //Engine.CreateObject(spriteTest);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    GameObject spriteTest2 = new GameObject($"spriteTest{i}{j}");
                    spriteTest2.Location = new Point(j * 100, i * 200); ;
                    spriteTest2.Scale = new Point(20, 20);
                    spriteTest2.AddComponent(new SpriteRenderer("aqua staff.png", 3 - i));
                    Engine.CreateObject(spriteTest2);
                }
            }
            
            Engine.Camera.Location = new Point(0, 0);
            Engine.Camera.AddComponent(new CameraMover(500));

            Application.Run(new Form1());



        }
        

    }
}
