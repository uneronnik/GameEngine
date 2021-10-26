using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    class Mover : Component
    {
        private int _speed;
        public Mover(int speed)
        {
            _speed = speed;
        }
        public override void Update()
        {
            
            if (Input.Pressed.D)
                Base.Location = new System.Drawing.PointF(Base.Location.X + 1 * _speed * Time.deltaTime, Base.Location.Y);
            if (Input.Pressed.A)
                Base.Location = new System.Drawing.PointF(Base.Location.X - 1 * _speed * Time.deltaTime, Base.Location.Y);
            if (Input.Pressed.W)
                Base.Location = new System.Drawing.PointF(Base.Location.X, Base.Location.Y - 1 * _speed * Time.deltaTime);
            if (Input.Pressed.S)
                Base.Location = new System.Drawing.PointF(Base.Location.X, Base.Location.Y + 1 * _speed * Time.deltaTime);
        }
    }
}
