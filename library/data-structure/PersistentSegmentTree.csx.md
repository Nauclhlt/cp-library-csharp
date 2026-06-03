---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':warning:'
  attributes: {}
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "/// <summary>\n/// Persistent segment tree.\n/// </summary>\npublic sealed\
    \ class PersistentSegmentTree<T>\n{\n    public delegate T Monoid(T x, T y);\n\
    \n    private sealed class Node\n    {\n        public T Data { get; set; }\n\
    \        public Node LeftNode { get; set; }\n        public Node RightNode { get;\
    \ set; }\n\n        public Node(T data)\n        {\n            Data = data;\n\
    \            LeftNode = null;\n            RightNode = null;\n        }\n    }\n\
    \n    private int _treeSize;\n    private int _size;\n    private Monoid<T> _operator;\n\
    \    private Monoid<T> _update;\n    private T _identity;\n    private List<Node>\
    \ _snapshots;\n\n    public int Size => _size;\n    public int TreeSize => _treeSize;\n\
    \    public T Identity => _identity;\n\n    public PersistentSegmentTree(int n,\
    \ Monoid<T> op, Monoid<T> update, T identity)\n    {\n        _size = n;\n   \
    \     _treeSize = 2 * _size - 1;\n\n        _identity = identity;\n        _operator\
    \ = op;\n        _update = update;\n\n        _snapshots = new();\n    }\n\n \
    \   /// <summary>\n    /// Returns the value at the specified index, at the specified\
    \ time. Time complexity is O(logn).\n    /// </summary>\n    public T this[int\
    \ time, int index]\n    {\n        get\n        {\n            return Access(time,\
    \ index);\n        }\n    }\n\n    /// <summary>\n    /// Builds the segment tree\
    \ from the array. Time complexity is O(n).\n    /// </summary>\n    public int\
    \ Build(T[] array)\n    {\n        if (_size != array.Length)\n        {\n   \
    \         throw new InvalidOperationException(\"Size of the specified array does\
    \ not match with the data size passed in the constructor.\");\n        }\n\n \
    \       return RegisterNode(BuildRange(0, array.Length, array));\n    }\n\n  \
    \  /// <summary>\n    /// Fills the segment tree with the uniform value. Time\
    \ complexity is O(n).\n    /// </summary>\n    public int Fill(T value)\n    {\n\
    \        return RegisterNode(BuildFillRange(0, _size, value));\n    }\n\n    private\
    \ Node BuildFillRange(int l, int r, T value)\n    {\n        if (l + 1 >= r) return\
    \ new Node(value);\n        else return MergeNode(BuildFillRange(l, (l + r) /\
    \ 2, value), BuildFillRange((l + r) / 2, r, value));\n    }\n\n    private Node\
    \ BuildRange(int l, int r, T[] array)\n    {\n        if (l + 1 >= r) return new\
    \ Node(array[l]);\n        else return MergeNode(BuildRange(l, (l + r) / 2, array),\
    \ BuildRange((l + r) / 2, r, array));\n    }\n\n    private Node MergeNode(Node\
    \ l, Node r)\n    {\n        Node res = new (_operator(l.Data, r.Data))\n    \
    \    {\n            LeftNode = l,\n            RightNode = r\n        };\n   \
    \     return res;\n    }\n\n    /// <summary>\n    /// Clear all snapshots. Time\
    \ complexity is O(1).\n    /// </summary>\n    public void ClearSnapshots()\n\
    \    {\n        _snapshots.Clear();\n    }\n\n    private int RegisterNode(Node\
    \ node)\n    {\n        _snapshots.Add(node);\n        return _snapshots.Count\
    \ - 1;\n    }\n\n    private Node GetRoot(int time)\n    {\n        return _snapshots[time];\n\
    \    }\n\n    /// <summary>\n    /// Updates the value at the specified index,\
    \ at the specified time. Time complexity is O(logn).\n    /// </summary>\n   \
    \ public int Update(int time, int index, T value)\n    {\n        return RegisterNode(ApplyRec(index,\
    \ value, GetRoot(time), 0, _size));\n    }\n\n    private Node ApplyRec(int index,\
    \ T value, Node node, int l, int r)\n    {\n        if (r <= index || index +\
    \ 1 <= l)\n        {\n            return node;\n        }\n        else if (index\
    \ <= l && r <= index + 1)\n        {\n            return new Node(_update(node.Data,\
    \ value));\n        }\n        else\n        {\n            return MergeNode(ApplyRec(index,\
    \ value, node.LeftNode, l, (l + r) / 2), ApplyRec(index, value, node.RightNode,\
    \ (l + r) / 2, r));\n        }\n    }\n\n    /// <summary>\n    /// Returns the\
    \ product of the interval [l, r), at the specified time. Time complexity is O(logn).\n\
    \    /// </summary>\n    public T Fold(int time, int l, int r)\n    {\n      \
    \  return QueryRec(l, r, GetRoot(time), 0, _size);\n    }\n\n    private T QueryRec(int\
    \ left, int right, Node node, int l, int r)\n    {\n        if (r <= left || right\
    \ <= l)\n        {\n            return _identity;\n        }\n        else if\
    \ (left <= l && r <= right)\n        {\n            return node.Data;\n      \
    \  }\n        else\n        {\n            return _operator(QueryRec(left, right,\
    \ node.LeftNode, l, (l + r) / 2), QueryRec(left, right, node.RightNode, (l + r)\
    \ / 2, r));\n        }\n    }\n\n    /// <summary>\n    /// Returns the value\
    \ at the specified index, at the specified time. Time complexity is O(logn).\n\
    \    /// </summary>\n    public T Access(int time, int index)\n    {\n       \
    \ Node current = GetRoot(time);\n        int l = 0;\n        int r = _size;\n\
    \        while (true)\n        {\n            if (l == index && l + 1 == r) return\
    \ current.Data;\n\n            if (index < (l + r) / 2)\n            {\n     \
    \           r = (l + r) / 2;\n                current = current.LeftNode;\n  \
    \          }\n            else\n            {\n                l = (l + r) / 2;\n\
    \                current = current.RightNode;\n            }\n        }\n    }\n\
    }"
  dependsOn: []
  isVerificationFile: false
  path: library/data-structure/PersistentSegmentTree.csx
  requiredBy: []
  timestamp: '2026-06-03 15:40:08+09:00'
  verificationStatus: LIBRARY_NO_TESTS
  verifiedWith: []
documentation_of: library/data-structure/PersistentSegmentTree.csx
layout: document
title: "Persistent Segment Tree(\u5B8C\u5168\u6C38\u7D9A\u30BB\u30B0\u30E1\u30F3\u30C8\
  \u6728)"
---

#### 説明

1次元のセグメント木を完全永続にしたもの. 通常のセグメント木で, 一点更新の際の計算量は $O(\log n)$ だが, このとき値が更新されるノードの数も $O(\log n)$ 個であるため, 更新クエリのたびに新たに $O(\log n)$ 個のノードをくっつけて木を作ればよい. 更新されない部分については, そのまま接続するようにすればよい.

これによって, 更新クエリ数を $Q$ として, $O((N+Q)\log N)$ 空間で永続になる.

ライブラリの設計上は, 整数で時刻を管理するようになっている.

#### 注意点
- 長さを $2$ べきに揃えるような仕様はない
- 再帰での実装
- その他通常のセグメント木の注意点も参照

#### 関数
- `this[time, index]`: 時刻 $time$ での $index$ 番目の要素を取得する
- `Build(array)`: $array$ で再構築したセグメント木を返す
- `Fill(value)`: 全要素を $value$ で埋めて再構築したセグメント木を返す
- `Update(time, index, value)`: 時刻 $time$ での $index$ 番目の要素を $value$ で更新したセグメント木を返す
- `Fold(time, l, r)`: 時刻 $time$ でのセグメント木における区間 $[l, r)$ の積を取得する