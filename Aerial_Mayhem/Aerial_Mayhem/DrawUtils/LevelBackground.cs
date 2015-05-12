using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.DrawUtils
{
    public class MovingBackground
    {
        //TODO rename class to BackgroudnLoop inherit Background(state texture) virtual method Draw, virtual method update
        SimpleSprite texture;
        public int Speed
        {
            get;
            set;
        }
        public MovingBackground(ContentManager Content,Rectangle pos, int speed,string filepath )
        {
            texture = new SimpleSprite(Content, pos, filepath);
            Speed = speed;

        }
        public void Update(GameTime gameTime)
        {
            
            
        }
        public void Draw(GameTime gameTime)
        {

        }

         


    }
}
