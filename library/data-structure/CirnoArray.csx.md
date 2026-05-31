---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/data-structure/LazySegmentTree.csx
    title: "Lazy Segment Tree(\u9045\u5EF6\u8A55\u4FA1\u30BB\u30B0\u30E1\u30F3\u30C8\
      \u6728)"
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/data-structure/CirnoArray.test.csx
    title: verify/data-structure/CirnoArray.test.csx
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
  code: "#load \"LazySegmentTree.csx\"\n\npublic sealed class CirnoArray<T> where\
    \ T : struct, INumber<T>, IMinMaxValue<T>\n{\n    private LazySegmentTree<Node,\
    \ (T b, T c)> _data;\n\n    private struct Node : IEquatable<Node>\n    {\n  \
    \      public T Sum;\n        public T Max;\n        public T Min;\n\n       \
    \ public Node(T sum, T max, T min)\n        {\n            Sum = sum;\n      \
    \      Max = max;\n            Min = min;\n        }\n\n        public bool Equals(Node\
    \ other)\n        {\n            return Sum == other.Sum && Max == other.Max &&\
    \ Min == other.Min;\n        }\n    }\n\n    public CirnoArray(int n)\n    {\n\
    \        InitSegmentTree(n);\n        _data.Fill(new(T.Zero, T.Zero, T.Zero));\n\
    \    }\n\n    public CirnoArray(T[] source)\n    {\n        InitSegmentTree(source.Length);\n\
    \        Node[] arr = new Node[source.Length];\n        for (int i = 0; i < source.Length;\
    \ i++)\n        {\n            arr[i] = new(source[i], source[i], source[i]);\n\
    \        }\n        _data.Build(arr);\n    }\n\n    private void InitSegmentTree(int\
    \ n)\n    {\n        _data = new(n, (x, y) => new(x.Sum + y.Sum, T.Max(x.Max,\
    \ y.Max), T.Min(x.Min, y.Min)), (x, a, l) => new(x.Sum * a.b + T.CreateChecked(l)\
    \ * a.c, a.b > T.Zero ? x.Max * a.b + a.c : x.Min * a.b + a.c, a.b > T.Zero ?\
    \ x.Min * a.b + a.c : x.Max * a.b + a.c), (x, y) => (x.b * y.b, y.b * x.c + y.c),\
    \ new(T.Zero, T.MinValue, T.MaxValue));\n    }\n\n    public T this[int index]\n\
    \    {\n        get => _data.Access(index).Sum;\n        set => _data.Update(index,\
    \ index + 1, (T.Zero, value));\n    }\n\n    public void Add(int index, T value)\n\
    \    {\n        _data.Update(index, index + 1, (T.MultiplicativeIdentity, value));\n\
    \    }\n\n    public void Add(int l, int r, T value)\n    {\n        _data.Update(l,\
    \ r, (T.MultiplicativeIdentity, value));\n    }\n\n    public void Multiply(int\
    \ index, T value)\n    {\n        _data.Update(index, index + 1, (value, T.AdditiveIdentity));\n\
    \    }\n\n    public void Multiply(int l, int r, T value)\n    {\n        _data.Update(l,\
    \ r, (value, T.AdditiveIdentity));\n    }\n\n    public T Sum(int l, int r)\n\
    \    {\n        return _data.Fold(l, r).Sum;\n    }\n\n    public T Max(int l,\
    \ int r)\n    {\n        return _data.Fold(l, r).Max;\n    }\n\n    public T Min(int\
    \ l, int r)\n    {\n        return _data.Fold(l, r).Min;\n    }\n}"
  dependsOn:
  - library/data-structure/LazySegmentTree.csx
  isVerificationFile: false
  path: library/data-structure/CirnoArray.csx
  requiredBy: []
  timestamp: '2026-05-10 16:08:07+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/data-structure/CirnoArray.test.csx
documentation_of: library/data-structure/CirnoArray.csx
layout: document
title: CirnoArray
---

#### 説明

「あたいったらさいきょーね」な配列. 区間加算, 区間掛け算, 一点更新, 一点取得, 区間和取得, 区間最大値/最小値取得が簡単にできちゃう！　※中身はただの遅延セグ木.

#### 注意点
- $T$ は `INumber` を実装してね

#### 関数
- `this[index]`: $index$ 番目の要素を取得する. $O(\log n)$ なことに注意
- `Add(index, value)`: $index$ 番目の要素に $value$ を加算する
- `Add(l, r, value)`: 区間 $[l, r)$ に $value$ を加算する
- `Multiply(index, value)`: $index$ 番目の要素に $value$ を掛け算する
- `Multiply(l, r, value)`: 区間 $[l, r)$ に $value$ を掛け算する
- `Sum(l, r)`: 区間 $[l, r)$ の和を取得する
- `Max(l, r)`: 区間 $[l, r)$ の最大値を取得する
- `Min(l, r)`: 区間 $[l, r)$ の最小値を取得する