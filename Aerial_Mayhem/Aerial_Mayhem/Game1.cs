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
        TestChraracter bs;

        LinkCharacter link1;
        BasicSprite sprite1;
        ArrayList disparos;
        ArrayList proyectiles;
        ArrayList minions;
        BasicSprite bala;


        bool conBalas = true;
        bool canDrop = true;
        bool cols = false;
        bool cols2 = false;
        bool cols3 = false;
        int life = 200;
        
         

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
           
            link1.LoadContent(Content, Keys.Left, Keys.Right, Keys.Up, Keys.Down);
            link1.Pos = new Vector2(100, 100);

            sprite1.Init(Content, "Boss.png");
            sprite1.SetAutomove(true);
            sprite1.SetIncrement(new Rectangle(-2, 0, 50, 50));

            Rectangle temp = sprite1.Pos;
            temp.X = 2500;
            temp.Y = 0;
            sprite1.Pos = temp;

//Arreglos
            proyectiles = new ArrayList();
            minions = new ArrayList();
            disparos = new ArrayList();
            
            

            for (int a = 0; a < 4; a++)
            {

                BasicSprite enemy = new BasicSprite();
                enemy.LoadContent(Content, a * 300 + 700, a*100+40, 50, 50, "0039.png");
                enemy.SetAutomove(true);
                enemy.SetIncrement(new Rectangle(-2, 0, 900, 50));
                proyectiles.Add(enemy);

            }

            for (int d = 0; d < 10; d++)
            {

                BasicSprite evilmen = new BasicSprite();
                evilmen.LoadContent(Content, d * 3000 + 700, d*50 +30, 50, 50, "0009.png");
                evilmen.SetAutomove(true);
                evilmen.SetIncrement(new Rectangle(-10, 0, 900, 50));
                minions.Add(evilmen);

            }
            loop = new BackgroundLoop(Content,0,240,2, "./Fondo_nivel01/fondo_medio_nivel01");
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

            int stop;
            stop = sprite1.GetRectangle().X;

            if (stop >= 500)
                sprite1.Update(gameTime);
            
            // TODO: Add your update logic here
            if(life>0)
            link1.Update(gameTime, Keyboard.GetState());

            


            //arrelos de balas y enemigos

            for (int b = 0; b < proyectiles.Count; b++)
            {
                
                BasicSprite enemy;
                enemy = (BasicSprite)proyectiles[b];              
                enemy.Update(gameTime);                                 
            }

            for (int b = 0; b < proyectiles.Count; b++)
            {
                cols=link1.CheckCollision((BasicSprite)proyectiles[b]);
                    if (cols)
                    {
                        life = life - 1;
                        break;
                    }
                        link1.CheckCollision(sprite1);
            }
                            link1.CheckCollision(sprite1);
            //minions

            for (int b = 0; b < minions.Count; b++)
            {

                BasicSprite evilmen;
                evilmen = (BasicSprite)minions[b];
                evilmen.Update(gameTime);
            }

            for (int c = 0; c < minions.Count; c++)
            {
                cols2 = link1.CheckCollision((BasicSprite)minions[c]);
                    if (cols2)
                    {
                        life = life - 100;
                        break;
                    }
                        link1.CheckCollision(sprite1);
            }
                             link1.CheckCollision(sprite1);
            //fire

            if (Keyboard.GetState().IsKeyDown(Keys.A) && canDrop && conBalas)
            {
                float x = link1.Pos.X;               
                float y = link1.Pos.Y+20;
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


            for (int o = 0; o < disparos.Count; o++)
            {
                cols3 = sprite1.CheckCollision((BasicSprite)disparos[o]);
                if (cols3)
                    {
                        sprite1.Draw(spriteBatch, Color.Red);
                        break;
                    }
            }



            if (disparos.Count == 10) conBalas = false;
            else conBalas = true;

            




            //Collisiones Enemigos
            

            




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

<<<<<<< HEAD
            if (cols)           
                link1.Draw(spriteBatch, Color.Red);                         
=======
            if(cols)
                link1.Draw(spriteBatch,Color.Red);
>>>>>>> parent of e11c29b... ya final
            else
                link1.Draw(spriteBatch);
            

            if (cols3)
                sprite1.Draw(spriteBatch, Color.Red);
            else
                sprite1.Draw(spriteBatch);

            for (int m = 0; m < proyectiles.Count; m++)
            {
                BasicSprite enemy;
                enemy = (BasicSprite)proyectiles[m];
                enemy.Draw(spriteBatch, Color.White);

            }

            for (int n = 0; n < minions.Count; n++)
            {
                BasicSprite evilmen;
                evilmen = (BasicSprite)minions[n];
                evilmen.Draw(spriteBatch, Color.White);

            }

            for (int k = 0; k < disparos.Count; k++)
            {
                BasicSprite bala;
                bala = (BasicSprite)disparos[k];
                bala.Draw(spriteBatch, Color.White);
            }

<<<<<<< HEAD
            if (life < 0)
                Exit();

=======
>>>>>>> parent of e11c29b... ya final
            base.Draw(gameTime);
            
        }
    }
}
