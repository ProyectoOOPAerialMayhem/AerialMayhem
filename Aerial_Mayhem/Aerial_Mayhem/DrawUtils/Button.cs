using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.DrawUtils
{
    enum ButtonStates 
    { 

    }
    public class Button :IDrawable
    {
        SimpleSprite[] states;
        Rectangle pos;
        ButtonStates state;
        public Button(Rectangle pos,SimpleSprite mouseDown)
        {

        }
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sp)
        {
        }
    }
}
