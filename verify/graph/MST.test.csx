#load "../../library/graph/MST.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_2_A

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

int V = io.Int();
int E = io.Int();

Graph<long> g = new(V);

for (int i = 0; i < E; i++)
{
    int s = io.Int();
    int t = io.Int();
    long w = io.Long();

    g.AddEdge(s, t, w);
}

io.Print(g.MinSpanningTreeWeight());

Console.Out.Flush();