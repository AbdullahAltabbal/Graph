using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Graph
{
    public class Graph
    {
        public List<Node> Nodes { get; set; } = new List<Node>();

        public Graph()
        {
            Nodes = new List<Node>();
        }
        public void AddNode(string cityName)
        {
            Nodes.Add(new Node { Name = cityName });
        }
        public void AddEdge(string station1, string station2, int costs)
        {
            var c1 = Nodes.Find(t => t.Name == station1);
            var c2 = Nodes.Find(t => t.Name == station2);

            if (c1 != null && c2 != null)
            {
                var edge = new Edge
                {
                    Start = c1,
                    Costs = costs,
                    Dest = c2
                };

                c1.Edges.Add(edge);
                c2.Edges.Add(edge);
                return;
            }
            throw new Exception("there is NO Node with this name! ");
        }
        public void DisplayAllNodes()
        {
            var count = 0;
            foreach (var nod in Nodes)
            {
                if (nod.Edges.Count() != 0)
                {
                    count++;
                    Console.WriteLine($" Nod #{count}: {nod.Name}");
                }
            }
            Console.WriteLine($"Number of Nodes : {count}");
        }
        public bool RemoveNode(string station, bool removeEdges = false)
        {
            if (!Exists(station))
            {
                Console.WriteLine("there is no station with this name!");
                return false;
            } 

            foreach (var nod in Nodes)
            {
                if (nod.Name != station)
                    continue;

                if (nod.Edges.Count() != 0 && !removeEdges)
                    continue;

                foreach (var edge in nod.Edges.ToArray())
                    RemoveEdges(edge);

                Nodes.Remove(nod);
                return true;
            }
            return false;
        }
        private void RemoveEdges(Edge edge)
        {
            edge.Start.Edges.Remove(edge);
            edge.Dest.Edges.Remove(edge);
        }

        public bool NodesNextTo(string station)
        {
            if (!Exists(station))
            {
                Console.WriteLine("there is no station with this name!");
                return false;
            }
            foreach (var nod in Nodes)
            {
                if (nod.Name == station)
                {
                    if (nod.Edges.Count() != 0)
                    {
                        var numOfEdges = nod.Edges.Count();
                        List<Node> edges = new List<Node>(numOfEdges);
                        foreach (var edge in nod.Edges)
                        {
                            Console.WriteLine($"from {edge.Start.Name} to {edge.Dest.Name} there is a way and cost {edge.Costs}");
                        }
                    }
                    else
                    Console.WriteLine("The station is in nowhere!");
                }
            }
            return true;
        }
        public bool Exists(string station)
        {
            foreach (var nod in Nodes)
            {
                if (station == nod.Name)
                    return true;
            }
            return false;
        }
    }
}