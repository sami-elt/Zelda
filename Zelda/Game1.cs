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
        private Zelda zelda;

        private int life = 3;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2;
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



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            foreach (Enemy enemy in tileMap.enemies)
            {
                enemy.Update(gameTime);
            }

            for (int i = tileMap.enemies.Count - 1; i >= 0; i--)
            {
                Enemy enemy = tileMap.enemies[i];

                foreach (Rectangle swordRect in player.GetSwordRectangles())
                {
                    if (swordRect.Intersects(enemy.GetEnemyRectangle()))
                    {
                        tileMap.enemies.RemoveAt(i);
                        break;
                    }
                }
            }

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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            tileMap.Draw(spriteBatch);

            player.Draw(spriteBatch);

            foreach(Enemy enemy in tileMap.enemies)
            {
                enemy.Draw(spriteBatch);
            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
