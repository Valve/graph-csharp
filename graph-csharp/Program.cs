
using System;
using System.IO;

namespace graph_csharp {
    class Program {
        static void Main(string[] args) {
            Graph g = new Graph(9);
            g.AddEdge(0, 1);
            g.AddEdge(0, 3);
            g.AddEdge(1, 2);
            g.AddEdge(1, 4);
            g.AddEdge(2, 5);
            g.AddEdge(3, 4);
            g.AddEdge(3, 6);
            g.AddEdge(4, 5);
            g.AddEdge(4, 7);
            g.AddEdge(5, 8);
            g.AddEdge(6, 7);
            g.AddEdge(7, 8);
            var p = new BFSPaths(g, 0);
            p.PathTo(8);
        }
    }
}
