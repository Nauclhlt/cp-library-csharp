#load "../../library/data-structure/FenwickTree.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.yosupo.jp/problem/point_add_range_sum

global using System.Runtime.CompilerServices;

CPIO io = new();

int N = io.Int();
int Q = io.Int();

FenwickTree<long> ft = new(N);
long[] arr = io.LongArray(N);
ft.Build(arr);

while (Q-- > 0)
{
    int t = io.Int();

    if (t == 0)
    {
        int p = io.Int();
        long x = io.Long();
        ft.Add(p, x);
    }
    else
    {
        int l = io.Int();
        int r = io.Int();
        io.Print(ft.Sum(l, r));
    }
}

Console.Out.Flush();