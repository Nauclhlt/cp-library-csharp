#load "../../library/graph/WarshallFloyd.csx"
#load "../../library/graph/GraphBase.csx"
#load "../../library/graph/DirectedGraph.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_1_C

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

int V = io.Int();
int E = io.Int();

DirectedGraph<long> g = new(V);

for (int i = 0; i < E; i++)
{
    int s = io.Int();
    int t = io.Int();
    long d = io.Long();

    g.AddEdge(s, t, d);
}

long[,] dist = g.WarshallFloyd();

for (int i = 0; i < V; i++)
{
    if (dist[i, i] < 0L)
    {
        io.Print("NEGATIVE CYCLE");
        Console.Out.Flush();
        return;
    }
}

for (int i = 0; i < V; i++)
{
    for (int j = 0; j < V; j++)
    {
        if (j > 0) Console.Write(" ");
        if (dist[i, j] == long.MaxValue)
        {
            Console.Write("INF");
        }
        else
        {
            Console.Write(dist[i, j]);
        }
    }
    Console.WriteLine();
}

Console.Out.Flush();