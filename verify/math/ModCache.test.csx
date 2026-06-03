#load "../../library/math/ModCache.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://yukicoder.me/problems/no/3146

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

ModCache<Mod998244353> cache = new(1000050);

CPIO io = new();

int T = io.Int();

List<ModInt<Mod998244353>> ans = new() {0};
ModInt<Mod998244353> sum = 0;
ModInt<Mod998244353> catalan = 0;

while (T-- > 0)
{
    int N = io.Int();
    if (N % 2 == 1) io.Print("0");
    else
    {
        N /= 2;

        while (ans.Count <= N)
        {
            ModInt<Mod998244353> next = 3L * sum + catalan;
            
            ans.Add(next);
            sum += next;
            int x = ans.Count - 1;
            ModInt<Mod998244353> c = cache.Factorial(2 * x) * cache.InverseFactorial(x) * cache.InverseFactorial(x) * cache.Inverse(x + 1);
            
            catalan += c;
        }

        io.Print(ans[N].ValueLong);
    }
}

Console.Out.Flush();