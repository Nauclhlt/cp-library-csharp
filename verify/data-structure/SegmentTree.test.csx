#load "../../library/data-structure/SegmentTree.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.yosupo.jp/problem/point_add_range_sum

global using System.Runtime.CompilerServices;

CPIO io = new();

int N = io.Int();
int Q = io.Int();

var seg = new SegmentTree<long>(N, (x, y) => x + y, (x, y) => x + y, 0L);
long[] arr = io.LongArray(N);
seg.Build(arr);

while (Q-- > 0)
{
    int t = io.Int();

    if (t == 0)
    {
        int p = io.Int();
        long x = io.Long();
        seg.Update(p, x);
    }
    else
    {
        int l = io.Int();
        int r = io.Int();
        io.Print(seg.Fold(l, r));
    }
}

Console.Out.Flush();