using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Zelda
{
    public class Tileset
    {
        private Texture2D texture;
        private Vector2 position;
        public bool wall;



        public Tileset(Texture2D texture, Vector2 position, bool wall)
        {
            this.texture = texture;
            this.position = position;
            this.wall = wall;
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, Color.White);


        }
    }
}
