using Aerial_Mayhem.DrawUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aerial_Mayhem.Scenes;

namespace Aerial_Mayhem.Scenes
{
      
   internal abstract class GameScene : Aerial_Mayhem.IDrawable
    {
       protected Background bgd;
       protected SimpleSprite[] decorTex;
       

       public abstract void Update(Microsoft.Xna.Framework.GameTime gameTime);

       public abstract void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sp);
       public abstract void Unload();
    }
}
