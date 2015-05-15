using Aerial_Mayhem.DrawUtils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.Scenes
{
    class CharacterSelector:GameScene
    {

        public CharacterSelector(Microsoft.Xna.Framework.Content.ContentManager c, GraphicsDeviceManager g)
        {
            bgd = new Background(c, 0, 0, "Fondo_SelectPalyer");
        }
        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch sp)
        {

        }

    }
}
