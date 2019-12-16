using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingFrenzy
{
    class Tile
    {
        protected Texture2D sprite;
        protected float rotation;
        protected Vector2 position;
        public Vector2 Position { get => position; }
        protected ContentManager content;
        private bool Walkable;
        private string buyItem;
    
        //DIfferent tiles
        public Tile(Vector2 startPosition, ContentManager content, string tileType)
        {
            position = startPosition;
            this.content = content;

            if (tileType == "Floor")
            {
                sprite = content.Load<Texture2D>("Floor");
                Walkable = true;
            }

            if (tileType == "Display")
            {
                sprite = content.Load<Texture2D>("Display");
                Walkable = false;
            }

            if (tileType == "DisplayAxe")
            {
                sprite = content.Load<Texture2D>("DisplayAxe");
                Walkable = false;
            }

            if (tileType == "DisplayClaw")
            {
                sprite = content.Load<Texture2D>("DisplayClaw");
                Walkable = false;
            }

            if (tileType == "DisplayDagger")
            {
                sprite = content.Load<Texture2D>("DisplayDagger");
                Walkable = false;
            }

            if (tileType == "DisplayMace")
            {
                sprite = content.Load<Texture2D>("DisplayMace");
                Walkable = false;
            }

            if (tileType == "DisplayShuriken")
            {
                sprite = content.Load<Texture2D>("DisplayShuriken");
                Walkable = false;
            }

            if (tileType == "DisplayStaff")
            {
                sprite = content.Load<Texture2D>("DisplayStaff");
                Walkable = false;
            }

            if (tileType == "BuyAxe")
            {
                sprite = content.Load<Texture2D>("FloorWhite");
                Walkable = true;
                buyItem = "Axe";

            }

            if (tileType == "BuyClaw")
            {
                sprite = content.Load<Texture2D>("FloorWhite");
                Walkable = true;
                buyItem = "Claw";

            }

            if (tileType == "BuyDagger")
            {
                sprite = content.Load<Texture2D>("FloorWhite");
                Walkable = true;
                buyItem = "Dagger";

            }

            if (tileType == "BuyMace")
            {
                sprite = content.Load<Texture2D>("FloorWhite");
                Walkable = true;
                buyItem = "Mace";

            }

            if (tileType == "BuyShuriken")
            {
                sprite = content.Load<Texture2D>("FloorWhite");
                Walkable = true;
                buyItem = "Shuriken";

            }

            if (tileType == "BuyStaff")
            {
                sprite = content.Load<Texture2D>("FloorWhite");
                Walkable = true;
                buyItem = "Staff";

            }

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, Vector2.Zero, 1f, new SpriteEffects(), 0f);
        }
    }
}
