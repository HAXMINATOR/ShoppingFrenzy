using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingFrenzy
{
    public class Node
    {
        Edge[] edges = new Edge[4];
        bool discovered;
        int index;

        public Node()
        {
        }

        public Edge[] Edges { get => edges; set => edges = value; }
        public bool Discovered { get => discovered; set => discovered = value; }
        public int Index { get => index; set => index = value; }
    }
}
