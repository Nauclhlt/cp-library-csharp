#load "../../library/data-structure/Set.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.yosupo.jp/problem/ordered_set

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

int N = io.Int();
int Q = io.Int();

Set<long> set = new();

if (N > 0)
{
    long[] a = io.LongArray(N);
    for (int i = 0; i < N; i++) set.Add(a[i]);
}
else
{
    Console.ReadLine();
}

for (int i = 0; i < Q; i++)
{
    int t = io.Int();
    long x = io.Long();

    if (t == 0)
    {
        if (!set.Contains(x)) set.Add(x);
    }
    else if (t == 1)
    {
        if (set.Contains(x)) set.Remove(x);
    }
    else if (t == 2)
    {
        x--;
        if (0 <= x && x < set.Count)
        {
            io.Print(set.GetByIndex((int)x));
        }
        else
        {
            io.Print(-1);
        }
    }
    else if (t == 3)
    {
        io.Print(set.LowerBound(x + 1));
    }
    else if (t == 4)
    {
        int p = set.LowerBound(x + 1);
        p--;
        if (0 <= p && p < set.Count)
        {
            io.Print(set.GetByIndex(p));
        }
        else
        {
            io.Print(-1);
        }
    }
    else if (t == 5)
    {
        int p = set.LowerBound(x);
        if (0 <= p && p < set.Count)
        {
            io.Print(set.GetByIndex(p));
        }
        else
        {
            io.Print(-1);
        }
    }
}

Console.Out.Flush();