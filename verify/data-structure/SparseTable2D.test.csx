#load "../../library/data-structure/SparseTable2D.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=1068

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

while (true)
{

    int R = io.Int();
    int C = io.Int();
    int Q = io.Int();

    if (R == 0) break;

    int[,] grid = new int[R, C];
    for (int y = 0; y < R; y++)
    {
        int[] row = io.IntArray(C);
        for (int x = 0; x < C; x++)
        {
            grid[y, x] = row[x];
        }
    }

    SparseTable2D<int> st = new(grid, int.MaxValue, int.Min);

    for (int i = 0; i < Q; i++)
    {
        int r1 = io.Int();
        int c1 = io.Int();
        int r2 = io.Int() + 1;
        int c2 = io.Int() + 1;

        io.Print(st.Fold(c1, r1, c2, r2));
    }

    Console.Out.Flush();
}
