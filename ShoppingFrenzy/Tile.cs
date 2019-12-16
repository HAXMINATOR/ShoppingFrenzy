using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace ShoppingFrenzy
{
    public class Tile : GameObject
    {
        public Tile(string spriteName, ContentManager content) : base(spriteName, content)
        {
        }
    }
}
