﻿using System;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Aerial_Mayhem.DrawUtils
{
    public  class SimpleSprite :AbstractSprite
    {
        //normal constructor sets the sprite position using the image height and width as default
        public SimpleSprite(ContentManager Content, int x, int y, string image)
        {
            this.image = Content.Load<Texture2D>(image);
            this.pos = new Rectangle(x, y, this.image.Width, this.image.Height);
        }
        public SimpleSprite(ContentManager Content,Rectangle pos, string image)
        {
            this.image = Content.Load<Texture2D>(image);
            this.pos = pos;
        }
        //overloaded constructor for finer control at creation time
        public SimpleSprite(ContentManager Content, Rectangle pos, float radian, Color color, string image)
        {
            this.image = Content.Load<Texture2D>(image);
            this.color = color;
            this.radian = radian;
            this.pos = pos;
        }

        //updates all the states of the basicsprite

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // draws the sprite to screen using the spriteBatch.Draw() method and it's arguments 
            //see https://msdn.microsoft.com/en-us/library/ff433992.aspx for more info

                spriteBatch.Draw(image, pos, null, color, radian, new Vector2(pos.Width / 2, pos.Height / 2), new SpriteEffects(), 0f);
        }

       
    }
}

