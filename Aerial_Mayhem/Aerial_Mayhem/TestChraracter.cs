using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aerial_Mayhem.DrawUtils;
using Microsoft.Xna.Framework.Input;


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
        public void LoadContent(ContentManager Content )
        {
            //SpriteSheet sp = new SpriteSheet("TestNewSpriteScript",9,10,83);
            SpriteSheet sp = new SpriteSheet("disparo1fix2", 6, 8, 48); //It works
            //animation constructors work really good
            animation = new AnimatedSprite(Content, pos, sp, 0.05f);
            //animation = new AnimatedSprite(Content, pos, sp, 0.05f, false);
            //animation = new AnimatedSprite(Content, pos, sp, 0.05f,0,42,false);
        }
        public void Update(GameTime gameTime)
        {
            //testing wether its worth it to change origin to center of image
            //not sure...
            //animation.Rotate(0.005f);
            animation.Update(gameTime);
            animation.Pos = pos;
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                animation.Reverse = !animation.Reverse;
        }
        public void Draw(SpriteBatch sp){
            animation.Draw(sp);
        }



    }
}
