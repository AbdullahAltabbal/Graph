using System;
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

            //graph.AddEdge("a", "b", 5);
            //graph.AddEdge("b", "c", 8);
            //graph.AddEdge("b", "e", 8);
            //graph.AddEdge("b", "f", 8);
            //graph.AddEdge("c", "d", 8);
            //graph.AddEdge("c", "f", 8);
            //graph.AddEdge("d", "f", 8);
            //graph.AddEdge("d", "e", 8);
            //graph.AddEdge("e", "f", 8);


            //graph.AddNode("Hermannplatz");
            //graph.AddNode("Alexanderplatz");
            //graph.AddNode("Hauptbahnhof");
            //graph.AddNode("Zoo");
            //graph.AddNode("Wittenau");
            //graph.AddNode("Rudow");
            //graph.AddNode("Kochstraße");
            //graph.AddNode("KottbuserTor");
            //graph.AddNode("Wedding");
            //graph.AddNode("Steglitz");
            //graph.AddNode("Pankow");
            //graph.AddNode("Tempelhpf");
            //graph.AddNode("Vincent");

            //graph.AddEdge("Hermannplatz", "Zoo", 5);
            //graph.AddEdge("Wittenau", "Alexanderplatz", 8);
            //graph.AddEdge("Hermannplatz", "Alexanderplatz", 10);
            //graph.AddEdge("Zoo", "Wittenau", 11);
            //graph.AddEdge("Wedding", "Zoo", 4);
            //graph.AddEdge("Wedding", "Tempelhpf", 3);
            //graph.AddEdge("Wedding", "KottbuserTor", 7);
            //graph.AddEdge("Wedding", "Steglitz", 7);
            //graph.AddEdge("Steglitz", "Rudow", 4);
            //graph.AddEdge("Tempelhpf", "Pankow", 8);
            //graph.AddEdge("Wittenau", "Kochstraße", 2);
            //graph.AddEdge("Kochstraße", "Hauptbahnhof", 15);




            graph.AddNode("E");
            graph.AddNode("B");
            graph.AddNode("D");
            graph.AddNode("F");
            graph.AddNode("H");
            graph.AddNode("C");
            graph.AddNode("G");
            graph.AddNode("A");
            graph.AddNode("L");
            graph.AddNode("Z");
            graph.AddNode("K");
            graph.AddNode("Q");
            graph.AddEdge("B", "E", 3);
            graph.AddEdge("E", "F", 1);
            graph.AddEdge("D", "E", 5);
            graph.AddEdge("D", "C", 4);
            graph.AddEdge("C", "A", 2);
            graph.AddEdge("D", "G", 1);
            graph.AddEdge("E", "H", 7);
            graph.AddEdge("H", "G", 5);
            graph.AddEdge("H", "K", 4);
            graph.AddEdge("Q", "K", 2);
            graph.AddEdge("K", "Z", 1);
            graph.AddEdge("Z", "G", 3);






            // graph.DisplayAllNodes();

            // graph.NodesNextTo("Tempelhpf");


            var start = graph.Nodes.First(n => n.value == "E");
            var ziel = graph.Nodes.First(n => n.value == "Z");
            graph.GangAlgo(start, ziel);
            //var history = new System.Collections.Generic.List<Node>
            //{
            //    start
            //};

            // graph.DFSListWay("Hermannplatz","Zoo");


            //foreach (var solution in s)
            //{
            //    foreach (var step in solution)
            //    {
            //        Console.Write(step.value);
            //    }
            //    Console.WriteLine("-----------");
            //}            

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
