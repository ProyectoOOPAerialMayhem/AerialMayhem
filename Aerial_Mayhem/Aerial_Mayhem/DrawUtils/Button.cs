using Microsoft.Xna.Framework;
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

        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sp)
        {
        }
    }
}
