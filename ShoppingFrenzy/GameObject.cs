using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingFrenzy
{
    public class GameObject
    {
        public Texture2D sprite;
        public Vector2 position;
        public Color color = Color.White;

        public GameObject()
        {

        }

        public GameObject(string spriteName, ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
        }

        public void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, color);
        }
    }
}
