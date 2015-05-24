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

    public class AnimatedSprite : AbstractSprite
    {
        // Attributes
       protected Rectangle frame;
       protected Rectangle test; 
       protected SpriteSheet sp;
       protected int currentFrame;
       protected float timePerFrame;
       protected float timer;
       public bool Play { get; set; }
       public bool Loop { get; set; }
       public bool Reverse { get; set; }
       public int Start { get; set; }
       public int End { get; set; }

        // Methods

        public  AnimatedSprite(ContentManager Content, Rectangle position,SpriteSheet sp, float timeperFrame)
        {
            this.sp = sp;
            image = Content.Load<Texture2D>(sp.FilePath);
            pos = position;
            Play = true;
            //new frame starting at initial position dependent of hrizontal frames and vertical ones 
            frame = new Rectangle(0,0,image.Width/sp.HorizontalFrames,image.Height/sp.VerticalFrames);
            test = frame;
            Loop = true;
            Start = 0;
            Play = true;
            End = sp.FrameCount;
            //TODO change Loop
            currentFrame = Start; 
            this.timePerFrame = timeperFrame; 
            timer = 0.0f;
        }
        public AnimatedSprite(ContentManager Content, Rectangle position, SpriteSheet sp, float timeperFrame,bool loop)
        {
            this.sp = sp;
            Play = true;
            image = Content.Load<Texture2D>(sp.FilePath);
            pos = position;
            //new frame starting at initial position dependent of hrizontal frames and vertical ones 
            frame = new Rectangle(0, 0, image.Width / sp.HorizontalFrames, image.Height / sp.VerticalFrames);
            test = frame;
            Start = 0;
            End = sp.FrameCount;
            //TODO change Loop
            currentFrame = Start;
            this.timePerFrame = timeperFrame;
            timer = 0.0f;
            this.Loop = loop;
        }
        public AnimatedSprite(ContentManager Content, Rectangle position, SpriteSheet sp, float timeperFrame,int startFrame,int endFrame)
        {
            this.sp = sp;
            image = Content.Load<Texture2D>(sp.FilePath);
            pos = position;
            Play = true;
            //new frame starting at initial position dependent of hrizontal frames and vertical ones 
            frame = new Rectangle(0, 0, image.Width / sp.HorizontalFrames, image.Height / sp.VerticalFrames);
            test = frame;
            Loop = true;
            Start = startFrame;
            End = endFrame;
            //TODO change Loop
            currentFrame = Start;
            this.timePerFrame = timeperFrame;
            timer = 0.0f;
        }
        public AnimatedSprite(ContentManager Content, Rectangle position, SpriteSheet sp, float timeperFrame, int startFrame, int endFrame,bool loop)
        {
            this.sp = sp;
            image = Content.Load<Texture2D>(sp.FilePath);
            pos = position;
            Play = true;
            //new frame starting at initial position dependent of hrizontal frames and vertical ones 
            frame = new Rectangle(0, 0, image.Width / sp.HorizontalFrames, image.Height / sp.VerticalFrames);
            test = frame;
            Start = startFrame;
            End = endFrame;
            //TODO change Loop
            currentFrame = Start;
            this.timePerFrame = timeperFrame;
            timer = 0.0f;
            this.Loop = loop;
        }

        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            // Update my animation
            // Update my currentFrame pointer
            if (timer >= timePerFrame)
            {
                if (Play)
                {
                    if (Reverse)
                    {
                        currentFrame = currentFrame - 1;
                        if (currentFrame < Start)
                            currentFrame = End;
                    }
                    else
                    {
                        currentFrame = currentFrame + 1;
                        if (currentFrame > End)
                            currentFrame = Start;
                    }
                       
                    if (!Loop)
                    {
                        if (Reverse)
                            Play = currentFrame > Start;
                        else
                            Play = currentFrame < End;
                    }
                }   
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