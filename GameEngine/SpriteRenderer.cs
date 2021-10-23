using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace GameEngine
{
    class SpriteRenderer : Component
    {
        Image _sprite;
        public SpriteRenderer(string spritePath)
        {
            _sprite = Image.FromFile(spritePath);
            
        }
        public override void Update()
        {
            PointF cameraLocation = Engine.Camera.Location;
            PointF relativeLocation = new PointF(Base.Location.X - cameraLocation.X, Base.Location.Y - cameraLocation.Y);
            PointF FormLocation = new PointF(relativeLocation.X + Engine.form.Width / 2, relativeLocation.Y + Engine.form.Height / 2);
            if (!Image.IsAlphaPixelFormat(_sprite.PixelFormat))
                Engine.graphics.CompositingMode = CompositingMode.SourceCopy;
            else
                Engine.graphics.CompositingMode = CompositingMode.SourceOver;
            Engine.graphics.DrawImage(_sprite, new RectangleF(FormLocation, new SizeF(Base.Size)));
        }
    }
}
