#load "../../library/graph/TreeDiameter.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_2_A

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

int N = io.Int();

Graph<long> g = new(N);

for (int i = 0; i < N - 1; i++)
{
    int s = io.Int();
    int t = io.Int();
    long w = io.Long();

    g.AddEdge(s, t, w);
}

io.Print(g.GetDiameter());

Console.Out.Flush();