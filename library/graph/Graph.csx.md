---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
  _extendedRequiredBy:
  - icon: ':heavy_check_mark:'
    path: library/graph/EulerTour.csx
    title: "Euler Tour(\u30AA\u30A4\u30E9\u30FC\u30C4\u30A2\u30FC)"
  - icon: ':heavy_check_mark:'
    path: library/graph/MST.csx
    title: "Minimum/Maximum Spanning Tree(\u30AF\u30E9\u30B9\u30AB\u30EB\u6CD5)"
  - icon: ':heavy_check_mark:'
    path: library/graph/TreeDiameter.csx
    title: library/graph/TreeDiameter.csx
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/graph/EulerTour.test.csx
    title: verify/graph/EulerTour.test.csx
  - icon: ':heavy_check_mark:'
    path: verify/graph/MST.test.csx
    title: verify/graph/MST.test.csx
  - icon: ':heavy_check_mark:'
    path: verify/graph/TreeDiameter.test.csx
    title: verify/graph/TreeDiameter.test.csx
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
  code: "#load \"GraphBase.csx\"\n\npublic partial class Graph<T> : GraphBase<T> where\
    \ T : struct, INumber<T>, IMinMaxValue<T>\n{\n    private List<Edge<T>> _edges;\n\
    \n    public List<Edge<T>> Edges => _edges;\n\n    public Graph(int vertexCount)\n\
    \    {\n        Initialize(vertexCount);\n        _edges = new();\n    }\n\n \
    \   public override void AddEdge(int a, int b, T weight)\n    {\n        if (!Validate(a)\
    \ || !Validate(b)) return;\n\n        if (a > b)\n        {\n            (a, b)\
    \ = (b, a);\n        }\n\n        Edge<T> right = new Edge<T>(a, b, weight);\n\
    \        Edge<T> left = new Edge<T>(b, a, weight);\n\n        _adjList[a].Add(right);\n\
    \        _adjList[b].Add(left);\n        _edges.Add(right);\n        _directionAwareEdges.Add(left);\n\
    \        _directionAwareEdges.Add(right);\n    }\n\n    public Graph<T> CreateComplement()\n\
    \    {\n        if ((long)_vertexCount * _vertexCount >= 100000000L)\n       \
    \ {\n            throw new InvalidOperationException(\"Too large graph.\");\n\
    \        }\n\n        HashSet<(int, int)> edgeSet = new();\n        for (int i\
    \ = 0; i < _edges.Count; i++)\n        {\n            edgeSet.Add((_edges[i].From,\
    \ _edges[i].To));\n        }\n\n        Graph<T> g = new(_vertexCount);\n\n  \
    \      for (int i = 0; i < _vertexCount - 1; i++)\n        {\n            for\
    \ (int j = i + 1; j < _vertexCount; j++)\n            {\n                if (!edgeSet.Contains((i,\
    \ j)))\n                {\n                    g.AddEdge(i, j, default);\n   \
    \             }\n            }\n        }\n\n        return g;\n    }\n\n    public\
    \ bool IsBipartite()\n    {\n        bool[] seen = new bool[_vertexCount];\n\n\
    \        Stack<(int, bool)> stack = new();\n\n        bool[] memo = new bool[_vertexCount];\n\
    \n        for (int i = 0; i < _vertexCount; i++)\n        {\n            stack.Push((i,\
    \ false));\n\n            while (stack.Count > 0)\n            {\n           \
    \     (int n, bool c) = stack.Pop();\n\n                if (seen[n])\n       \
    \         {\n                    if (memo[n] != !c) return false;\n          \
    \          continue;\n                }\n\n                seen[n] = true;\n \
    \               memo[n] = !c;\n\n                var ch = _adjList[n];\n     \
    \           for (int j = 0; j < ch.Count; j++)\n                {\n          \
    \          stack.Push((ch[j].To, !c));\n                }\n            }\n   \
    \     }\n\n        return true;\n    }\n}"
  dependsOn:
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/Graph.csx
  requiredBy:
  - library/graph/TreeDiameter.csx
  - library/graph/EulerTour.csx
  - library/graph/MST.csx
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/MST.test.csx
  - verify/graph/EulerTour.test.csx
  - verify/graph/TreeDiameter.test.csx
documentation_of: library/graph/Graph.csx
layout: document
title: "Graph(\u7121\u5411\u30B0\u30E9\u30D5)"
---

#### 説明

無向グラフを扱う.

#### 注意点
- とくになし

#### 関数
- `AddEdge(a, b, weight)`: $a$ と $b$ を結ぶ重み $weight$ の辺を追加する
- `CreateComplement()`: 補グラフを作成して返す
- `IsBipartite()`: 二部グラフかどうかを判定する