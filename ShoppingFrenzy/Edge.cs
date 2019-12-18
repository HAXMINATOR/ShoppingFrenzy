using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingFrenzy
{
    public class Edge
    {
        Node parent;
        Node child;

        public Edge(Node parent, Node child)
        {
            Parent = parent;
            Child = child;
        }

        public Node Parent { get => parent; set => parent = value; }
        public Node Child { get => child; set => child = value; }
    }
}
