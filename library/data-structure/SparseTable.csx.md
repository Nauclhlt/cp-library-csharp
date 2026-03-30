---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/data-structure/SparseTable.test.csx
    title: verify/data-structure/SparseTable.test.csx
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    links: []
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "/// <summary>\n/// Sparse table, which can compute interval products of associative\
    \ and idempotent operations.\n/// </summary>\npublic sealed class SparseTable<T>\n\
    {\n    private Func<T, T, T> _op;\n    private T[][] _table;\n    private int[]\
    \ _lookup;\n    private int _length;\n    private T _identity;\n\n    /// <summary>\n\
    \    /// Build the sparse table by the array. Time complexity is O(nlogn).\n \
    \   /// </summary>\n    public SparseTable(T[] array, T identity, Func<T, T, T>\
    \ op)\n    {\n        _op = op;\n        _identity = identity;\n        _length\
    \ = array.Length;\n        int exp = 0;\n        while (1 << (exp + 1) <= array.Length)\
    \ exp++;\n        _table = new T[exp + 1][];\n        for (int i = 0; i <= exp;\
    \ i++)\n        {\n            _table[i] = new T[_length];\n        }\n\n    \
    \    for (int i = 0; i <= exp; i++)\n        {\n            int width = 1 << i;\n\
    \            for (int j = 0; j <= _length - width; j++)\n            {\n     \
    \           if (width == 1) _table[i][j] = array[j];\n                else _table[i][j]\
    \ = _op(_table[i - 1][j], _table[i - 1][j + (1 << (i - 1))]);\n            }\n\
    \        }\n\n        _lookup = new int[_length + 1];\n        for (int i = 2;\
    \ i <= _length; i++)\n        {\n            _lookup[i] = _lookup[i / 2] + 1;\n\
    \        }\n    }\n\n    /// <summary>\n    /// Gets the product of the interval\
    \ [l, r). Time complexity is O(1).\n    /// </summary>\n    public T Fold(int\
    \ l, int r)\n    {\n        if (l >= r) return _identity;\n        int len = r\
    \ - l;\n        int x = _lookup[len];\n        return _op(_table[x][l], _table[x][r\
    \ - (1 << x)]);\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/data-structure/SparseTable.csx
  requiredBy: []
  timestamp: '2026-03-30 11:41:30+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/data-structure/SparseTable.test.csx
documentation_of: library/data-structure/SparseTable.csx
layout: document
title: Sparse Table
---

#### 説明

$X$ 上の演算 $f: X^2\rightarrow X$ が冪等性を満たすとは $x\in X$ に対して $f(x, x) = x$ を満たすことをいう.

$\max, \min, \gcd, \mathrm{AND, OR}$ などがこれを満たす演算の例. Sparse Tableが扱えるのはさらに結合律を満たすもの.

Sparse Tableは静的な列に対してこのような演算の区間積を $\Theta (n\log n)$ の前計算により各 $O(1)$ で処理する. 具体的には, 各 $i$ に対して $i$ を左端する長さが2冪の区間の積を前計算しておけば, 任意の区間がそのような区間高々 $2$ つの和集合として表せるため, 冪等性からその和が求まるという仕組み.

#### 注意点
- 前計算がそこそこ重い代わりにクエリが軽いので, 変更の必要がなければセグメント木よりも速い場合がある

#### 関数
- `Fold(l, r)`: 区間 $[l, r)$ の積を求める