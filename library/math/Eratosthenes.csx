/// <summary>
/// Sieve of Eratosthenes.
/// </summary>
public sealed class Eratosthenes
{
    private bool[] _isPrime;
    private int[] _minFactor;
    private int[] _mobius;
    private int _n;

    /// <summary>
    /// Initializes new instance. Time complexity is O(nloglogn);
    /// </summary>
    public Eratosthenes(int n)
    {
        _n = n;

        _isPrime = new bool[n + 1];
        _minFactor = new int[n + 1];
        _mobius = new int[n + 1];

        Array.Fill(_isPrime, true);
        Array.Fill(_minFactor, -1);
        Array.Fill(_mobius, 1);

        _isPrime[1] = false;
        _minFactor[1] = 1;

        for (int i = 2; i <= _n; i++)
        {
            if (!_isPrime[i]) continue;

            _minFactor[i] = i;
            _mobius[i] = -1;

            for (int j = i + i; j <= _n; j += i)
            {
                _isPrime[j] = false;

                if (_minFactor[j] == -1) _minFactor[j] = i;
                if (j / i % i == 0) _mobius[j] = 0;
                else _mobius[j] = -_mobius[j];
            }
        }
    }

    /// <summary>
    /// Returns the prime factorization of n. Time complexity is O(logn).
    /// </summary>
    public List<(int, int)> PrimeFactorize(int n)
    {
        if (n > _n) throw new InvalidOperationException();
        List<(int, int)> result = new();
        while (_minFactor[n] != 1)
        {
            int p = _minFactor[n];
            int c = 0;
            while (n % p == 0)
            {
                n /= p;
                c++;
            }

            result.Add((p, c));
        }

        return result;
    }

    /// <summary>
    /// Enumerates all divisors of n. Time complexity is O(logn + d(n)). (d is divisor function)
    /// </summary>
    public List<int> GetDivisors(int n)
    {
        if (n > _n) throw new InvalidOperationException();
        List<int> divs = new();
        var factors = PrimeFactorize(n);

        divs.Add(1);

        for (int i = 0; i < factors.Count; i++)
        {
            int len = divs.Count;
            for (int j = 0; j < len; j++)
            {
                int f = factors[i].Item1;
                for (int k = 0; k < factors[i].Item2; k++)
                {
                    divs.Add(divs[j] * f);
                    f *= factors[i].Item1;
                }
            }
        }

        return divs;
    }

    /// <summary>
    /// Returns μ(n). μ is mobius function.
    /// </summary>
    public int Mobius(int n)
    {
        if (n > _n) throw new InvalidOperationException();
        return _mobius[n];
    }

    /// <summary>
    /// When f(n) is equals to the sum of F(d) for all divisors d of n, calculates F(n) using mobius inversion formula. Time complexity is O(d(n)). (d is divisor function)
    /// </summary>
    public T MobiusTransform<T>(int n, T[] f) where T : INumber<T>
    {
        if (n > _n) throw new InvalidOperationException();
        List<int> divs = GetDivisors(n);
        T res = T.AdditiveIdentity;
        for (int i = 0; i < divs.Count; i++)
        {
            int m = Mobius(divs[i]);
            T factor = m == 0 ? T.Zero : (m == 1 ? T.MultiplicativeIdentity : -T.MultiplicativeIdentity);
            res += factor * f[n / divs[i]];
        }

        return res;
    }

    /// <summary>
    /// Returns the minimum prime that divides n. Time complexity is O(1).
    /// </summary>
    public int MinFactor(int n)
    {
        if (n > _n) throw new InvalidOperationException();
        return _minFactor[n];
    }

    /// <summary>
    /// Determines if n is a prime number. Time complexity is O(1).
    /// </summary>
    public bool IsPrime(int n)
    {
        if (n > _n) throw new InvalidOperationException();
        return _isPrime[n];
    }
}