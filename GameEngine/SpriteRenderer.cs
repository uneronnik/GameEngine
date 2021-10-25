using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;

namespace GameEngine
{
    class SpriteRenderer : Component
    {
        Image _sprite;
        public int OrderInRender { get; private set; }
        public SpriteRenderer(string spritePath, int orderInRender)
        {
            _sprite = CropAlpha(new Bitmap(Image.FromFile(spritePath)));
            OrderInRender = orderInRender;
            //_sprite = Image.FromFile(spritePath);
            
        }
        private Bitmap CropAlpha(Bitmap bitmap)
        {
            Point up = new Point();
            Point down = new Point();
            Point left = new Point();
            Point right = new Point();
            
            bool isFinished = false;
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    if (pixel.A != 0)
                    {
                        up = new Point(x, y);
                        isFinished = true;
                        break;
                    }
                }
                if (isFinished == true)
                    break;
            }
            isFinished = false;
            for (int x = 0; x < bitmap.Height; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    if (pixel.A != 0)
                    {
                        left = new Point(x, y);
                        isFinished = true;
                        break;
                    }
                }
                if (isFinished == true)
                    break;
            }
            isFinished = false;
            for (int y = bitmap.Height - 1; y > 0; y--)
            {
                for (int x = bitmap.Width - 1; x > 0; x--)
                {
                    if (bitmap.GetPixel(x, y).A != 0)
                    {
                        down = new Point(x, y);
                        isFinished = true;
                        break;
                    }
                }
                if (isFinished == true)
                    break;
            }
            isFinished = false;
            for (int x = bitmap.Width - 1; x > 0; x--)
            {
                for (int y = bitmap.Height - 1; y > 0; y--)
                {
                    if (bitmap.GetPixel(x, y).A != 0)
                    {
                        right = new Point(x, y);
                        isFinished = true;
                        break;
                    }
                }
                if (isFinished == true)
                    break;
            }
            Point leftUpCorner = new Point(left.X, up.Y);
            Point rightDownCorner = new Point(right.X, down.Y);
            Bitmap newBitmap = bitmap.Clone(new Rectangle(leftUpCorner, new Size(rightDownCorner.X - leftUpCorner.X, rightDownCorner.Y - leftUpCorner.Y)), PixelFormat.Format32bppArgb);
            return newBitmap;
        }
        private bool ContainsTransparent(Bitmap image)
        {
            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x)
                {
                    if (image.GetPixel(x, y).A != 255)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override void Update()
        {
            PointF cameraLocation = Engine.Camera.Location;
            PointF relativeLocation = new PointF(Base.Location.X - cameraLocation.X, Base.Location.Y - cameraLocation.Y);
            PointF FormLocation = new PointF(relativeLocation.X + Engine.form.Width / 2, relativeLocation.Y + Engine.form.Height / 2);

            RectangleF objectRectangle = new RectangleF(FormLocation, new SizeF(_sprite.Width * Base.Scale.X, _sprite.Height * Base.Scale.Y)); // new SizeF(Base.Size)
            RectangleF formRectangle = new RectangleF(0, 0, Engine.form.Width, Engine.form.Height);

            Bitmap spriteBitmap = new Bitmap(_sprite);
            

            if (formRectangle.Y < objectRectangle.Y + objectRectangle.Height ||
                formRectangle.Y + formRectangle.Height > objectRectangle.Y ||
                formRectangle.X + formRectangle.Width < objectRectangle.X ||
                formRectangle.X > objectRectangle.X + objectRectangle.Width)
            {
                if (!ContainsTransparent(spriteBitmap))
                    Engine.graphicsBuffer.Graphics.CompositingMode = CompositingMode.SourceCopy;

                Engine.graphicsBuffer.Graphics.DrawImage(_sprite, objectRectangle);

                Engine.graphicsBuffer.Graphics.CompositingMode = CompositingMode.SourceOver;
            }
            

            
        }
    }
}
