#load "../../library/utility/CPIO.csx"
#load "../../library/data-structure/UnionFind.csx"
// verification-helper: PROBLEM https://judge.yosupo.jp/problem/unionfind

global using System.Runtime.CompilerServices;

CPIO io = new();

int N = io.Int();
int Q = io.Int();

UnionFind uf = new(Q);

while (Q-- > 0)
{
    int t = io.Int();
    int u = io.Int();
    int v = io.Int();

    if (t == 0)
    {
        uf.Unite(u, v);
    }
    else if (t == 1)
    {
        if (uf.Same(u, v)) io.Print(1);
        else io.Print(0);
    }
}

Console.Out.Flush();