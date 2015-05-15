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
    class LinkCharacter : BasicCollision
    {
        bool drawPosition;
        Color linkColor;
        AnimatedCharacter link;

        public LinkCharacter()
        {
            link = new AnimatedCharacter();
            drawPosition = false;
            linkColor = Color.White;
        }

        public void LoadContent(ContentManager Content, Keys left, Keys right, Keys up, Keys down)
        {
            //link.LoadContent(Content, "SpriteFont1.xnb");

            link.SetMoveSprites(SideDirection.RUN_DOWN, Content, "PlaneGDown", "00", 4, 0.05f, down);
            link.SetMoveSprites(SideDirection.RUN_LEFT, Content, "PlaneLeft", "00", 1, 0.05f, left);
            link.SetMoveSprites(SideDirection.RUN_RIGHT, Content, "PlaneRight", "00", 1, 0.05f, right);
            link.SetMoveSprites(SideDirection.RUN_UP, Content, "PlaneGUp", "00", 7, 0.05f, up);

            link.SetStandSprites(SideDirection.STAND_DOWN, Content, "PlaneDown/0001");
            link.SetStandSprites(SideDirection.STAND_LEFT, Content, "StandLeft/0001");
            link.SetStandSprites(SideDirection.STAND_RIGHT, Content, "StandRight/0001");
            link.SetStandSprites(SideDirection.STAND_UP, Content, "PlaneUp/0001");
        }

        public Vector2 Pos
        {
            set
            {
                link.Pos = value;
            }
            get
            {
                return link.Pos;
            }
        }

        public void Update(GameTime gametime, KeyboardState kbs)
        {
            link.Update(gametime, kbs);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            link.Draw(spriteBatch, linkColor);

            //if (drawPosition)
            //    link.DrawPosition(spriteBatch);
        }

        // -------------------------------------------------------------------------------------------
        // Basic Collision methods inherited from INTERFACE
        // Method to check intersection of this (eventual) object with a rectangle
        public override bool Intersects(Rectangle colIn)
        {
            return link.Intersects(colIn);
        }

        // Basic Collision methods inherited from INTERFACE
        // Method for this (eventual) object to provide a rectangle for collision
        public override Rectangle GetCollisionRect()
        {
            return link.GetCollisionRect();
        }

        // OVERRIDING our Check Collision method
        public override bool CheckCollision<T>(T check)
        {
            // Implement the collision detection
            bool result = base.CheckCollision(check);

            // Do whatever we want if collision is true
            if (result)
            {
                // TO DO - eg draw position
                drawPosition = true;
                linkColor = Color.Red;
            }
            else
            {
                drawPosition = false;
                linkColor = Color.White;
            }

            return result;
        }
        // -------------------------------------------------------------------------------------------
    }
}
