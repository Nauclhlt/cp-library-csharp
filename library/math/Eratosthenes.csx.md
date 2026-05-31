---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/math/Eratosthenes.test.csx
    title: verify/math/Eratosthenes.test.csx
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes: {}
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "/// <summary>\n/// Sieve of Eratosthenes.\n/// </summary>\npublic sealed\
    \ class Eratosthenes\n{\n    private bool[] _isPrime;\n    private int[] _minFactor;\n\
    \    private int[] _mobius;\n    private int _n;\n\n    /// <summary>\n    ///\
    \ Initializes new instance. Time complexity is O(nloglogn);\n    /// </summary>\n\
    \    public Eratosthenes(int n)\n    {\n        _n = n;\n\n        _isPrime =\
    \ new bool[n + 1];\n        _minFactor = new int[n + 1];\n        _mobius = new\
    \ int[n + 1];\n\n        Array.Fill(_isPrime, true);\n        Array.Fill(_minFactor,\
    \ -1);\n        Array.Fill(_mobius, 1);\n\n        _isPrime[1] = false;\n    \
    \    _minFactor[1] = 1;\n\n        for (int i = 2; i <= _n; i++)\n        {\n\
    \            if (!_isPrime[i]) continue;\n\n            _minFactor[i] = i;\n \
    \           _mobius[i] = -1;\n\n            for (int j = i + i; j <= _n; j +=\
    \ i)\n            {\n                _isPrime[j] = false;\n\n                if\
    \ (_minFactor[j] == -1) _minFactor[j] = i;\n                if (j / i % i == 0)\
    \ _mobius[j] = 0;\n                else _mobius[j] = -_mobius[j];\n          \
    \  }\n        }\n    }\n\n    /// <summary>\n    /// Returns the prime factorization\
    \ of n. Time complexity is O(logn).\n    /// </summary>\n    public List<(int,\
    \ int)> PrimeFactorize(int n)\n    {\n        if (n > _n) throw new InvalidOperationException();\n\
    \        List<(int, int)> result = new();\n        while (_minFactor[n] != 1)\n\
    \        {\n            int p = _minFactor[n];\n            int c = 0;\n     \
    \       while (n % p == 0)\n            {\n                n /= p;\n         \
    \       c++;\n            }\n\n            result.Add((p, c));\n        }\n\n\
    \        return result;\n    }\n\n    /// <summary>\n    /// Enumerates all divisors\
    \ of n. Time complexity is O(logn + d(n)). (d is divisor function)\n    /// </summary>\n\
    \    public List<int> GetDivisors(int n)\n    {\n        if (n > _n) throw new\
    \ InvalidOperationException();\n        List<int> divs = new();\n        var factors\
    \ = PrimeFactorize(n);\n\n        divs.Add(1);\n\n        for (int i = 0; i <\
    \ factors.Count; i++)\n        {\n            int len = divs.Count;\n        \
    \    for (int j = 0; j < len; j++)\n            {\n                int f = factors[i].Item1;\n\
    \                for (int k = 0; k < factors[i].Item2; k++)\n                {\n\
    \                    divs.Add(divs[j] * f);\n                    f *= factors[i].Item1;\n\
    \                }\n            }\n        }\n\n        return divs;\n    }\n\n\
    \    /// <summary>\n    /// Returns \u03BC(n). \u03BC is mobius function.\n  \
    \  /// </summary>\n    public int Mobius(int n)\n    {\n        if (n > _n) throw\
    \ new InvalidOperationException();\n        return _mobius[n];\n    }\n\n    ///\
    \ <summary>\n    /// When f(n) is equals to the sum of F(d) for all divisors d\
    \ of n, calculates F(n) using mobius inversion formula. Time complexity is O(d(n)).\
    \ (d is divisor function)\n    /// </summary>\n    public T MobiusTransform<T>(int\
    \ n, T[] f) where T : INumber<T>\n    {\n        if (n > _n) throw new InvalidOperationException();\n\
    \        List<int> divs = GetDivisors(n);\n        T res = T.AdditiveIdentity;\n\
    \        for (int i = 0; i < divs.Count; i++)\n        {\n            int m =\
    \ Mobius(divs[i]);\n            T factor = m == 0 ? T.Zero : (m == 1 ? T.MultiplicativeIdentity\
    \ : -T.MultiplicativeIdentity);\n            res += factor * f[n / divs[i]];\n\
    \        }\n\n        return res;\n    }\n\n    /// <summary>\n    /// Returns\
    \ the minimum prime that divides n. Time complexity is O(1).\n    /// </summary>\n\
    \    public int MinFactor(int n)\n    {\n        if (n > _n) throw new InvalidOperationException();\n\
    \        return _minFactor[n];\n    }\n\n    /// <summary>\n    /// Determines\
    \ if n is a prime number. Time complexity is O(1).\n    /// </summary>\n    public\
    \ bool IsPrime(int n)\n    {\n        if (n > _n) throw new InvalidOperationException();\n\
    \        return _isPrime[n];\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/math/Eratosthenes.csx
  requiredBy: []
  timestamp: '2026-05-14 21:28:54+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/math/Eratosthenes.test.csx
documentation_of: library/math/Eratosthenes.csx
layout: document
title: "Sieve of Eratosthenes(\u30A8\u30E9\u30C8\u30B9\u30C6\u30CD\u30B9\u306E\u7BE9\
  )"
---

#### 説明

エラトステネスの篩のアルゴリズムを用いると, $n$ 以下の各正整数 $k$ に対して, $k$ が素数かどうかの情報だけでなく, $k$ を割り切る最小の素数, $\mu (k)$ も $O(n\log\log n)$ で求まる. (これ以外にも色々求めることができるが実装はしていない)

上述の前計算によって, 素因数分解が試し割り法による $O(\sqrt{n})$ より良い $O(\log n)$ の計算量で計算できたり, 約数を列挙できたりする. また, メビウス関数の値はメビウスの反転公式で活躍したりする.

#### 注意点
- 前計算でうまくやりたいときに使う. 数回なら素直に試し割りの方が速い.

#### 関数
- `PrimeFactorize(n)`: $n$ の素因数分解を求める
- `GetDivisors(n)`: $n$ の約数を列挙する
- `Mobius(n)`: $\mu (n)$ を求める. ここで $\mu$ はメビウス関数
- `MobiusTransform(n, f)`: $g$ を $f$ のメビウス変換, すなわち $\displaystyle f(N)=\sum_{d:Nの約数} g(d)$ を満たす関数とするとき, $g(n)$ を求める
- `MinFactor(n)`: $n$ を割り切る最小の素数を返す
- `IsPrime(n)`: $n$ が素数かどうかを返す