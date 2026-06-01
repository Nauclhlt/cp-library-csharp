---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/Graph.csx
    title: "Graph(\u7121\u5411\u30B0\u30E9\u30D5)"
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/graph/MST.test.csx
    title: verify/graph/MST.test.csx
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
  code: "#load \"Graph.csx\"\n#load \"../data-structure/UnionFind.csx\"\n\npublic\
    \ partial class Graph<T>\n{\n    /// <summary>\n    /// Gets the sum of weights\
    \ of the edges in the maximum spanning tree of the graph.\n    /// Time complexity\
    \ is O(ElogE).\n    /// </summary>\n    public T MaxSpanningTreeWeight()\n   \
    \ {\n        UnionFind unionFind = new(_vertexCount);\n\n        T ans = T.Zero;\n\
    \        foreach (var edge in _edges.OrderByDescending(x => x.Weight))\n     \
    \   {\n            if (!unionFind.Same(edge.From, edge.To))\n            {\n \
    \               unionFind.Unite(edge.From, edge.To);\n                ans += edge.Weight;\n\
    \            }\n        }\n\n        return ans;\n    }\n\n    /// <summary>\n\
    \    /// Gets the sum of weights of the edges in the minimum spanning tree of\
    \ the graph.\n    /// Time complexity is O(ElogE).\n    /// </summary>\n    public\
    \ T MinSpanningTreeWeight()\n    {\n        UnionFind unionFind = new(_vertexCount);\n\
    \n        T ans = T.Zero;\n        foreach (var edge in _edges.OrderBy(x => x.Weight))\n\
    \        {\n            if (!unionFind.Same(edge.From, edge.To))\n           \
    \ {\n                unionFind.Unite(edge.From, edge.To);\n                ans\
    \ += edge.Weight;\n            }\n        }\n\n        return ans;\n    }\n}"
  dependsOn:
  - library/graph/Graph.csx
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/MST.csx
  requiredBy: []
  timestamp: '2026-05-31 11:56:47+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/MST.test.csx
documentation_of: library/graph/MST.csx
layout: document
title: "Minimum/Maximum Spanning Tree(\u30AF\u30E9\u30B9\u30AB\u30EB\u6CD5)"
---

#### 説明

クラスカル(Kruskal)法を用いて, 最大/最小全域木に含まれる辺の重みの総和を求める.

辺を重みの順にソートして連結成分数が減るなら採用するという貪欲法で, グラフの頂点数, 辺数を $V, E$ として $O(V\alpha(V)+E\log E)$ で求まる.

#### 注意点
- とくになし

#### 関数
- `MaxSpanningTreeWeight()`: 最大全域木に含まれる辺の重みの総和を求める
- `MinSpanningTreeWeight()`: 最小全域木に含まれる辺の重みの総和を求める