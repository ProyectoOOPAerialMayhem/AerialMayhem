using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.DrawUtils
{
    enum ButtonStates 
    { 
        normal,rollover,mouseDown,active
    }
    public class Button :IDrawable
    {
        SimpleSprite[] states;
        Rectangle pos;
        ButtonStates state;
        bool active;
        /// <summary>
        /// Standar  position rectangle
        /// states[0]=normal,states[1]=rollover,state[2]=mouseDown,state[4]Active
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="states"></param>
        public Button(Rectangle pos,SimpleSprite [] states)
        {
            this.states = states;
            state = ButtonStates.normal;
        }
        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            Rectangle r = new Rectangle(mouse.X, mouse.Y, 1, 1);
            if (active)
            {
                state = ButtonStates.active;
            }
            else if (r.Intersects(pos))
            {
                state = ButtonStates.rollover;
                if (mouse.RightButton == ButtonState.Pressed)
                {
                    active = true;
                    state = ButtonStates.mouseDown;
                }

            }
            else
                state = ButtonStates.normal;
            
        }
        public bool Triggered()
        {
            return active;
        }
        public void Release()
        {
            active = false;
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sp)
        {
            states[(int)state].Draw(sp);
        }
    }
}
