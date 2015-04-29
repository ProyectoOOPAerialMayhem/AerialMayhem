using System;
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

namespace Aerial_Mayhem
{
    public class BasicSprite
    {
        protected Texture2D image;
        protected Color color = Color.White;
        protected Rectangle pos;
        protected float radian = 0;

        //normal constructor sets the sprite pisition using the image height and width as default
        public BasicSprite(ContentManager Content, int x, int y, string image)
        {
            this.image = Content.Load<Texture2D>(image);
            this.pos = new Rectangle(x, y, this.image.Width, this.image.Height);


        }
        public BasicSprite(ContentManager Content, int x, int y, int width, int height, string image)
        {
            this.image = Content.Load<Texture2D>(image);
            this.pos = new Rectangle(x, y, width, height);
        }
        //overloaded constructor for finer control at creation time
        public BasicSprite(ContentManager Content, int x, int y, int height, int width, float radian, Color color, string image)
        {
            this.image = Content.Load<Texture2D>(image);
            this.color = color;
            this.radian = radian;
            this.pos = new Rectangle(x, y, width, height);
        }

        public void Rotate(float radIncr)
        {

            radian += radIncr;

        }
        //updates all the states of the basicsprite

        public virtual void Update(GameTime gameTime)
        {



        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // draws the sprite to screen using the spriteBatch.Draw() method and it's arguments 
            //see https://msdn.microsoft.com/en-us/library/ff433992.aspx for more info

                spriteBatch.Draw(image, pos, null, color, radian, new Vector2(image.Width / 2, image.Height / 2), new SpriteEffects(), 0f);
        }
       
       
    }
}

