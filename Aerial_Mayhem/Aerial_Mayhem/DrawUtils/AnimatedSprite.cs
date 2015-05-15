using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Aerial_Mayhem.DrawUtils
{
 
    public class AnimatedSprite :AbstractSprite
    {
        // Attributes
       protected Rectangle frame;
       protected Rectangle test; 
       protected SpriteSheet sp;
       protected int currentFrame;
       protected int start;
       protected int end;
       protected float timePerFrame;
       protected float timer;
       bool play=true;
       bool loop;



        // Methods

        public  AnimatedSprite(ContentManager Content, Rectangle position,SpriteSheet sp, float timeperFrame)
        {
            this.sp = sp;
            image = Content.Load<Texture2D>(sp.FilePath);
            pos = position;
            //new frame starting at initial position dependent of hrizontal frames and vertical ones 
            frame = new Rectangle(0,0,image.Width/sp.HorizontalFrames,image.Height/sp.VerticalFrames);
            test = frame;
            currentFrame = 0; 
            this.timePerFrame = timeperFrame; 
            timer = 0.0f;
        }
     
        public void Stop(int frame)
        {
            play = false;
            currentFrame = frame;
            
        }

        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Update my animation
            // Update my currentFrame pointer
            if (timer >= timePerFrame)
            {
                if (play)
                    currentFrame = (currentFrame + 1) % sp.FrameCount;
                timer = timer - timePerFrame;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            frame.Y = frame.Height * (currentFrame / sp.HorizontalFrames % sp.VerticalFrames);
            frame.X = (currentFrame % sp.HorizontalFrames) * frame.Width;
            //this is to handle the sprite from the center rather than the upper-left corner
            //might be uselful? it might not?
            Vector2 origin = new Vector2(test.Center.X,test.Center.Y);
            spriteBatch.Draw(image, pos, frame, Color.White, radian, origin, new SpriteEffects(), 0f);

        }


    }
}