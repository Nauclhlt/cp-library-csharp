#load "../../library/data-structure/SparseTable.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.yosupo.jp/problem/staticrmq

global using System.Runtime.CompilerServices;

CPIO io = new();

int N = io.Int();
int Q = io.Int();

long[] a = io.LongArray(N);

SparseTable<long> table = new(a, long.MaxValue, long.Min);

while (Q-- > 0)
{
    int l = io.Int();
    int r = io.Int();

    io.Print(table.Fold(l, r));
}

Console.Out.Flush();