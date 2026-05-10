#load "../../library/data-structure/CirnoArray.csx"
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


MINT[] arr = new MINT[N];
for (int i = 0; i < N; i++) arr[i] = io.Long();

CirnoArray<MINT> cirno = new(arr);

while (Q-- > 0)
{
    int t = io.Int();

    if (t == 0)
    {
        int l = io.Int();
        int r = io.Int();
        long b = io.Long();
        long c = io.Long();
        cirno.Multiply(l, r, b);
        cirno.Add(l, r, c);
    }
    else
    {
        int l = io.Int();
        int r = io.Int();
        io.Print(cirno.Sum(l, r).Value.ToString());
    }
}

Console.Out.Flush();