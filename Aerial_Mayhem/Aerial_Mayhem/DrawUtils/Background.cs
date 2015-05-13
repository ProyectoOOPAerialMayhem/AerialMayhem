using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.DrawUtils
{
    
    public class Background :SimpleSprite,Aerial_Mayhem.IDrawable
    {
        public Background(ContentManager Content, int x, int y, string image):base(Content,x,y,image)
        {

        }
        public Background(ContentManager Content, Rectangle pos, float radian, Color color, string image):
            base(Content,pos,radian,color,image)
        {
            
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch sp)
        {
            base.Draw(sp);
        }
    }
}
