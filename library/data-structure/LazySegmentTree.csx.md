---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':x:'
    path: verify/data-structure/LazySegmentTree.test.csx
    title: verify/data-structure/LazySegmentTree.test.csx
  _isVerificationFailed: true
  _pathExtension: csx
  _verificationStatusIcon: ':x:'
  attributes:
    links: []
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "/// <summary>\n/// Segment Tree with lazy evaluation. (Recursive, can be\
    \ used with non-commutative monoid)\n/// </summary>\npublic sealed class LazySegmentTree<T,\
    \ M> where T : struct, IEquatable<T> where M : struct, IEquatable<M>\n{\n    public\
    \ delegate T Monoid(T x, T y);\n    public delegate M Composition(M x, M y);\n\
    \    public delegate T Mapping(T x, M y, int l);\n\n    private int _treeSize;\n\
    \    private int _dataSize;\n    private int _originalDataSize;\n    private T[]\
    \ _data;\n    private M?[] _lazy;\n    private Monoid _operator;\n    private\
    \ Mapping _mapping;\n    private Composition _composition;\n    private T _identity;\n\
    \n    /// <summary>\n    /// Gets the value by index. Time complexity is O(logn).\n\
    \    /// </summary>\n    public T this[int index]\n    {\n        get\n      \
    \  {\n            return Access(index);\n        }\n    }\n\n    /// <summary>\n\
    \    /// Builds the segment tree. Time complexity is O(n).\n    /// </summary>\n\
    \    /// <param name=\"n\">Size of the segment tree.</param>\n    /// <param name=\"\
    op\">Binary operation.</param>\n    /// <param name=\"mapping\">Mapping function.</param>\n\
    \    /// <param name=\"composition\">Composition function. composition(x, y) :=\
    \ yox</param>\n    /// <param name=\"identity\">Identity.</param>\n    public\
    \ LazySegmentTree(int n, Monoid op, Mapping mapping, Composition composition,\
    \ T identity)\n    {\n        _originalDataSize = n;\n\n        int size = 1;\n\
    \        while (n > size)\n        {\n            size <<= 1;\n        }\n\n \
    \       _dataSize = size;\n        _treeSize = 2 * size - 1;\n\n        _data\
    \ = new T[_treeSize];\n        _data.AsSpan().Fill(_identity);\n        _lazy\
    \ = new M?[_treeSize];\n\n        _identity = identity;\n        _operator = op;\n\
    \        _mapping = mapping;\n        _composition = composition;\n    }\n\n \
    \   /// <summary>\n    /// Rebuild the segment tree from the array. Time complexity\
    \ is O(n).\n    /// Since the time complexity of n Update() calls is O(nlogn),\
    \ when initializing the segment tree with an array, \n    /// call this function\
    \ to make it faster.\n    /// </summary>\n    public void Build(T[] array)\n \
    \   {\n        for (int i = 0; i < array.Length; i++)\n        {\n           \
    \ _data[i + _dataSize - 1] = array[i];\n        }\n\n        for (int i = _dataSize\
    \ - 2; i >= 0; i--)\n        {\n            _data[i] = _operator(_data[(i << 1)\
    \ + 1], _data[(i << 1) + 2]);\n        }\n    }\n\n     /// <summary>\n    ///\
    \ Fill the array with the uniform value. Time complexity is O(n).\n    /// </summary>\n\
    \    public void Fill(T value)\n    {\n        for (int i = 0; i < _originalDataSize;\
    \ i++)\n        {\n            _data[i + _dataSize - 1] = value;\n        }\n\n\
    \        for (int i = _dataSize - 2; i >= 0; i--)\n        {\n            _data[i]\
    \ = _operator(_data[(i << 1) + 1], _data[(i << 1) + 2]);\n        }\n    }\n\n\
    \    private void Evaluate(int index, int l, int r)\n    {\n        if (_lazy[index]\
    \ is null)\n        {\n            return;\n        }\n\n        if (index < _dataSize\
    \ - 1)\n        {\n            _lazy[(index << 1) + 1] = GuardComposition(_lazy[(index\
    \ << 1) + 1], _lazy[index]);\n            _lazy[(index << 1) + 2] = GuardComposition(_lazy[(index\
    \ << 1) + 2], _lazy[index]);\n        }\n\n        _data[index] = _mapping(_data[index],\
    \ (M)_lazy[index], r - l);\n        _lazy[index] = null;\n    }\n\n    private\
    \ M GuardComposition(M? a, M? b)\n    {\n        if (a is null)\n        {\n \
    \           return (M)b;\n        }\n        else\n        {\n            return\
    \ _composition((M)a, (M)b);\n        }\n    }\n\n    /// <summary>\n    /// Update\
    \ the range [l, r) by m. Time complexity is O(logn).\n    /// </summary>\n   \
    \ public void Update(int l, int r, M m)\n    {\n        if (l == r) return;\n\n\
    \        if (0 <= l && l < r && r <= _originalDataSize)\n            ApplyRec(l,\
    \ r, m, 0, 0, _dataSize);\n    }\n    \n    private void ApplyRec(int a, int b,\
    \ M m, int index, int l, int r)\n    {\n        Evaluate(index, l, r);\n\n   \
    \     if (a >= r || b <= l)\n        {\n            return;\n        }\n\n   \
    \     if (a <= l && r <= b)\n        {\n            _lazy[index] = GuardComposition(_lazy[index],\
    \ m);\n            Evaluate(index, l, r);\n        }\n        else\n        {\n\
    \            ApplyRec(a, b, m, (index << 1) + 1, l, (l + r) / 2);\n          \
    \  ApplyRec(a, b, m, (index << 1) + 2, (l + r) / 2, r);\n            _data[index]\
    \ = _operator(_data[(index << 1) + 1], _data[(index << 1) + 2]);\n        }\n\
    \    }\n\n    /// <summary>\n    /// Gets the product of the range [l, r). Time\
    \ complexity is O(logn).\n    /// </summary>\n    /// <param name=\"l\"></param>\n\
    \    /// <param name=\"r\"></param>\n    /// <returns></returns>\n    public T\
    \ Fold(int l, int r)\n    {\n        if (l == r) return _identity;\n\n       \
    \ if (0 <= l && l < r && r <= _originalDataSize)\n            return QueryRec(l,\
    \ r, 0, 0, _dataSize);\n        else\n            return _identity;\n    }\n\n\
    \    private T QueryRec(int left, int right, int index, int nodeLeft, int nodeRight)\n\
    \    {\n        Evaluate(index, nodeLeft, nodeRight);\n\n        if (left >= nodeRight\
    \ || right <= nodeLeft)\n        {\n            return _identity;\n        }\n\
    \n        if (left <= nodeLeft && nodeRight <= right)\n        {\n           \
    \ return _data[index];\n        }\n\n        T leftChild = QueryRec(left, right,\
    \ (index << 1) + 1, nodeLeft, (nodeLeft + nodeRight) >> 1);\n        T rightChild\
    \ = QueryRec(left, right, (index << 1) + 2, (nodeLeft + nodeRight) >> 1, nodeRight);\n\
    \n        return _operator(leftChild, rightChild);\n    }\n\n    /// <summary>\n\
    \    /// Gets the value at the specified index. Time complexity is O(logn).\n\
    \    /// </summary>\n    public T Access(int index)\n    {\n        if (index\
    \ < 0 || index >= _originalDataSize)\n        {\n            throw new Exception(\"\
    Index is out of range.\");\n        }\n\n        return AccessRec(index, 0, 0,\
    \ _dataSize);\n    }\n\n    private T AccessRec(int target, int index, int l,\
    \ int r)\n    {\n        Evaluate(index, l, r);\n\n        if (index >= _dataSize\
    \ - 1)\n        {\n            return _data[index];\n        }\n\n        int\
    \ mid = (l + r) / 2;\n        if (target < mid)\n        {\n            return\
    \ AccessRec(target, (index << 1) + 1, l, mid);\n        }\n        else\n    \
    \    {\n            return AccessRec(target, (index << 1) + 2, mid, r);\n    \
    \    }\n    }\n\n    private void EvaluateAll(int index, int l, int r)\n    {\n\
    \        if (_lazy[index] is null)\n        {\n            if (index < _dataSize\
    \ - 1)\n            {\n                EvaluateAll((index << 1) + 1, l, (l + r)\
    \ / 2);\n                EvaluateAll((index << 1) + 2, (l + r) / 2, r);\n    \
    \        }\n            return;\n        }\n\n        if (index < _dataSize -\
    \ 1)\n        {\n            _lazy[(index << 1) + 1] = GuardComposition(_lazy[(index\
    \ << 1) + 1], _lazy[index]);\n            _lazy[(index << 1) + 2] = GuardComposition(_lazy[(index\
    \ << 1) + 2], _lazy[index]);\n            EvaluateAll((index << 1) + 1, l, (l\
    \ + r) / 2);\n            EvaluateAll((index << 1) + 2, (l + r) / 2, r);\n   \
    \     }\n\n        _data[index] = _mapping(_data[index], (M)_lazy[index], r -\
    \ l);\n        _lazy[index] = null;\n    }\n\n    /// <summary>\n    /// Returns\
    \ the span of the underlying data. Time complexity is O(n).\n    /// </summary>\n\
    \    /// <returns></returns>\n    public ReadOnlySpan<T> AsSpan()\n    {\n   \
    \     EvaluateAll(0, 0, _dataSize);\n\n        return _data.AsSpan(_dataSize -\
    \ 1, _originalDataSize);\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/data-structure/LazySegmentTree.csx
  requiredBy: []
  timestamp: '2026-05-10 10:54:19+09:00'
  verificationStatus: LIBRARY_ALL_WA
  verifiedWith:
  - verify/data-structure/LazySegmentTree.test.csx
documentation_of: library/data-structure/LazySegmentTree.csx
layout: document
title: Lazy Segment Tree
---

#### 説明

1次元の遅延評価セグメント木. モノイドの演算に加えてモノイドによる区間作用も対数時間で処理する.

#### 注意点
- 内部で利用する配列の長さを2冪に揃える実装をしている
- 中身は再帰の実装になっている
- 単位元はちゃんと設定しないと壊れる

#### 関数
- `this[index]`: $index$ 番目の要素を取得する. $O(\log n)$ なことに注意
- `Build(array)`: $array$ で再構築する
- `Fill(value)`: 全要素を $value$ で埋めて再構築する
- `Update(l, r, m)`: 区間 $[l, r)$ に対して $m$ を作用させる
- `Fold(l, r)`: 区間 $[l, r)$ の積を取得する
- `Access(index)`: `this[index]` と同じ
- `AsSpan()`: 内部配列のビュー(read-only)を返す. 2冪に拡大する実装になっているため用意している.