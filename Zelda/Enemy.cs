using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda
{
    public class Enemy
    {

        private Vector2 position;
        private Texture2D texture;
        private Vector2 destination;
        private Vector2 direction = new Vector2(-1, 0);

        private bool moving;

        private float speed;

        private int tileSize = 36;
        private TileMap tileMap;
        private Random random = new Random();

        public Enemy(Texture2D texture, Vector2 position, TileMap tileMap)
        {
            this.texture = texture;
            this.position = position;
            this.tileMap = tileMap;

            speed = random.Next(20, 120);
        }

        public void ChangeDirection(Vector2 dir)
        {
            direction = dir;
            Vector2 newDestination = position + direction * tileSize;


            if (!tileMap.GetTileAtPosition(newDestination))
            {
                destination = newDestination;
                moving = true;
            }
            else
            {
                direction = new Vector2(-direction.X, 0);
                newDestination = position + direction * tileSize;

                if (!tileMap.GetTileAtPosition(newDestination))
                {
                    destination = newDestination;
                    moving = true;
                }
            }
        }

        public void ChangeDirectionIfHit()
        {

            moving = false;

            Vector2 changeDirectionIfHit = new Vector2(-direction.X, 0);

            ChangeDirection(changeDirectionIfHit);
        }

        public Rectangle GetEnemyRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, tileSize, tileSize);
        }
        public void Update(GameTime gameTime)
        {

            if (!moving)
            {
                ChangeDirection(direction);
            }
            else
            {

                position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (Vector2.Distance(position, destination) < 1)
                {
                    position = destination;
                    moving = false;
                }

            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
