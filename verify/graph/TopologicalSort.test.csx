#load "../../library/graph/TopologicalSort.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_4_B

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

int V = io.Int();
int E = io.Int();

DirectedGraph<int> g = new(V);

for (int i = 0; i < E; i++)
{
    int s = io.Int();
    int t = io.Int();

    g.AddEdge(s, t, 0);
}

g.TryTopologicalSort(out List<int> sorted);

for (int i = 0; i < V; i++)
{
    io.Print(sorted[i]);
}

Console.Out.Flush();