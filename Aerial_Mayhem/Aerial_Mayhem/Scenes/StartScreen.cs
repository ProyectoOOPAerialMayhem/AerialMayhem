using Aerial_Mayhem.DrawUtils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.Scenes
{
    class StartScreen:GameScene
    {
        Button play;
        Button selectPlayer;
        Button leaderboards;
        Button Options;

        public StartScreen(ContentManager Content, GraphicsDeviceManager g)
        {
            bgd = new Background(Content, 0, 0, "Fondo_Inicio");

        }
        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch sp)
        {

        }
    }
}
