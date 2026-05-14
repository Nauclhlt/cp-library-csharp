#load "../../library/math/Eratosthenes.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_D

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

int a = io.Int();
int b = io.Int();
int c = io.Int();

Eratosthenes e = new(c + 100);

List<int> div = e.GetDivisors(c);

int ans = 0;
for (int i = 0; i < div.Count; i++)
{
    if (a <= div[i] && div[i] <= b)
    {
        ans++;
    }
}

io.Print(ans);

Console.Out.Flush();