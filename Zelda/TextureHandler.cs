using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda
{
    public static class TextureHandler
    {
        public static Texture2D bushTexture;
        public static Texture2D grassTexture;
        public static Texture2D zeldaTexture;
        public static Texture2D skeletonTexture;
        public static Texture2D bridgeTexture;
        public static Texture2D doorTexture;
        public static Texture2D keyTexture;
        public static Texture2D stoneFloorTexture;
        public static Texture2D wallTexture;
        public static Texture2D waterTexture;
        public static Texture2D linkTexture;
        public static Texture2D startScreenTexture;

        public static SpriteFont font;

        public static void LoadContent(ContentManager content)
        {

            bushTexture = content.Load<Texture2D>("bushS");
            grassTexture = content.Load<Texture2D>("grass");
            linkTexture = content.Load<Texture2D>("Link_alone");
            zeldaTexture = content.Load<Texture2D>("Zelda");
            skeletonTexture = content.Load<Texture2D>("skelett");
            bridgeTexture = content.Load<Texture2D>("bridge");
            doorTexture = content.Load<Texture2D>("door");
            keyTexture = content.Load<Texture2D>("key");
            stoneFloorTexture = content.Load<Texture2D>("stonefloor");
            wallTexture = content.Load<Texture2D>("wall");
            waterTexture = content.Load<Texture2D>("water");
            startScreenTexture = content.Load<Texture2D>("spacebackground1");
            font = content.Load<SpriteFont>("font");


        }
    }
}
