using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.Scenes
{
      enum GameScenes{
    StartScreen,OptionScreen,CharacterSlector,LevelSelector,Pause,GameOver,
    }
   internal abstract class GameScene
    {
        public abstract void ChangeScene(GameScenes scene);
    }
}
