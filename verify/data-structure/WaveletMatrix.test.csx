#load "../../library/data-structure/WaveletMatrix.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.yosupo.jp/problem/range_kth_smallest

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

int N = io.Int();
int Q = io.Int();
long[] A = io.LongArray(N);

WaveletMatrix wm = new(A);

while (Q-- > 0)
{
    int l = io.Int();
    int r = io.Int();
    int k = io.Int();

    io.Print(wm.Quantile(l, r, k));
}

Console.Out.Flush();