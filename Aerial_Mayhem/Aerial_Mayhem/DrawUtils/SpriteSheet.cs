using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerial_Mayhem.DrawUtils
{
    public struct SpriteSheet
    {
        int verticalFrames;
        int horizontalFrames;
        int frameCount;
        string filepath;
        public SpriteSheet(string filepath,int verticalFrames,int horizontalFrames, int frameCount)
        {
            this.filepath = filepath;
            this.verticalFrames = verticalFrames;
            this.horizontalFrames = horizontalFrames;
            this.frameCount = frameCount;
        }

        public int VerticalFrames
        {
            get { return verticalFrames; }
        }
        public int HorizontalFrames
        {
             get{return horizontalFrames;}
        }
        public int FrameCount
        {
             get{return frameCount;}
        }
        public string FilePath
        {
            get{return filepath;}
        }
    }
}
