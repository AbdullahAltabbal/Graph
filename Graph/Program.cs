using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
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
            graph.AddNode("Vincent");
            


            graph.AddEdge("Hermannplatz", "Zoo", 5);
            graph.AddEdge("Zoo", "Wedding", 4);
            graph.AddEdge("Wedding", "Tempelhpf", 3);
            graph.AddEdge("Wedding", "KottbuserTor", 7);
            graph.AddEdge("Wedding", "Steglitz", 7);
            graph.AddEdge("Steglitz", "Rudow", 4);
            graph.AddEdge("Tempelhpf", "Pankow", 8);
            graph.AddEdge("Zoo", "Wittenau", 11);
            graph.AddEdge("Wittenau", "Alexanderplatz", 8);
            graph.AddEdge("Wittenau", "Kochstraße", 2);
            graph.AddEdge("Kochstraße", "Hauptbahnhof", 15);


            // graph.DisplayAllNodes();

            graph.NodesNextTo("Tempelhpf");

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
