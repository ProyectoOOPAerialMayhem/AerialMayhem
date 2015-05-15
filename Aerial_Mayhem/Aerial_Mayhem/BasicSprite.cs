using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Aerial_Mayhem
{
    class BasicSprite : BasicCollision
    {
        //atributos
        Texture2D image;
        Rectangle pos;
        Rectangle inc;
        bool automove;

        // metodo de inicializacion
        public void Init(ContentManager Content, String name)
        {
            image = Content.Load<Texture2D>(name);
            pos = new Rectangle(0, 0, image.Width, image.Height);
        }
        public void SetIncrement(Rectangle incIn)
        {
            inc = incIn;

        }
        public void SetAutomove(bool moveIn)
        {

            automove = moveIn;

        }

        public Rectangle GetRectangle()
        {
            return pos;
        }

        public void Update(GameTime gameTime)
        {

            if (automove)
            {
                pos.X += inc.X;
                pos.Y += inc.Y;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(image, pos, Color.White);
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(image, pos, color);
            spriteBatch.End();
           
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 posIn)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(image, posIn, Color.White);
            spriteBatch.End();
        }

        // Get/Set the current position of the character, as a Rectangle
        public Rectangle Pos
        {
            set
            {
                pos = value;
            }
            get
            {
                return pos;
            }
        }

        // -------------------------------------------------------------------------------------------
        // Basic Collision methods inherited from INTERFACE
        // Method to check intersection of this (eventual) object with a rectangle
        public override bool Intersects(Rectangle colIn)
        {
            return this.pos.Intersects(colIn);
        }

        // Basic Collision methods inherited from INTERFACE
        // Method for this (eventual) object to provide a rectangle for collision
        public override Rectangle GetCollisionRect()
        {
            return pos;
        }
        // -------------------------------------------------------------------------------------------

    }
}
