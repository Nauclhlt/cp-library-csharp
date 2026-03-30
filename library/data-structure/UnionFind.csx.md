---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':warning:'
  attributes:
    links: []
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "/// <summary>\n/// Union-Find(disjoint set union).\n/// </summary>\npublic\
    \ sealed class UnionFind\n{\n    private int[] _parents;\n    private int[] _size;\n\
    \    private int _vertexCount;\n\n    public int VertexCount => _vertexCount;\n\
    \n    public UnionFind(int n)\n    {\n        _vertexCount = n;\n        _parents\
    \ = new int[n];\n        _size = new int[n];\n        for (int i = 0; i < n; i++)\n\
    \        {\n            _parents[i] = i;\n            _size[i] = 1;\n        }\n\
    \    }\n\n    /// <summary>\n    /// Gets the leader(root) of the connected component\
    \ x belongs to. Time complexity is O(\u03B1(n)).\n    /// </summary>\n    public\
    \ int Leader(int x)\n    {\n        if (_parents[x] == x)\n            return\
    \ x;\n        return _parents[x] = Leader(_parents[x]);\n    }\n\n    /// <summary>\n\
    \    /// Gets the size of the connected component x belongs to. Time complexity\
    \ is O(\u03B1(n)).\n    /// </summary>\n    public int Size(int x)\n    {\n  \
    \      return _size[Leader(x)];\n    }\n\n    /// <summary>\n    /// Merge the\
    \ two connected components. Time complexity is O(\u03B1(n)).\n    /// </summary>\n\
    \    public void Unite(int x, int y)\n    {\n        int rootX = Leader(x);\n\
    \        int rootY = Leader(y);\n        if (rootX == rootY)\n            return;\n\
    \            \n        int from = rootX;\n        int to = rootY;\n        \n\
    \        // union by size.(small-to-large merging)\n        if (_size[from] >\
    \ _size[to])\n        {\n            (from, to) = (to, from);\n        }\n\n \
    \       _size[to] += _size[from];\n        _parents[from] = to;\n    }\n\n   \
    \ /// <summary>\n    /// Gets the list of vertices which belong to the connected\
    \ component of x. Time complexity is O(n).\n    /// </summary>\n    public List<int>\
    \ GetGroup(int x)\n    {\n        int rootX = Leader(x);\n        List<int> set\
    \ = new List<int>();\n        for (int i = 0; i < _vertexCount; i++)\n       \
    \ {\n            if (Leader(i) == rootX)\n                set.Add(i);\n      \
    \  }\n\n        return set;\n    }\n\n    /// <summary>\n    /// Gets the vertex\
    \ list of all connected components. Time complexity is O(n).\n    /// </summary>\n\
    \    public Dictionary<int, List<int>> FindAll()\n    {\n        Dictionary<int,\
    \ List<int>> sets = new Dictionary<int, List<int>>();\n        for (int i = 0;\
    \ i < _vertexCount; i++)\n        {\n            int root = Leader(i);\n     \
    \       if (sets.ContainsKey(root))\n                sets[root].Add(i);\n    \
    \        else\n                sets[root] = new List<int>() { i };\n        }\n\
    \n        return sets;\n    }\n\n    /// <summary>\n    /// Determines if the\
    \ x and y belong to the same connected component. Time complexity is O(\u03B1\
    (n)).\n    /// </summary>\n    public bool Same(int x, int y)\n    {\n       \
    \ int rootX = Leader(x);\n        int rootY = Leader(y);\n        return rootX\
    \ == rootY;\n    }\n\n    /// <summary>\n    /// Clears the data. Time complexity\
    \ is O(n).\n    /// </summary>\n    public void Clear()\n    {\n        for (int\
    \ i = 0; i < _vertexCount; i++)\n        {\n            _parents[i] = i;\n   \
    \         _size[i] = 1;\n        }\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/data-structure/UnionFind.csx
  requiredBy: []
  timestamp: '2026-03-30 11:52:28+09:00'
  verificationStatus: LIBRARY_NO_TESTS
  verifiedWith: []
documentation_of: library/data-structure/UnionFind.csx
layout: document
title: Union-Find
---

#### 説明

Union-Findというデータ構造. またの名を素集合データ構造(disjoint-set-union, DSU).

無向グラフへの辺の追加, $2$ 頂点が同じ連結成分に属しているかの判定などが高速にできる. 具体的には $\alpha$ を逆アッカーマン関数として $O(\alpha(n))$ でできる操作がほとんど.

#### 注意点
- 経路圧縮+union-by-sizeで実装している

#### 関数
- `Leader(x)`: $x$ が属する連結成分の代表元を返す
- `Size(x)`: $x$ が属する連結成分の大きさを返す
- `Unite(x, y)`: $x, y$ が属する連結成分同士を併合する. ($x$ と $y$ の間に辺を張る)
- `GetGroup(x)`: $x$ とが属する連結成分に含まれる頂点のリストを返す
- `FindAll()`: 代表元と, それが属する連結成分の組をすべて返す
- `Same(x, y)`: $x$ と $y$ が同じ連結成分に属しているかを判定する
- `Clear()`: 内容をクリアする. (辺をすべて削除する)