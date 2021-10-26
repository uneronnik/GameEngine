using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GameEngine
{
    
    class Input
    {
        public static class Pressed
        {
            static public bool W;
            static public bool A;
            static public bool S;
            static public bool D;
            static public bool Shift;
            static public bool Ctrl;
            static public bool Space;
        }
        static public void KeyDown(KeyEventArgs key)
        {
            if (key.KeyCode == Keys.Shift)
                Pressed.Shift = true;
            if (key.KeyCode == Keys.Control)
                Pressed.Ctrl = true;
            if (key.KeyCode == Keys.Space)
                Pressed.Space = true;
            if (key.KeyCode == Keys.W)
                Pressed.W = true;
            if (key.KeyCode == Keys.A)
                Pressed.A = true;
            if (key.KeyCode == Keys.S)
                Pressed.S = true;
            if (key.KeyCode == Keys.D)
                Pressed.D = true;
        }

        static public void KeyUp(KeyEventArgs key)
        {
            if (key.KeyCode == Keys.Shift)
                Pressed.Shift = false;
            if (key.KeyCode == Keys.Control)
                Pressed.Ctrl = false;
            if (key.KeyCode == Keys.Space)
                Pressed.Space = false;
            if (key.KeyCode == Keys.W)
                Pressed.W = false;
            if (key.KeyCode == Keys.A)
                Pressed.A = false;
            if (key.KeyCode == Keys.S)
                Pressed.S = false;
            if (key.KeyCode == Keys.D)
                Pressed.D = false;

        }
    }
}
