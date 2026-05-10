#load "../../library/graph/SCC.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.yosupo.jp/problem/scc

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

int N = io.Int();
int M = io.Int();

DirectedGraph<int> g = new(N);

for (int i = 0; i < M; i++)
{
    int a = io.Int();
    int b = io.Int();

    g.AddEdge(a, b, 0);
}

List<List<int>> scc = g.DivideSCC();
io.Print(scc.Count);
for (int i = 0; i < scc.Count; i++)
{
    Console.Write(scc[i].Count + " ");
    io.Print(scc[i]);
}

Console.Out.Flush();