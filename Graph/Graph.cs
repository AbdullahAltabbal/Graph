using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Graph
{
    public class Graph
    {
        HashSet<Node> visited = new HashSet<Node>();
        Stack<Node> stack = new Stack<Node>();

        public List<List<Node>> solutions = new List<List<Node>>();
        public List<Node> Nodes { get; set; } = new List<Node>();
        public Graph()
        {
            Nodes = new List<Node>();
        }
        public void AddNode(string cityName)
        {
            Nodes.Add(new Node { value = cityName });
        }
        public void AddEdge(string firstPosition, string secounPosition, int costs)
        {
            var c1 = Nodes.Find(t => t.value == firstPosition);
            var c2 = Nodes.Find(t => t.value == secounPosition);

            if (c1 != null && c2 != null && c1 != c2)
            {
                var edge = new Edge
                {
                    FirstPosition = c1,
                    Costs = costs,
                    SecondPosition = c2
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
                    Console.WriteLine($" Nod #{count}: {nod.value}");
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
                if (nod.value != station)
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
            edge.FirstPosition.Edges.Remove(edge);
            edge.SecondPosition.Edges.Remove(edge);
        }
        public bool NodesNextToDisplay(string station)
        {
            if (!Exists(station))
            {
                Console.WriteLine("there is no station with this name! ");
                return false;
            }
            foreach (var nod in Nodes)
            {
                if (nod.value == station)
                {
                    if (nod.Edges.Count() != 0)
                    {
                        var numOfEdges = nod.Edges.Count();
                        List<Node> edges = new List<Node>(numOfEdges);
                        foreach (var edge in nod.Edges)
                        {
                            Console.WriteLine($"from {edge.FirstPosition.value} to {edge.SecondPosition.value} there is a way and cost {edge.Costs}");
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
                if (station == nod.value)
                    return true;
            }
            return false;
        }
        public List<Node> FindNeighbour(string startnode)
        {
            List<Node> neighbourlist = new List<Node>();
            Node startknoten = null;
            foreach (var node in Nodes)
            {
                if (node.value == startnode)
                {
                    startknoten = node;
                }
            }
            if (startknoten != null)
            {
                foreach (var kante in startknoten.Edges)
                {
                    if (kante.FirstPosition == startknoten)
                        neighbourlist.Add(kante.SecondPosition);
                    else
                        neighbourlist.Add(kante.FirstPosition);
                }
            }
            else
            {
                Console.WriteLine("Der Knoten existiert nicht");
            }
            return neighbourlist;
        }

        // Johannas Code
        //public List<List<Node>> DFS(Node start, Node Ziel, List<Node> history)
        //{
        //    //Console.WriteLine(start.value + " " + history.Count());
        //    var newHistory = new List<Node>(history);
        //    HashSet<Node> visited = new HashSet<Node>();

        //    visited.Add(start);

        //    var neighborNodes = start.Edges
        //        .Select(e => e.SecondPosition)
        //        .Where(e=> !history.Contains(e))
        //        .Where(e => !visited.Contains(e))
        //        .ToList();

        //    neighborNodes.AddRange(start.Edges
        //        .Select(e => e.FirstPosition)
        //        .Where(e => !history.Contains(e))
        //        .Where(e => !visited.Contains(e))
        //        .Where(e => !neighborNodes.Contains(e))
        //        .ToArray());

        //    foreach (var neighbor in neighborNodes)
        //    {
        //        newHistory.Add(neighbor);

        //        if (neighbor == Ziel)
        //        {
        //            if (!solutions.Any(s => s.SequenceEqual(newHistory)))
        //                solutions.Add(newHistory);
        //            return solutions;
        //        }                
        //        solutions.AddRange(DFS(neighbor, Ziel, newHistory));
        //    }
        //    return solutions;
        //}



        // Jens & Vincent Code
        //public void DFSListWay(string startpoint, string target)
        //{
        //    var startNode = Nodes.First(Node => Node.value == startpoint);
        //    var ways = new List<List<Node>> { new List<Node> { startNode } };
        //    var newWays = ways;
        //    bool newWayFound = true;
        //    while (newWayFound)
        //    {
        //        newWays = newWays.SelectMany(w => GetNewWays(w)).ToList();
        //        newWayFound = newWays.Any();
        //        ways.AddRange(newWays);
        //    }
        //    var result = ways.Where(w => w.Last().value == target).ToArray();
        //}
        //public List<List<Node>> GetNewWays(List<Node> way)
        //{
        //    var ways = new List<List<Node>>();
        //    var startNode = way.Last();
        //    var otherNode = startNode.Edges
        //        .Select(k => k.FirstPosition)
        //        .Concat(startNode.Edges.Select(k => k.SecondPosition))
        //        .Distinct()
        //        .Where(k => !way.Contains(k))
        //        .ToArray();

        //    foreach (var Node in otherNode)
        //    {
        //        var newWay = way.ToList();
        //        newWay.Add(Node);
        //        ways.Add(newWay);

        //    }
        //    return ways;
        //}

        //public List<List<Node>> DFSRecursive(Node start, Node Ziel)
        //{
        //    HashSet<Node> visited = new HashSet<Node>();
        //    stack.Push(start);
        //    while (stack.Count > 0)
        //    {
        //        var node = stack.Peek();
        //        visited.Add(node);

        //        var neighborNodes = node.Edges
        //          .Select(e => e.SecondPosition)
        //          .Where(e => !stack.Contains(e))
        //          .Where(e => !visited.Contains(e))
        //          .ToList();

        //        neighborNodes.AddRange(node.Edges
        //            .Select(e => e.FirstPosition)
        //            .Where(e => !stack.Contains(e))
        //            .Where(e => !visited.Contains(e))
        //            .Where(e => !neighborNodes.Contains(e))
        //            .ToArray());

        //        if (neighborNodes.Count == 0)
        //            stack.Pop();

        //        foreach (var neighbor in neighborNodes)
        //        {
        //            if (neighbor == Ziel)
        //            {
        //                stack.Push(neighbor);
        //                var solution = stack.ToList();
        //                if (!solutions.Any(s => s.SequenceEqual(solution)))
        //                    solutions.Add(solution);
        //                else
        //                    visited.Add(neighbor);

        //                stack.Pop();
        //            }               
        //        }
        //    }
        //    return solutions;
        //}
        public List<List<Node>> GangAlgo(Node start, Node target)
        {
            List<Node> temp = new List<Node>();
            stack.Push(start);
            Node current = start;
            while (stack.Count > 0)
            {
                var tempNachbar = nachBaren(current);

                while (tempNachbar.Count != 0)
                {
                    current = tempNachbar.Where(n => !temp.Contains(n)).ToArray()[0];
                    stack.Push(current);
                    if (current == target)
                    {
                        if (!listExistiert(stack.ToList()))
                            solutions.Add(stack.ToList());
                        stack.Pop();
                        current = stack.Peek();
                        while (tempNachbar.Count == 1) // statt nur wenn ein nachfolgender nachbar besteht müssen wir den buchstaben so oft ins temp reinschreiben wie er nachbarn hat und darauf überprüfen 
                        {
                            if (tempNachbar.Count == 1)
                            {
                                temp.Add(current);
                                stack.Pop();
                                current = stack.Peek();
                                tempNachbar = nachBaren(current);
                            }                           
                        }
                        break;
                    }                
                   tempNachbar = nachBaren(current);
                }
                if (tempNachbar.Count == 0)
                {
                    stack.Pop();
                    visited.Add(current);
                    current = stack.Peek();
                }
            }
            return solutions;
        }
        public List<Node> nachBaren(Node aktuell)
        {
            var tempnachbarn = FindNeighbour(aktuell.value)
                              .Where(e => !stack.Contains(e))
                              .Where(e => !visited.Contains(e))
                              .ToList();

            return tempnachbarn;
        }
        public bool listExistiert(List<Node> zuPrüfen)
        {
            var _zuPrüfen = zuPrüfen.ToArray();

            if (solutions.Count == 0)
            {
                return false;
            }

            foreach (var lösung in solutions)
            {
                var _lösung = lösung.ToArray();

                for (int i = 0; i < zuPrüfen.Count; i++)
                {
                    if (_zuPrüfen[i] == _lösung[i])
                    {
                        if (i == zuPrüfen.Count -1)
                            return true;                        
                    }
                    else
                        break;
                }
            }
            return false;
        }
    }
}