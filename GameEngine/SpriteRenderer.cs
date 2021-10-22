using System;
using System.Collections.Generic;
using System.Drawing;
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
            Engine.graphics.DrawImage(_sprite, Base.Location);
        }
    }
}
