using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aerial_Mayhem.DrawUtils;


namespace Aerial_Mayhem

{
    
    class TestChraracter //TODO CollidableEntity: ICollidable
    {
        /// <summary>
        /// Testing AnimatedSprite class and SpriteSheet class
        /// It's easier to load an animation with spritesheet class
        /// </summary>
        AnimatedSprite animation;
        Rectangle pos;
        public TestChraracter(Rectangle pos)
        {
            this.pos = pos;
        }
        public void LoadContent(ContentManager Content ){
            SpriteSheet sp = new SpriteSheet("bs",4,2,8);
            animation = new AnimatedSprite(Content,pos,sp,0.7f);
        }
        public void Update(GameTime gameTime)
        {
            //testing wether its worth it to change origin to center of image
            //not sure...
            animation.Rotate(0.005f);
            animation.Update(gameTime);
            pos.X++;
            animation.Pos = pos;
        }
        public void Draw(SpriteBatch sp){
            animation.Draw(sp);
        }



    }
}
