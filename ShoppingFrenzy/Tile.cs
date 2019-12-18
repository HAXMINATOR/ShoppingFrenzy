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
        private Texture2D sprite;
        protected float rotation;
        private Vector2 position;
        protected ContentManager content;
        private bool walkable;
        private string buyItem;
        private Node node;
        private string tileType;
        private static readonly string[] buyAbles = new string[] { "BuyAxe", "BuyClaw", "BuyDagger", "BuyMace", "BuyShuriken", "BuyStaff" };

        public Vector2 Position { get => position; }
        public Node Node { get => node; set => node = value; }
        public bool Walkable { get => walkable; set => walkable = value; }
        public static string[] BuyAbles { get => buyAbles; }
        public string TileType { get => tileType; set => tileType = value; }
        public Texture2D Sprite { get => sprite; set => sprite = value; }

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
                    Sprite = content.Load<Texture2D>("Floor");
                    Walkable = true;
                    break;
                case "Display":
                    Sprite = content.Load<Texture2D>("Display");
                    Walkable = false;
                    break;
                case "DisplayAxe":
                    Sprite = content.Load<Texture2D>("DisplayAxe");
                    Walkable = false;
                    break;
                case "DisplayClaw":
                    Sprite = content.Load<Texture2D>("DisplayClaw");
                    Walkable = false;
                    break;
                case "DisplayDagger":
                    Sprite = content.Load<Texture2D>("DisplayDagger");
                    Walkable = false;
                    break;
                case "DisplayMace":
                    Sprite = content.Load<Texture2D>("DisplayMace");
                    Walkable = false;
                    break;
                case "DisplayShuriken":
                    Sprite = content.Load<Texture2D>("DisplayShuriken");
                    Walkable = false;
                    break;
                case "DisplayStaff":
                    Sprite = content.Load<Texture2D>("DisplayStaff");
                    Walkable = false;
                    break;
                case "BuyAxe":
                    Sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
                case "BuyClaw":
                    Sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
                case "BuyDagger":
                    Sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
                case "BuyMace":
                    Sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
                case "BuyShuriken":
                    Sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
                case "BuyStaff":
                    Sprite = content.Load<Texture2D>("FloorWhite");
                    Walkable = true;
                    buyItem = "Axe";
                    break;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, position, null, Color.White, rotation, Vector2.Zero, 1f, new SpriteEffects(), 0f);
        }
    }
}
