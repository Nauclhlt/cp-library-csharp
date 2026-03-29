#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.yosupo.jp/problem/many_aplusb

global using System.Runtime.CompilerServices;

CPIO io = new();

int T = io.Int();

while (T-- > 0)
{
    long A = io.Long();
    long B = io.Long();

    io.Print(A + B);
}

Console.Out.Flush();