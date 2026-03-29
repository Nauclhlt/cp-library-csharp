---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/data-structure/SegmentTree.test.csx
    title: verify/data-structure/SegmentTree.test.csx
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
  code: "/// <summary>\n/// Segment tree. (Non-recursive, compatible for non-commutative\
    \ monoid)\n/// </summary>\n/// <typeparam name=\"T\">Type of values.</typeparam>\n\
    public sealed class SegmentTree<T> where T : struct\n{\n    public delegate T\
    \ Monoid(T x, T y);\n\n    private int _treeSize;\n    private int _dataSize;\n\
    \    private int _originalDataSize;\n    private T[] _data;\n    private Monoid\
    \ _operator;\n    private Monoid _update;\n    private T _identity;\n\n    public\
    \ int OriginalDataSize => _originalDataSize;\n    public int TreeSize => _treeSize;\n\
    \    public T Identity => _identity;\n\n    /// <summary>\n    /// Gets the value\
    \ by index. Time complexity is O(1).\n    /// </summary>\n    public T this[int\
    \ index]\n    {\n        get\n        {\n            return _data[_dataSize -\
    \ 1 + index];\n        }\n    }\n\n    /// <summary>\n    /// Builds the segment\
    \ tree. Time complexity is O(n).\n    /// </summary>\n    public SegmentTree(int\
    \ n, Monoid op, Monoid update, T identity)\n    {\n        _originalDataSize =\
    \ n;\n\n        int size = 1;\n        while (n > size)\n        {\n         \
    \   size <<= 1;\n        }\n\n        _dataSize = size;\n        _treeSize = 2\
    \ * size - 1;\n\n        _data = new T[_treeSize];\n        Array.Fill(_data,\
    \ identity);\n        _identity = identity;\n        _operator = op;\n       \
    \ _update = update;\n    }\n\n    /// <summary>\n    /// Rebuild the segment tree\
    \ from the array. Time complexity is O(n).\n    /// Since the time complexity\
    \ of n Update() calls is O(nlogn), when initializing the segment tree with an\
    \ array, \n    /// call this function to make it faster.\n    /// </summary>\n\
    \    public void Build(T[] array)\n    {\n        for (int i = 0; i < array.Length;\
    \ i++)\n        {\n            _data[i + _dataSize - 1] = array[i];\n        }\n\
    \n        for (int i = _dataSize - 2; i >= 0; i--)\n        {\n            _data[i]\
    \ = _operator(_data[(i << 1) + 1], _data[(i << 1) + 2]);\n        }\n    }\n\n\
    \    public void UpdateByArray(T[] array)\n    {\n        for (int i = 0; i <\
    \ array.Length; i++)\n        {\n            _data[i + _dataSize - 1] = _update(_data[i\
    \ + _dataSize - 1], array[i]);\n        }\n\n        for (int i = _dataSize -\
    \ 2; i >= 0; i--)\n        {\n            _data[i] = _operator(_data[(i << 1)\
    \ + 1], _data[(i << 1) + 2]);\n        }\n    }\n\n    /// <summary>\n    ///\
    \ Fill the array with the uniform value. Time complexity is O(n).\n    /// </summary>\n\
    \    public void Fill(T value)\n    {\n        for (int i = 0; i < _originalDataSize;\
    \ i++)\n        {\n            _data[i + _dataSize - 1] = value;\n        }\n\n\
    \        for (int i = _dataSize - 2; i >= 0; i--)\n        {\n            _data[i]\
    \ = _operator(_data[(i << 1) + 1], _data[(i << 1) + 2]);\n        }\n    }\n\n\
    \    /// <summary>\n    /// Update the value at the specified position. Time complexity\
    \ is O(logn).\n    /// </summary>\n    public void Update(int index, T value)\n\
    \    {\n        index += _dataSize - 1;\n        _data[index] = _update(_data[index],\
    \ value);\n\n        while (index > 0)\n        {\n            index = (index\
    \ - 1) >> 1;\n            _data[index] = _operator(_data[(index << 1) + 1], _data[(index\
    \ << 1) + 2]);\n        }\n    }\n\n    /// <summary>\n    /// Gets the product\
    \ of the range [l, r). Time complexity is O(logn).\n    /// </summary>\n    public\
    \ T Fold(int l, int r)\n    {\n        l += _dataSize - 1;\n        r += _dataSize\
    \ - 1;\n\n        T leftFold = _identity;\n        T rightFold = _identity;\n\
    \        while (l < r)\n        {\n            if ((l & 1) == 0)\n           \
    \ {\n                leftFold = _operator(leftFold, _data[l]);\n             \
    \   l++;\n            }\n            if ((r & 1) == 0)\n            {\n      \
    \          r--;\n                rightFold = _operator(_data[r], rightFold);\n\
    \            }\n\n            l = (l - 1) >> 1;\n            r = (r - 1) >> 1;\n\
    \        }\n\n        return _operator(leftFold, rightFold);\n    }\n\n    ///\
    \ <summary>\n    /// Returns the span of the underlying data. Time complexity\
    \ is O(1).\n    /// </summary>\n    public ReadOnlySpan<T> AsSpan()\n    {\n \
    \       return _data.AsSpan(_dataSize - 1, _originalDataSize);\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/data-structure/SegmentTree.csx
  requiredBy: []
  timestamp: '2026-03-29 20:16:24+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/data-structure/SegmentTree.test.csx
documentation_of: library/data-structure/SegmentTree.csx
layout: document
title: Segment Tree
---

#### 説明

1次元のセグメント木. セグメント木に乗せられる演算は(可換とは限らない)モノイドをなすもの. 1点更新と区間積取得を各 $O(\log n)$ で処理する.

ただし競プロにおいては構造体などに適当なフラグを持たせるなどすることで単位元は作れたりする.

#### 注意点
- 内部で利用する配列の長さを2冪に揃える実装をしている
- 1点加算などを手軽に書けるように, 更新する際の処理も受け取るようにしている
- クエリ, 1点更新共に非再帰での実装で $O(\log n)$
- 単位元はちゃんと設定しないと壊れる

#### 関数
- `this[index]`: $index$ 番目の要素を取得する
- `Build(array)`: $array$ で再構築する
- `UpdateByArray(array)`: $i$ 番目の要素 $a_i$ に対して $a_i\leftarrow update(a_i, array[i])$ となるように更新する
- `Fill(value)`: 全要素を $value$ で埋めて再構築する
- `Update(index, value)`: $index$ 番目の要素を $value$ で更新する
- `Fold(l, r)`: 区間 $[l, r)$ の積を取得する
- `AsSpan()`: 内部配列のビュー(read-only)を返す. 2冪に拡大する実装になっているため用意している.