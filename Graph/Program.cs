using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            //graph.AddNode("a");
            //graph.AddNode("b");
            //graph.AddNode("c");
            //graph.AddNode("d");
            //graph.AddNode("e");
            //graph.AddNode("f");
            //graph.AddNode("g");

            //graph.AddEdge("a", "b", 5);
            //graph.AddEdge("b", "c", 9);
            //graph.AddEdge("b", "e", 4);
            //graph.AddEdge("b", "f", 1);
            //graph.AddEdge("c", "d", 3);
            //graph.AddEdge("c", "f", 2);
            //graph.AddEdge("d", "f", 7);
            //graph.AddEdge("d", "e", 5);
            //graph.AddEdge("e", "f", 6);
            //graph.AddEdge("e", "g", 7);


            graph.AddNode("Hermannplatz");
            graph.AddNode("Alexanderplatz");
            graph.AddNode("Hauptbahnhof");
            graph.AddNode("Zoo");
            graph.AddNode("Wittenau");
            graph.AddNode("Rudow");
            graph.AddNode("Kochstraße");
            graph.AddNode("KottbuserTor");
            graph.AddNode("Wedding");
            graph.AddNode("Steglitz");
            graph.AddNode("Pankow");
            graph.AddNode("Tempelhpf");

            graph.AddEdge("Hermannplatz", "Zoo", 5);
            graph.AddEdge("Wittenau", "Alexanderplatz", 8);
            graph.AddEdge("Hermannplatz", "Alexanderplatz", 10);
            graph.AddEdge("Zoo", "Wittenau", 11);
            graph.AddEdge("Wedding", "Zoo", 4);
            graph.AddEdge("Wedding", "Tempelhpf", 3);
            graph.AddEdge("Wedding", "KottbuserTor", 7);
            graph.AddEdge("Wedding", "Steglitz", 7);
            graph.AddEdge("Steglitz", "Rudow", 4);
            graph.AddEdge("Tempelhpf", "Pankow", 8);
            graph.AddEdge("Wittenau", "Kochstraße", 2);
            //graph.AddEdge("Wittenau", "Tempelhpf", 4);
            graph.AddEdge("Kochstraße", "Hauptbahnhof", 15);


            // graph.DisplayAllNodes();

            // graph.NodesNextTo("Tempelhpf");


            var start = graph.Nodes.First(n => n.value == "Hermannplatz");
            var ziel = graph.Nodes.First(n => n.value == "Wittenau");
            var history = new List<Node>();
            var s = graph.SearchWaysRecursive(start, ziel, history);

            var count = 0;
            foreach (var solution in s)
            {              
                var ar = solution.ToArray();
                if (ar[0] == start)
                {
                    count++;
                    Console.WriteLine(" Weg :" + count);
                    foreach (var step in solution)
                    {
                        Console.WriteLine(step.value + "  ");                      
                    }
                    var cost = graph.WaysCosts(solution);
                    Console.WriteLine("Costs are :" + cost);
                }
            }
            //var history = new System.Collections.Generic.List<Node>
            //{
            //    start
            //};

            // graph.DFSListWay("Hermannplatz","Zoo");




            Console.ReadLine();
























            //if(!graph.RemoveNode("Zoo" ))// removeEdges: true))
            //{
            //    Console.WriteLine("Löschen ging nicht");
            //}



            //Console.WriteLine("--------------  NACH REMOVE ------------------");
            //graph.DisplayAllNodes();


            //var hermann = graph.Nodes.Find(t => t.Name == "Wedding");

            //Console.WriteLine(hermann.Edges.Exists(e => e.Start.Name == "Zoo"));
        }
    }
}
