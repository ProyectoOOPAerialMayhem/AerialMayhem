using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.DrawUtils
{
    public abstract class AbstractSprite :IDrawable
    {
        protected Texture2D image;
        protected Color color = Color.White;
        protected Rectangle pos;
        protected float radian = 0;
        public Rectangle Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public float Radian
        {
            get { return radian; }
            set { radian = value; }
        }

        public void Rotate(float radIncr)
        {

            radian += radIncr;

        }
        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch sp);
    }
}
