using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.Scenes.Scenes
{
    public class SceneManager:IDrawable
    {
        GameScene currentScene;
        GameScene tempScene;
        public GameScene LoadScene(GameScenes scene, ContentManager c, GraphicsDeviceManager g)
        {
            switch (scene)
            {
                case GameScenes.StartScreen:
                    currentScene = new StartScreen(c,g);
                    return currentScene;
                case GameScenes.CharacterSlector:
                    currentScene = new CharacterSelector(c,g);
                    return currentScene;
                case GameScenes.GameOver:
                    currentScene = new GameOver(c,g);
                    return currentScene;
                case GameScenes.LevelSelector:
                    currentScene = new LevelSelector(c,g);
                    return currentScene;
                case GameScenes.OptionScreen:
                    currentScene = new OptionScreen(c,g);
                    return currentScene;
                case GameScenes.Pause:
                    currentScene = new Pause(c,g);
                    return currentScene;
                case GameScenes.LeaderBoard:
                    currentScene = new LeaderBoard(c,g);
                    return currentScene;
                default:
                    return currentScene;
            }
              
               
        }
        public void UnloadScene()
        {
            currentScene.Unload();
        }
        public void ChangeScene(GameScenes scene,ContentManager Content,GraphicsDeviceManager g)
        {
            currentScene = LoadScene(scene,Content,g);
        }
        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch sp)
        {
            throw new NotImplementedException();
        }
    }
}
