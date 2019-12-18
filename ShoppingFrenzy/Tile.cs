using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingFrenzy
{
    public class Tile
    {
        protected Texture2D sprite;
        protected float rotation;
        private Vector2 position;
        protected ContentManager content;
        private bool walkable;
        private string buyItem;
        private Node node;
        private string tileType;
        private static readonly string[] buyAbles = new string[] { "BuyAxe", "BuyClaw", "BuyDagger", "BuyMace", "BuyShuriken", "BuyStaff" };
        private int hValue = 0;

        public Vector2 Position { get => position; }
        public Node Node { get => node; set => node = value; }
        public bool Walkable { get => walkable; set => walkable = value; }
        public static string[] BuyAbles { get => buyAbles; }
        public string TileType { get => tileType; set => tileType = value; }
        public int HValue { get => hValue; set => hValue = value; }

        public Tile()
        {

        }

        //DIfferent tiles
        public Tile(Vector2 startPosition, ContentManager content, string tileType)
        {
            position = startPosition;
            this.content = content;
            this.TileType = tileType;

            switch (tileType)
            {
                case "Floor":
                    sprite = content.Load<Texture2D>("Floor");
                    Walkable = true;
                    break;
                case "Display":
                    sprite = content.Load<Texture2D>("Display");
                    Walkable = false;
                    break;
                case "DisplayAxe":
                    sprite = content.Load<Texture2D>("DisplayAxe");
                    Walkable = false;
                    break;
                case "DisplayClaw":
                    sprite = content.Load<Texture2D>("DisplayClaw");
                    Walkable = false;
                    break;
                case "DisplayDagger":
                    sprite = content.Load<Texture2D>("DisplayDagger");
                    Walkable = false;
                    break;
                case "DisplayMace":
                    sprite = content.Load<Texture2D>("DisplayMace");
                    Walkable = false;
                    break;
                case "DisplayShuriken":
                    sprite = content.Load<Texture2D>("DisplayShuriken");
                    Walkable = false;
                    break;
                case "DisplayStaff":
                    sprite = content.Load<Texture2D>("DisplayStaff");
                    Walkable = false;
                    break;
                case "BuyAxe":
                    sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
                case "BuyClaw":
                    sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
                case "BuyDagger":
                    sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
                case "BuyMace":
                    sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
                case "BuyShuriken":
                    sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
                case "BuyStaff":
                    sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, Vector2.Zero, 1f, new SpriteEffects(), 0f);
        }

        public static void GenerateHValue(int targetTileX, int targetTileY, Shopper targetShopper)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    int temp1 = Math.Abs((i - targetTileX));
                    int temp2 = Math.Abs((k - targetTileY));

                    targetShopper.ShopperMap[i,k].HValue = (temp1 + temp2)*10;
                }
            }
               
            }
           
        }
    }

