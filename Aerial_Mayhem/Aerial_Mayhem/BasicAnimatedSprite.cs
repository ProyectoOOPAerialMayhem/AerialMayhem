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

namespace Aerial_Mayhem
{
    class BasicAnimatedSprite : BasicCollision
    {
        // Attributes
        // Contains all attributes of basic sprite
        // -------------------------------------------
        Texture2D image;
        Rectangle pos;
        // for animation
        int frameCount;         // How many images
        int currentFrame;       // Which image to draw now
        ArrayList textureList;  // Texture array for multiple images
        float timer;            // To calc how long each frame will be shown
        float timePerFrame;     // Time to show each frame
        bool multipleFiles;     // True if multiple files used for animation
        int frameWidth;         // Size of the frame
        int frameHeight;        // Size of the frame

        // Metodos
        // -------------------------------------------
        // Load multiple images for animation
        public void InitMultipleFiles(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            this.frameCount = frameCount;
            this.timePerFrame = timePerFrame;
            this.currentFrame = 0;
            this.timer = 0.0f;
            this.textureList = new ArrayList();
            this.multipleFiles = true;

            // Load all the texture images
            for (int k = 1; k <= frameCount; k++)
            {
                Texture2D tex;
                tex = Content.Load<Texture2D>(nameDir + "/" + nameFile + k.ToString("00"));
                textureList.Add(tex);
            }

            // we will assume all images have same dimensions (width/height)
            pos = new Rectangle(0, 0, ((Texture2D)textureList[0]).Width, ((Texture2D)textureList[0]).Height);
        }

        // Load single image for animation
        public void InitSingleFile(ContentManager Content, String name, int frameWidth, int frameHeight, int frameCount, float timePerFrame)
        {
            this.frameCount = frameCount;
            this.timePerFrame = timePerFrame;
            this.currentFrame = 0;
            this.timer = 0.0f;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.multipleFiles = false;

            // Actually load the texture
            image = Content.Load<Texture2D>(name);

            // we will assume all images have same dimensions (width/height)
            // OJO!!! This rectangle is DIFFERENT to the one used for selecting the frame
            pos = new Rectangle(0, 0, frameWidth, frameHeight);
        }

        // Update function is the same for both types of animation
        public void Update(GameTime gameTime)
        {
            // Calculate how much time has passed
            timer = timer + (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= timePerFrame)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                timer = timer - timePerFrame;
            }
        }

        // Draw function - same for both but with a control flag
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            // Draw animated sprite based on multiple files
            if (multipleFiles)
            {
                if (currentFrame < textureList.Count)
                {
                    Texture2D tex = (Texture2D)textureList[currentFrame];
                    spriteBatch.Draw(tex, pos, Color.White);
                }
            }
            // Draw animated sprite based on single file with multiple frames
            else
            {
                int xTex, yTex;
                Rectangle sourceRect;

                xTex = currentFrame * frameWidth;
                yTex = 0;
                sourceRect = new Rectangle(xTex, yTex, frameWidth, frameHeight);
                spriteBatch.Draw(image, pos, sourceRect, Color.White);
            }
            spriteBatch.End();
        }

        // Draw function with POSITION - same for both but with a control flag
        public void Draw(SpriteBatch spriteBatch, Vector2 posIn)
        {
            spriteBatch.Begin();
            // Draw animated sprite based on multiple files
            if (multipleFiles)
            {
                if (currentFrame < textureList.Count)
                {
                    Texture2D tex = (Texture2D)textureList[currentFrame];
                    spriteBatch.Draw(tex, posIn, Color.White);
                }
            }
            // Draw animated sprite based on single file with multiple frames
            else
            {
                int xTex, yTex;
                Rectangle sourceRect;

                xTex = currentFrame * frameWidth;
                yTex = 0;
                sourceRect = new Rectangle(xTex, yTex, frameWidth, frameHeight);
                spriteBatch.Draw(image, posIn, sourceRect, Color.White);
            }
            spriteBatch.End();
        }

        // Draw function - same for both but with a control flag
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Begin();
            // Draw animated sprite based on multiple files
            if (multipleFiles)
            {
                if (currentFrame < textureList.Count)
                {
                    Texture2D tex = (Texture2D)textureList[currentFrame];
                    spriteBatch.Draw(tex, pos, color);
                }
            }
            // Draw animated sprite based on single file with multiple frames
            else
            {
                int xTex, yTex;
                Rectangle sourceRect;

                xTex = currentFrame * frameWidth;
                yTex = 0;
                sourceRect = new Rectangle(xTex, yTex, frameWidth, frameHeight);
                spriteBatch.Draw(image, pos, sourceRect, color);
            }
            spriteBatch.End();
        }

        // Get/Set the current position of the character, as a Rectangle
        public Rectangle Pos
        {
            set
            {
                pos = value;
            }
            get
            {
                return pos;
            }
        }

        // -------------------------------------------------------------------------------------------
        // Basic Collision methods inherited from INTERFACE
        // Method to check intersection of this (eventual) object with a rectangle
        public override bool Intersects(Rectangle colIn)
        {
            return pos.Intersects(colIn);
        }

        // Basic Collision methods inherited from INTERFACE
        // Method for this (eventual) object to provide a rectangle for collision
        public override Rectangle GetCollisionRect()
        {
            return pos;
        }
        // -------------------------------------------------------------------------------------------
    }
}
