using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g1 = new Graph();
            g1.AdjInput(false);
            g1.IncInput();
            g1.Dfs();
            g1.Bfs();
            g1.Dijkstra();
        }
    }
}
