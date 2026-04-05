#load "../../library/math/ModInt.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/6/NTL/1/NTL_1_B

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

long m = io.Long();
long n = io.Long();

ModInt<Mod1000000007> modint = m;
io.Print(modint.Power(n).Value);

Console.Out.Flush();