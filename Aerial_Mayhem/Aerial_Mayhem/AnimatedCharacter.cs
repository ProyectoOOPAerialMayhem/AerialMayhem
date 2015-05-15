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
    enum SideDirection { RUN_LEFT, RUN_RIGHT, RUN_UP, RUN_DOWN, STAND_LEFT, STAND_RIGHT, STAND_UP, STAND_DOWN };

    class AnimatedCharacter : BasicCollision
    {
        // Attributes
        // -------------------------------------------
        BasicAnimatedSprite moveLeft, moveRight, moveUp, moveDown;
        BasicSprite standLeft, standRight, standUp, standDown;

        // Attributes
        Keys runLeft, runRight, runUp, runDown;
        SideDirection direction;

        Vector2 inc;

        //SpriteFont font;

        // Methods
        // -------------------------------------------
        public AnimatedCharacter()
        {
            moveDown = new BasicAnimatedSprite();
            moveRight = new BasicAnimatedSprite();
            moveLeft = new BasicAnimatedSprite();
            moveUp = new BasicAnimatedSprite();

            standLeft = new BasicSprite();
            standRight = new BasicSprite();
            standDown = new BasicSprite();
            standUp = new BasicSprite();
            
            // default increment
            inc = new Vector2(2, 2);
        }

        //public void LoadContent(ContentManager Content, string fontname)
        //{
        //    font = Content.Load<SpriteFont>("SpriteFont1.xnb");
        //}

        public void SetMoveLeft(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame, Keys run)
        {
            //moveLeft = new BasicSpriteAnimated();
            moveLeft.InitMultipleFiles(Content, nameDir, nameFile, frameCount, timePerFrame);
            runLeft = run;
        }

        public void SetMoveRight(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame, Keys run)
        {
            //moveRight = new BasicSpriteAnimated();
            moveRight.InitMultipleFiles(Content, nameDir, nameFile, frameCount, timePerFrame);
            runRight = run;
        }

        public void SetStandLeft(ContentManager Content, String name)
        {
            //standLeft = new BasicSprite();
            standLeft.Init(Content, name);
        }

        public void SetStandRight(ContentManager Content, String name)
        {
            //standRight = new BasicSprite();
            standRight.Init(Content, name);
        }

        public void SetMoveSprites(SideDirection direction, ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame, Keys run)
        {
            switch (direction)
            {
                // Animated Sprites
                // NOTE: Does not check if something was loaded or not
                case (SideDirection.RUN_DOWN):
                    {
                        //moveDown = new BasicSpriteAnimated();
                        moveDown.InitMultipleFiles(Content, nameDir, nameFile, frameCount, timePerFrame);
                        runDown = run;
                        break;
                    }
                case (SideDirection.RUN_LEFT):
                    {
                        //moveLeft = new BasicSpriteAnimated();
                        moveLeft.InitMultipleFiles(Content, nameDir, nameFile, frameCount, timePerFrame);
                        runLeft = run;
                        break;
                    }
                case (SideDirection.RUN_RIGHT):
                    {
                        //moveRight = new BasicSpriteAnimated();
                        moveRight.InitMultipleFiles(Content, nameDir, nameFile, frameCount, timePerFrame);
                        runRight = run;
                        break;
                    }
                case (SideDirection.RUN_UP):
                    {
                        //moveUp = new BasicSpriteAnimated();
                        moveUp.InitMultipleFiles(Content, nameDir, nameFile, frameCount, timePerFrame);
                        runUp = run;
                        break;
                    }
                default:
                    break;
            }
        }

        public void SetStandSprites(SideDirection direction, ContentManager Content, String name)
        {
            switch (direction)
            {
                // Simple Sprites
                // NOTE: Does not check if something was loaded or not
                case (SideDirection.STAND_DOWN):
                    {
                        //standDown = new BasicSprite();
                        standDown.Init(Content, name);
                        break;
                    }
                case (SideDirection.STAND_LEFT):
                    {
                        //standLeft = new BasicSprite();
                        standLeft.Init(Content, name);
                        break;
                    }
                case (SideDirection.STAND_RIGHT):
                    {
                        //standRight = new BasicSprite();
                        standRight.Init(Content, name);
                        break;
                    }
                case (SideDirection.STAND_UP):
                    {
                        //standUp = new BasicSprite();
                        standUp.Init(Content, name);
                        break;
                    }
                default:
                    break;
            }
        }

        // Get/Set the current position of the character, as a Rectangle
        public Vector2 Pos
        {
            set
            {
                Rectangle temp = standRight.Pos;

                temp.X = (int)value.X;
                temp.Y = (int)value.Y;

                // Update the position of ALL animations
                standLeft.Pos = temp;
                standRight.Pos = temp;
                standUp.Pos = temp;
                standDown.Pos = temp;

                moveLeft.Pos = temp;
                moveRight.Pos = temp;
                moveDown.Pos = temp;
                moveUp.Pos = temp;
            }
            get
            {
                // return the postion of the character
                // Since we are updating them all (see set above), we can return only one of them
                Vector2 temp = new Vector2(standRight.Pos.X, standRight.Pos.Y);

                return temp;
            }

        }

        public void SetInc(Vector2 incIn)
        {
            inc = incIn;
        }

        public void ValidateAndSetPos(Vector2 pos)
        {
            // First check that we actually have a map
            // TO DO  - In next solution file
            //if ()
            //{
            //  // TO DO - Map validation
            //}
            // we don't have a map.. simply update
            //else
            //{
            this.Pos = pos;
            //}
        }

        public void Update(GameTime gameTime, KeyboardState kbs)
        {
            // Check Keyboard and character direction
            if (direction == SideDirection.RUN_LEFT)
                direction = SideDirection.STAND_LEFT;
            else if (direction == SideDirection.RUN_RIGHT)
                direction = SideDirection.STAND_RIGHT;
            else if (direction == SideDirection.RUN_DOWN)
                direction = SideDirection.STAND_DOWN;
            else if (direction == SideDirection.RUN_UP)
                direction = SideDirection.STAND_UP;

            if (kbs.IsKeyDown(runLeft))
            {
                direction = SideDirection.RUN_LEFT;
                moveLeft.Update(gameTime);

                // update the position, for all animations
                Vector2 pos = new Vector2(standLeft.Pos.X, standLeft.Pos.Y);
                pos.X -= inc.X;

                // Validate collisions using Rectangle.Intersects()
                // TO DO 

                // Validate collisions using map
                ValidateAndSetPos(pos);

            }
            if (kbs.IsKeyDown(runRight))
            {
                direction = SideDirection.RUN_RIGHT;
                moveRight.Update(gameTime);

                // update the position, for all animations
                Vector2 pos = new Vector2(standLeft.Pos.X, standLeft.Pos.Y);
                pos.X += inc.X;

                // Validate collisions using Rectangle.Intersects()
                // TO DO 

                // Validate collisions using map
                ValidateAndSetPos(pos);
            }
            if (kbs.IsKeyDown(runUp))
            {
                direction = SideDirection.RUN_UP;
                moveUp.Update(gameTime);

                // update the position, for all animations
                Vector2 pos = new Vector2(standLeft.Pos.X, standLeft.Pos.Y);
                pos.Y -= inc.Y;

                // Validate collisions using Rectangle.Intersects()
                // TO DO 

                // Validate collisions using map
                ValidateAndSetPos(pos);
            }
            if (kbs.IsKeyDown(runDown))
            {
                direction = SideDirection.RUN_DOWN;
                moveDown.Update(gameTime);

                // update the position, for all animations
                Vector2 pos = new Vector2(standLeft.Pos.X, standLeft.Pos.Y);
                pos.Y += inc.Y;

                // Validate collisions using Rectangle.Intersects()
                // TO DO 

                // Validate collisions using map
                ValidateAndSetPos(pos);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (direction == SideDirection.RUN_LEFT)
                moveLeft.Draw(spriteBatch, color);
            else if (direction == SideDirection.RUN_RIGHT)
                moveRight.Draw(spriteBatch, color);
            else if (direction == SideDirection.RUN_DOWN)
                moveDown.Draw(spriteBatch, color);
            else if (direction == SideDirection.RUN_UP)
                moveUp.Draw(spriteBatch, color);
            else if (direction == SideDirection.STAND_LEFT)
                standLeft.Draw(spriteBatch, color);
            else if (direction == SideDirection.STAND_RIGHT)
                standRight.Draw(spriteBatch, color);
            else if (direction == SideDirection.STAND_UP)
                standUp.Draw(spriteBatch, color);
            else if (direction == SideDirection.STAND_DOWN)
                standDown.Draw(spriteBatch, color);
        }

        //public void DrawPosition(SpriteBatch spriteBatch)
        //{
        //    spriteBatch.Begin();
        //    //spriteBatch.DrawString(font, "pos: " + this.Pos.X + " " + this.Pos.Y, new Vector2(0, 0), Color.Blue);
        //    spriteBatch.DrawString(font, "pos: " + this.Pos.X + " " + this.Pos.Y, Pos, Color.Blue);
        //    spriteBatch.End();
        //}

        // -------------------------------------------------------------------------------------------
        // Basic Collision methods inherited from INTERFACE
        // Method to check intersection of this (eventual) object with a rectangle
        public override bool Intersects(Rectangle colIn)
        {
            return standRight.Pos.Intersects(colIn);
        }

        // Basic Collision methods inherited from INTERFACE
        // Method for this (eventual) object to provide a rectangle for collision
        public override Rectangle GetCollisionRect()
        {
            return standRight.Pos;
        }
        // -------------------------------------------------------------------------------------------
    }
}
