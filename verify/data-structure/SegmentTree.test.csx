#load "../../library/data-structure/SegmentTree.csx"
// verification-helper: PROBLEM https://judge.yosupo.jp/problem/point_add_range_sum


string[] nq = Console.ReadLine().Split();
int N = int.Parse(nq[0]);
int Q = int.Parse(nq[1]);

var seg = new SegmentTree<long>(N, (x, y) => x + y, (x, y) => x + y, 0L);

long[] arr = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();
seg.Build(arr);

while (Q-- > 0)
{
    var q = Console.ReadLine().Split();
    int t = int.Parse(q[0]);

    if (t == 0)
    {
        int p = int.Parse(q[1]);
        int x = int.Parse(q[2]);
        seg.Update(p, x);
    }
    else
    {
        int l = int.Parse(q[1]);
        int r = int.Parse(q[2]);
        Console.WriteLine(seg.Fold(l, r));
    }
}