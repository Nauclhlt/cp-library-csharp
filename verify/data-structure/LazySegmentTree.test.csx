#load "../../library/data-structure/LazySegmentTree.csx"
#load "../../library/utility/CPIO.csx"
#load "../../library/math/ModInt.csx"
// verification-helper: PROBLEM https://judge.yosupo.jp/problem/range_affine_range_sum

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;
using MINT = ModInt<Mod998244353>;

CPIO io = new();

int N = io.Int();
int Q = io.Int();

var seg = new LazySegmentTree<MINT, (MINT b, MINT c)>(N, (x, y) => x + y, (x, a, l) => x * a.b + l * a.c, (x, y) => (x.b * y.c, y.b * x.c + y.c), 0L);
MINT[] arr = new MINT[N];
for (int i = 0; i < N; i++) arr[i] = io.Long();
seg.Build(arr);

while (Q-- > 0)
{
    int t = io.Int();

    if (t == 0)
    {
        int l = io.Int();
        int r = io.Int();
        long b = io.Long();
        long c = io.Long();
        seg.Update(l, r, (b, c));
    }
    else
    {
        int l = io.Int();
        int r = io.Int();
        io.Print(seg.Fold(l, r).Value.ToString());
    }
}

Console.Out.Flush();