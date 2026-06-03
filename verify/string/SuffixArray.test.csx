#load "../../library/string/SuffixArray.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://yukicoder.me/problems/no/430

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

string S = io.String();
int M = io.Int();
string[] C = io.StringArray(M);

SuffixArray sa = new(S);
long ans = 0;
for (int i = 0; i < M; i++)
{
    ans += sa.CountOf(C[i]);
}

io.Print(ans);

Console.Out.Flush();