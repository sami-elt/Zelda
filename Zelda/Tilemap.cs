using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;


namespace Zelda
{
    public class TileMap
    {
        private Tileset[,] tileArray;
        private int tileSize = 36;

        public Player player;
        public List <Enemy> enemies = new List <Enemy>();
        public Zelda key, door;

        public Vector2 positionDoor;

        public List<string> ReadFromFile(string path)
        {
            StreamReader streamReader = new StreamReader(path);

            List<string> result = new List<string>();

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                result.Add(line);
            }
            streamReader.Close();
            return result;
        }

        public void CreateWorld(string path)
        {
            List<string> level = ReadFromFile(path);
            tileArray = new Tileset[level[0].Length, level.Count];

            for (int i = 0; i < level.Count; i++)
            {
                for (int j = 0; j < level[i].Length; j++)
                {
                    if (level[i][j] == 'w')
                    {
                        tileArray[j, i] = new Tileset(
                            TextureHandler.bushTexture,
                            new Vector2(j * tileSize, i * tileSize),
                            true);
                    }
                    else if (level[i][j] == '-')
                    {
                        tileArray[j, i] = new Tileset(
                            TextureHandler.grassTexture,
                            new Vector2(j * tileSize, i * tileSize),
                            false);
                    }
                    else if (level[i][j] == 'b')
                    {
                        tileArray[j, i] = new Tileset(
                            TextureHandler.grassTexture,
                            new Vector2(j * tileSize, i * tileSize),
                            false);

                            player = new Player(TextureHandler.linkTexture, new Vector2(j * tileSize, i * tileSize), this);

                    }
                    else if (level[i][j] == 'e')
                    {
                        tileArray[j, i] = new Tileset(
                            TextureHandler.grassTexture,
                            new Vector2(j * tileSize, i * tileSize),
                            false);

                            enemies.Add(new Enemy(TextureHandler.skeletonTexture, new Vector2(j * tileSize, i * tileSize), this));
                    }
                    else if(level[i][j] == 'k')
                    {
                        tileArray[j, i] = new Tileset(
                            TextureHandler.grassTexture,
                            new Vector2(j * tileSize, i * tileSize),
                            false);

                        key = new Zelda(TextureHandler.keyTexture, new Vector2(j * tileSize, i * tileSize));

                    }
                    else if (level[i][j] == 'd')
                    {
                        tileArray[j, i] = new Tileset(
                            TextureHandler.grassTexture,
                            new Vector2(j * tileSize, i * tileSize),
                            true);

                        door = new Zelda(TextureHandler.doorTexture, new Vector2(j * tileSize, i * tileSize));

                        positionDoor = new Vector2(j,i);
                    }
                    else if (level[i][j] == 'l')
                    {
                        tileArray[j, i] = new Tileset(
                            TextureHandler.bridgeTexture,
                            new Vector2(j * tileSize, i * tileSize),
                            false);
                    }
                    else if (level[i][j] == 'v')
                    {
                        tileArray[j, i] = new Tileset(
                            TextureHandler.waterTexture,
                            new Vector2(j * tileSize, i * tileSize),
                            true);
                    }
                    else if (level[i][j] == 's')
                    {
                        tileArray[j, i] = new Tileset(
                            TextureHandler.wallTexture,
                            new Vector2(j * tileSize, i * tileSize),
                            true);
                    }
                    else if (level[i][j] == 'z')
                    {
                        tileArray[j, i] = new Tileset(
                            TextureHandler.zeldaTexture,
                            new Vector2(j * tileSize, i * tileSize),
                            true);
                    }

                }



            }
        }

        public void IfDoorUnlocked()
        {
            tileArray[(int)positionDoor.X, (int)positionDoor.Y].wall = false;
        }

        public bool GetTileAtPosition(Vector2 position)
        {
            return tileArray[(int)position.X / tileSize, (int)position.Y / tileSize].wall;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tileArray.GetLength(1); i++)
            {
                for (int j = 0; j < tileArray.GetLength(0); j++)
                {
                    if (tileArray[j, i] != null)
                    {
                        tileArray[j, i].Draw(spriteBatch);
                    }
                }
            }
        }

    }
}
