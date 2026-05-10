#load "../../library/graph/BellmannFord.csx"
#load "../../library/graph/DirectedGraph.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_1_B

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

int V = io.Int();
int E = io.Int();
int r = io.Int();

DirectedGraph<long> g = new(V);

for (int i = 0; i < E; i++)
{
    int s = io.Int();
    int t = io.Int();
    long d = io.Long();
    g.AddEdge(s, t, d);
}

long[] dist = g.BellmannFordFrom(r);

for (int i = 0; i < V; i++)
{
    if (dist[i] == long.MinValue)
    {
        io.Print("NEGATIVE CYCLE");
        Console.Out.Flush();
        return;
    }
}

for (int i = 0; i < V; i++)
{
    if (dist[i] == long.MaxValue)
        io.Print("INF");
    else
        io.Print(dist[i]);
}

Console.Out.Flush();