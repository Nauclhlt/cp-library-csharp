#load "ModInt.csx"

/// <summary>
/// Pre-calculation utility class for modint.
/// </summary>
public sealed class ModCache<T> where T : struct, IMod
{
    private ModInt<T>[] _factorial;
    private ModInt<T>[] _inverseFactorial;
    private ModInt<T>[] _inverse;

    /// <summary>
    /// Calculates factorials, inverse factorials, and inverses for all numbers from 1 to n. Time complexity is O(n).
    /// </summary>
    public ModCache(long n)
    {
        _factorial = new ModInt<T>[n + 1];
        _inverseFactorial = new ModInt<T>[n + 1];

        _factorial[0] = 1;
        _inverseFactorial[0] = ModInt<T>.One;

        _inverse = new ModInt<T>[n + 1];
        _inverse[1] = ModInt<T>.CreateFast(1);

        for (long p = 1; p <= n; p++)
        {
            _factorial[p] = _factorial[p - 1] * p;
            if (p > 1)
            {
                _inverse[p] = -(ModInt<T>.Mod / p) * _inverse[ModInt<T>.Mod % p];
            }
            _inverseFactorial[p] = _inverseFactorial[p - 1] * _inverse[p];
        }
    }

    /// <summary>
    /// Returns binom(n, r). Note that if r < 0, r > n, or n <= 0, this function returns 0. Time complexity is O(1).
    /// </summary>
    public ModInt<T> Combination(long n, long r)
    {
        if (r < 0 || r > n || n <= 0) return 0;
        return _factorial[n] * (_inverseFactorial[n - r] * _inverseFactorial[r]);
    }

    /// <summary>
    /// Returns nPr. Note that if r < 0, r > n, or n <= 0, this function returns 0. Time complexity is O(1).
    /// </summary>
    public ModInt<T> Permutation(long n, long r)
    {
        if (r < 0 || r > n || n <= 0) return 1;
        return _factorial[n] * _inverseFactorial[n - r];
    }

    /// <summary>
    /// Returns n!. Time complexity is O(1).
    /// </summary>
    public ModInt<T> Factorial(long n)
    {
        Debug.Assert(0 <= n && n < _factorial.Length);
        return _factorial[n];
    }

    /// <summary>
    /// Returns (n!)^-1. Time complexity is O(1).
    /// </summary>
    public ModInt<T> InverseFactorial(int n)
    {
        Debug.Assert(0 <= n && n < _inverseFactorial.Length);
        return _inverseFactorial[n];
    }

    /// <summary>
    /// Returns n^-1. Time complexity is O(1).
    /// </summary>
    public ModInt<T> Inverse(long n)
    {
        Debug.Assert(0 <= n && n < _inverse.Length);
        return _inverse[n];
    }
}