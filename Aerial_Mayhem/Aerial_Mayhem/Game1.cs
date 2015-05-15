#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Aerial_Mayhem.Scenes;
using Aerial_Mayhem.DrawUtils;
#endregion

namespace Aerial_Mayhem
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {

        //Default screen : 480*800
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //skeleton
        GameScenes scene;
        Player player;
        //testing...
        BackgroundLoop loop;
        BackgroundLoop loop3;
        TestChraracter bs;

        LinkCharacter link1, link2;
        BasicSprite sprite1;
        ArrayList disparos;
      
        BasicSprite bala;


        bool conBalas = true;
        bool canDrop = true;
        int x = 200;
        int y = -95;
        int z = 0;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            bs = new TestChraracter(new Rectangle(100, 100, 100, 100));
            //screen: graphics.PreferredBackBufferHeight; graphics.PreferredBackBufferWidth
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            link1 = new LinkCharacter();
            bala = new BasicSprite();
            sprite1 = new BasicSprite();

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bs.LoadContent(Content);
            Rectangle screen = new Rectangle(0, 480/ 2, 2438, 480);
            loop = new BackgroundLoop(Content,screen , Color.White, 2, "./Fondo_nivel01/fondo_medio_nivel01");

            loop3 = new BackgroundLoop(Content, screen, Color.White, 2, "./Fondo_nivel01/fondo_medio_nivel01");

            spriteBatch = new SpriteBatch(GraphicsDevice);
            link1.LoadContent(Content, Keys.Left, Keys.Right, Keys.Up, Keys.Down);
           

            link1.Pos = new Vector2(100, 100);

            sprite1.Init(Content, "enemy");
            sprite1.SetAutomove(true);
            sprite1.SetIncrement(new Rectangle(-2, 0, 50, 50));

            Rectangle temp = sprite1.Pos;
            temp.X = 200;
            sprite1.Pos = temp;

            disparos = new ArrayList();
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            loop.Update(gameTime);
            bs.Update(gameTime);


            sprite1.Update(gameTime);

            // TODO: Add your update logic here
            link1.Update(gameTime, Keyboard.GetState());
            link1.CheckCollision(sprite1);

            if (Keyboard.GetState().IsKeyDown(Keys.A) && canDrop && conBalas)
            {
                float x = link1.Pos.X*2;               
                float y = link1.Pos.Y*2;
                canDrop = false;
                BasicSprite bala = new BasicSprite();
                bala.LoadContent(Content, (int)x,(int)y, 50,50,"Bullet.png");
                bala.SetIncrement(new Rectangle(4, 0, 50, 50));
                bala.SetAutomove(true);
                disparos.Add(bala);


            }

            else if (Keyboard.GetState().IsKeyUp(Keys.C))
            {
                canDrop = true;
            }

            for (int k = 0; k < disparos.Count; k++)
            {
                BasicSprite bala;
                bala = (BasicSprite)disparos[k];
                bala.Update(gameTime);
            }

            for (int k = 0; k < disparos.Count; k++)
            {
                BasicSprite bala = (BasicSprite)disparos[k];
                int pos = bala.GetRectangle().X;
                pos = bala.GetRectangle().X + 3;
                disparos[k] = bala;
                if (bala.GetRectangle().X > 800) disparos.RemoveAt(k);
            }

            if (disparos.Count == 10) conBalas = false;
            else conBalas = true;




            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            loop.Draw(spriteBatch);
            //bs.Draw(spriteBatch);
            spriteBatch.End();

            link1.Draw(spriteBatch);
            

            sprite1.Draw(spriteBatch);

            for (int k = 0; k < disparos.Count; k++)
            {
                BasicSprite bala;
                bala = (BasicSprite)disparos[k];
                bala.Draw(spriteBatch, Color.White);
            }

            base.Draw(gameTime);
            
        }
    }
}
