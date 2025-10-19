using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda
{
    public class Zelda
    {
        private Texture2D texture;
        private Vector2 position;

        private int tileSize = 36;



        public Zelda(Texture2D texture, Vector2 position) { 
        
            this.texture = texture;
            this.position = position;
        
        }

        public Rectangle GetZeldaRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, tileSize, tileSize);
        }

        //public Rectangle GetKeyRectangle()
        //{
        //    return new Rectangle((int)position.X, (int)position.Y, tileSize, tileSize);
        //}

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,position,Color.White);
        }
    }
}
