using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.DrawUtils
{
    public class BackgroundLoop :Aerial_Mayhem.IDrawable

    {
        //TODO rename class to BackgroudnLoop inherit Background(state texture) virtual method Draw, virtual method update
        Background bgd;
        Rectangle pos1;
        Rectangle pos2;
        private int centerX;
        public int Speed
        {
            get;
            set;
        }
        public BackgroundLoop(ContentManager Content,int x, int y, int speed,string filepath )
        {
            bgd = new Background(Content,x,y,filepath);
            pos1 = bgd.Pos;
            centerX = pos1.Width / 2;
            pos2 = new Rectangle(pos1.X+pos1.Width,pos1.Y,pos1.Width,pos1.Height);
            Speed = speed;

        }
        public virtual void Update(GameTime gameTime)
        {
            if (pos1.X <= -centerX)
                pos1.X = centerX * 3 + (centerX + pos1.X);
            if (pos2.X <= -centerX)
                pos2.X = centerX * 3 + (centerX + pos2.X); 
            pos1.X-=Speed;
            pos2.X-=Speed;
            
        }

        public virtual void Draw(SpriteBatch sp)
        {
            bgd.Pos=pos1;
            bgd.Draw(sp);
            bgd.Pos=pos2;
            bgd.Draw(sp);
        }

         


    }
}
