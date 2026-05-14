#load "../../library/math/SquareMatrix.csx"
#load "../../library/math/ModInt.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://yukicoder.me/problems/no/1340

global using System.Collections;
global using System.Runtime.CompilerServices;
global using System.Numerics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;

CPIO io = new();

int N = io.Int();
int M = io.Int();
long T = io.Long();

SquareMatrix<ANDOR> mat = SquareMatrix<ANDOR>.Zero(N);

for (int i = 0; i < M; i++)
{
    int a = io.Int();
    int b = io.Int();

    mat[b, a] = new(1);
}

SquareMatrix<ANDOR> power = mat.Power(T);

int ans = 0;
for (int i = 0; i < N; i++)
{
    if (power[i, 0].Value == 1) ans++;
}

io.Print(ans);

Console.Out.Flush();

public struct ANDOR : IAdditionOperators<ANDOR, ANDOR, ANDOR>, IMultiplyOperators<ANDOR, ANDOR, ANDOR>, IAdditiveIdentity<ANDOR, ANDOR>, IMultiplicativeIdentity<ANDOR, ANDOR>, IEqualityOperators<ANDOR, ANDOR, bool>
{
    public static ANDOR AdditiveIdentity => new(0);
    public static ANDOR MultiplicativeIdentity => new(1);


    public long Value;

    public ANDOR(long v)
    {
        Value = v;
    }

    public static ANDOR operator +(ANDOR a, ANDOR b)
    {
        return new(a.Value | b.Value);
    }

    public static ANDOR operator *(ANDOR a, ANDOR b)
    {
        return new ANDOR(a.Value & b.Value);
    }

    public static bool operator ==(ANDOR a, ANDOR b) => a.Value == b.Value;
    public static bool operator !=(ANDOR a, ANDOR b) => a.Value != b.Value;

    public override bool Equals([NotNullWhen(true)] object obj)
    {
        if (obj is ANDOR m) return this == m;
        else return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}