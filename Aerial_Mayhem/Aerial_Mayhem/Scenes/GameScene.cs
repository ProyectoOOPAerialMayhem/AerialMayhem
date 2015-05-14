using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.Scenes
{
      
   internal abstract class GameScene : Aerial_Mayhem.IDrawable
    {
       public void ChangeScene(GameScenes scene) { 
       }

       public abstract void Update(Microsoft.Xna.Framework.GameTime gameTime);

       public abstract void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sp);

    }
}
