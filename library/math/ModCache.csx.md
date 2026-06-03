---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/math/ModInt.csx
    title: ModInt
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/math/ModCache.test.csx
    title: verify/math/ModCache.test.csx
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
  code: "#load \"ModInt.csx\"\n\n/// <summary>\n/// Pre-calculation utility class\
    \ for modint.\n/// </summary>\npublic sealed class ModCache<T> where T : struct,\
    \ IMod\n{\n    private ModInt<T>[] _factorial;\n    private ModInt<T>[] _inverseFactorial;\n\
    \    private ModInt<T>[] _inverse;\n\n    /// <summary>\n    /// Calculates factorials,\
    \ inverse factorials, and inverses for all numbers from 1 to n. Time complexity\
    \ is O(n).\n    /// </summary>\n    public ModCache(long n)\n    {\n        _factorial\
    \ = new ModInt<T>[n + 1];\n        _inverseFactorial = new ModInt<T>[n + 1];\n\
    \n        _factorial[0] = 1;\n        _inverseFactorial[0] = ModInt<T>.One;\n\n\
    \        _inverse = new ModInt<T>[n + 1];\n        _inverse[1] = ModInt<T>.CreateFast(1);\n\
    \n        for (long p = 1; p <= n; p++)\n        {\n            _factorial[p]\
    \ = _factorial[p - 1] * p;\n            if (p > 1)\n            {\n          \
    \      _inverse[p] = -(ModInt<T>.Mod / p) * _inverse[ModInt<T>.Mod % p];\n   \
    \         }\n            _inverseFactorial[p] = _inverseFactorial[p - 1] * _inverse[p];\n\
    \        }\n    }\n\n    /// <summary>\n    /// Returns binom(n, r). Note that\
    \ if r < 0, r > n, or n <= 0, this function returns 0. Time complexity is O(1).\n\
    \    /// </summary>\n    public ModInt<T> Combination(long n, long r)\n    {\n\
    \        if (r < 0 || r > n || n <= 0) return 0;\n        return _factorial[n]\
    \ * (_inverseFactorial[n - r] * _inverseFactorial[r]);\n    }\n\n    /// <summary>\n\
    \    /// Returns nPr. Note that if r < 0, r > n, or n <= 0, this function returns\
    \ 0. Time complexity is O(1).\n    /// </summary>\n    public ModInt<T> Permutation(long\
    \ n, long r)\n    {\n        if (r < 0 || r > n || n <= 0) return 1;\n       \
    \ return _factorial[n] * _inverseFactorial[n - r];\n    }\n\n    /// <summary>\n\
    \    /// Returns n!. Time complexity is O(1).\n    /// </summary>\n    public\
    \ ModInt<T> Factorial(long n)\n    {\n        Debug.Assert(0 <= n && n < _factorial.Length);\n\
    \        return _factorial[n];\n    }\n\n    /// <summary>\n    /// Returns (n!)^-1.\
    \ Time complexity is O(1).\n    /// </summary>\n    public ModInt<T> InverseFactorial(int\
    \ n)\n    {\n        Debug.Assert(0 <= n && n < _inverseFactorial.Length);\n \
    \       return _inverseFactorial[n];\n    }\n\n    /// <summary>\n    /// Returns\
    \ n^-1. Time complexity is O(1).\n    /// </summary>\n    public ModInt<T> Inverse(long\
    \ n)\n    {\n        Debug.Assert(0 <= n && n < _inverse.Length);\n        return\
    \ _inverse[n];\n    }\n}"
  dependsOn:
  - library/math/ModInt.csx
  isVerificationFile: false
  path: library/math/ModCache.csx
  requiredBy: []
  timestamp: '2026-06-01 18:17:15+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/math/ModCache.test.csx
documentation_of: library/math/ModCache.csx
layout: document
title: "Mod Cache (\u4F59\u308A\u95A2\u9023\u306E\u524D\u8A08\u7B97)"
---

#### 説明

$p$ を素数とする. $n=1, 2, \cdots, N$ に対して $\mathbb{F}_p$ 上で以下のものが $O(N)$ で前計算できる
- $n!$
- $(n!)^{-1}$
- $n^{-1}$

これに伴って, $1\leq n, r\leq N$ なる $n, r$ について以下のものが前計算の後, 各 $O(1)$ で取得できるようになる.

- $\displaystyle \binom{n}{r}={}_n\mathrm{C}_r$
- ${}_n\mathrm{P}_r$

#### 注意点
- $\displaystyle \binom{n}{r}$ について, $r$ が十分小さい場合は愚直計算で求めることができる. この場合 $n$ は巨大でもよい

#### 関数
- `Combination(n, r)`: 二項係数 $\displaystyle \binom{n}{r}$ を返す
- `Permutation(n, r)`: 順列の総数 ${}_n\mathrm{P}_r$ を返す
- `Factorial(n)`: $n!$ を返す
- `InverseFactorial(n)`: $(n!)^{-1}$ を返す
- `Inverse(n)`: $n^{-1}$ を返す