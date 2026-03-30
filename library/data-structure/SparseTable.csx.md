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

$p$ を素数として $\mathbb{F}_p$ 上の整数. 常に $0$ 以上 $p-1$ 以下の値を取ることが保証される.

$p$ が素数であるため, $0$ でない任意の元に対して乗法逆元が存在する. フェルマーの小定理より, $x$ に対して $x^{p-2}$ が逆元となっていることも分かる. $O(\log p)$ で逆元が計算できる.

ただし, 割り算の度に $O(\log p)$ の処理をしていると間に合わない場合があるため, そのときは逆元の前計算などで対応する.

#### 注意点
- 遅くはないがそこまで速くもない
- `INumber` インターフェースを実装しているため, Generic Mathに使える
- 利用する際は `ModInt<Mod998244353>` のようにジェネリックで法を指定する

#### 関数
- `CreateFast(value)`: $value$ で初期化したものを返す. この関数ではmodをとる処理が入らないため, 範囲内であることが事前に分かっている場合は効率が良いかもしれない. 別に良くないかもしれない.
- `Power(e)`: 繰り返し $2$ 乗法で $e$ 乗した値を求める
- `Inv()`: 逆元を返す
- その他各種演算子が使える