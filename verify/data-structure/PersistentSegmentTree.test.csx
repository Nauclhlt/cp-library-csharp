#load "../../library/data-structure/PersistentSegmentTree.csx"
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

long[] values = A.Distinct().Order().ToArray();
Dictionary<long, int> valueToIndex = new();
for (int i = 0; i < values.Length; i++)
{
    valueToIndex[values[i]] = i;
}

int[] times = new int[values.Length];
List<int>[] indices = new List<int>[values.Length];
for (int i = 0; i < values.Length; i++) indices[i] = new();

for (int i = 0; i < N; i++)
{
    int idx = valueToIndex[A[i]];
    indices[idx].Add(i);
}

PersistentSegmentTree<int> seg = new(N, (x, y) => x + y, (x, a) => x + a, 0);

int init = seg.Fill(0);

for (int i = 0; i < values.Length; i++)
{
    int prev = -1;
    if (i == 0) prev = init;
    else prev = times[i - 1];

    for (int j = 0; j < indices[i].Count; j++)
    {
        prev = seg.Update(prev, indices[i][j], 1);
    }

    times[i] = prev;
}

while (Q-- > 0)
{
    int l = io.Int();
    int r = io.Int();
    int k = io.Int();

    int left = 0;
    int right = values.Length;
    while (right > left)
    {
        int mid = left + (right - left) / 2;

        int c = seg.Fold(times[mid], l, r);
        if (c <= k)
        {
            left = mid + 1;
        }
        else
        {
            right = mid;
        }
    }

    io.Print(values[left]);
}

Console.Out.Flush();