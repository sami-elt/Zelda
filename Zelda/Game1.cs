using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;


namespace Zelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private TileMap tileMap;
        private Player player;
        private Zelda key;
        private Zelda door;

        private int life = 3;

        enum GameState 
        {
            Menu,
            GamePlay,
            GameEnded
        }

        private GameState gameState;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = 2000;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureHandler.LoadContent(Content);

            tileMap = new TileMap();
            tileMap.CreateWorld("map.txt");

            player = tileMap.player;

            door = tileMap.door;
            key = tileMap.key;



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (gameState)
            {
                case GameState.Menu:
                    //add gamestart logic
                    break;
                case GameState.GamePlay:

                    player.Update(gameTime);

                    foreach (Enemy enemy in tileMap.enemies)
                    {
                        enemy.Update(gameTime);
                    }

                    KeyAndDoorLogic();
                    EnemyIntersectsWithPlayer();
                    SwordIntersectsWithEnemy();

                    break;
                case GameState.GameEnded:
                    //add endgame logic
                    break;
            }




            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        private void KeyAndDoorLogic()
        {
            if (player.GetPlayerRectangle().Intersects(key.GetZeldaRectangle()))
            {
                player.GotKey = true;

                tileMap.IfDoorUnlocked();

            }

            if (player.GetPlayerRectangle().Intersects(door.GetZeldaRectangle()))
            {
                if (player.GotKey)
                {
                    Debug.WriteLine("winning");
                }
                else
                {
                    Debug.WriteLine("get the key");
                }
            }
        }

        private void SwordIntersectsWithEnemy()
        {
            for (int i = tileMap.enemies.Count - 1; i >= 0; i--)
            {
                Enemy enemy = tileMap.enemies[i];

                foreach (Rectangle swordRectangle in player.GetSwordRectangles())
                {
                    if (swordRectangle.Intersects(enemy.GetEnemyRectangle()))
                    {
                        tileMap.enemies.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        private void EnemyIntersectsWithPlayer()
        {
            foreach (Enemy enemy in tileMap.enemies)
            {
                if (enemy.GetEnemyRectangle().Intersects(player.GetPlayerRectangle()))
                {
                    life--;

                    enemy.ChangeDirectionIfHit();

                    if (life <= 0)
                    {

                        //implementera gameover screen
                        Debug.WriteLine("u dead");
                    }
                }
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            switch (gameState)
            {
                case GameState.Menu:
                    //Add start menu
                    break;
                case GameState.GamePlay:
                    tileMap.Draw(spriteBatch);
                    player.Draw(spriteBatch);

                    if (!player.GotKey)
                    {
                        key.Draw(spriteBatch);
                    }

                    door.Draw(spriteBatch);

                    foreach (Enemy enemy in tileMap.enemies)
                    {
                        enemy.Draw(spriteBatch);
                    }
                    break;
                case GameState.GameEnded:
                    //add endgame drawing
                    break;

            }


            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
