using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Aerial_Mayhem
{
    abstract class AbstractSprite
    {

        // atributes 
        Rectangle pos;
        Texture2D image;



        // methods 
        //abstract void LoadContent(ContentManager Content);
        //abstract void Draw(SpriteBatch spriteBatch);


        // implemented methods 
        void Initialize(int x, int y)
        {
            pos = new Rectangle();
            pos.X = x;
            pos.Y = y; 

        }



    }
}
