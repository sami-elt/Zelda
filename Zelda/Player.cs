using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Zelda
{
    public class Player
    {

        private Texture2D tex;

        private Vector2 position;
        private Vector2 direction;
        private Vector2 destination;
        private float playerSpeed = 200f;
        private float attackSpeed = 300f;

        private KeyboardState keyboardState;
        private KeyboardState previousKeyboardState;

        private List<Vector2> swordAttacks = new List<Vector2>();

        public bool GotKey { get; set; } = false;

        private bool moving = false;

        private int tileSize = 36;
        private TileMap tileMap;


        public Player(Texture2D tex, Vector2 position, TileMap tileMap)
        {
            this.tex = tex;
            this.tileMap = tileMap;
            this.position = position;

            keyboardState = Keyboard.GetState();

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
        }

        public void Update(GameTime gameTime)
        {
            previousKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();


            if (!moving)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    ChangeDirection(new Vector2(0, -1));
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    ChangeDirection(new Vector2(-1, 0));
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    ChangeDirection(new Vector2(1, 0));
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    ChangeDirection(new Vector2(0, 1));
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Space) && previousKeyboardState.IsKeyUp(Keys.Space))
                {
                    Vector2 swordStart = new Vector2(position.X + tileSize, position.Y + tileSize / 2);

                    swordAttacks.Add(swordStart);
                }

            }
            else
            {
                position += direction * playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (Vector2.Distance(position, destination) < 1)
                {
                    position = destination;
                    moving = false;
                }
            }

            for (int i = 0; i < swordAttacks.Count; i++)
            {
                swordAttacks[i] += new Vector2(1, 0) * attackSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                
            }
        }


        public Rectangle GetPlayerRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, tileSize, tileSize);
        }

        public List<Rectangle> GetSwordRectangles()
        {
            List<Rectangle> swordRectangles = new List<Rectangle>();

            foreach (var sword in swordAttacks)
            {
                swordRectangles.Add(new Rectangle((int)sword.X, (int)sword.Y, 10, 10));
            }

            return swordRectangles;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex,position,Color.White);

            foreach (var sword in swordAttacks)
            {
                spriteBatch.Draw(tex, new Rectangle((int)sword.X, (int)sword.Y, 10, 10),
            Color.Brown);
            }
        }
    }
}
