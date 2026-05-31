#load "../../library/graph/EulerTour.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_5_C

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

int N = io.Int();

Graph<int> g = new(N);

for (int i = 0; i < N; i++)
{
    int k = io.Int();
    for (int j = 0; j < k; j++)
    {
        int c = io.Int();
        g.AddEdge(i, c, 1);
    }
}

var et = g.ConstructEulerTour<int>(root: 0);

int Q = io.Int();

for (int i = 0; i < Q; i++)
{
    int u = io.Int();
    int v = io.Int();

    io.Print(et.Lca(u, v));
}

Console.Out.Flush();