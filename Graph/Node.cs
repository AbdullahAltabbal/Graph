using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Node
    {
        public string value;
        public List<Edge> Edges { get; set; }
        public Node()
        {
            Edges = new List<Edge>();
        }
    }
}
