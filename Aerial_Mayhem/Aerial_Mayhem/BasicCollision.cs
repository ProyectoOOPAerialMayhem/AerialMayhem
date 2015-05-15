using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Aerial_Mayhem
{
    abstract class BasicCollision : IBasicCollision
    {
        // Method from interface
        public abstract bool Intersects(Rectangle colIn);

        // Method from interface
        public abstract Rectangle GetCollisionRect();

        // GENERIC CheckCollision Method
        // Can be used with any class derived from IBasicCollision
        public virtual bool CheckCollision<T>(T check) where T : IBasicCollision
        {
            // NOTICE THAT ATTRIBUTES ARE NOT DIRECTLY REFERENCED
            return this.Intersects(check.GetCollisionRect());
        }

    }
}
