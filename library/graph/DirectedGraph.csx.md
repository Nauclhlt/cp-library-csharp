---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
  _extendedRequiredBy:
  - icon: ':heavy_check_mark:'
    path: library/graph/SCC.csx
    title: "Strongly Connected Components(\u5F37\u9023\u7D50\u6210\u5206\u5206\u89E3\
      )"
  - icon: ':warning:'
    path: library/graph/SplitCycleTree.csx
    title: "Split-Cycle-Tree (\u9589\u8DEF+\u6728\u5206\u89E3)"
  - icon: ':heavy_check_mark:'
    path: library/graph/TopologicalSort.csx
    title: "Topological Sort(\u30C8\u30DD\u30ED\u30B8\u30AB\u30EB\u30BD\u30FC\u30C8\
      )"
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/graph/SCC.test.csx
    title: verify/graph/SCC.test.csx
  - icon: ':heavy_check_mark:'
    path: verify/graph/TopologicalSort.test.csx
    title: verify/graph/TopologicalSort.test.csx
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
  code: "#load \"GraphBase.csx\"\n\npublic partial class DirectedGraph<T> : GraphBase<T>\
    \ where T : struct, INumber<T>, IMinMaxValue<T>\n{\n    private List<List<Edge<T>>>\
    \ _reverseAdjList;\n    private List<Edge<T>> _reverseEdges;\n\n    public List<List<Edge<T>>>\
    \ ReverseAdjList => _reverseAdjList;\n    public List<Edge<T>> ReverseEdges =>\
    \ _reverseEdges;\n    public List<Edge<T>> Edges => _directionAwareEdges;\n\n\
    \    public DirectedGraph(int vertexCount)\n    {\n        Initialize(vertexCount);\n\
    \        _reverseAdjList = new(vertexCount);\n        for (int i = 0; i < vertexCount;\
    \ i++)\n        {\n            _reverseAdjList.Add(new());\n        }\n      \
    \  _reverseEdges = new();\n    }\n\n    public override void AddEdge(int a, int\
    \ b, T weight)\n    {\n        if (!Validate(a) || !Validate(b)) return;\n\n \
    \       Edge<T> e = new Edge<T>(a, b, weight);\n        Edge<T> rev = new Edge<T>(b,\
    \ a, weight);\n\n        _adjList[a].Add(e);\n        _reverseAdjList[b].Add(rev);\n\
    \        _directionAwareEdges.Add(e);\n        _reverseEdges.Add(rev);\n    }\n\
    }"
  dependsOn:
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/DirectedGraph.csx
  requiredBy:
  - library/graph/TopologicalSort.csx
  - library/graph/SCC.csx
  - library/graph/SplitCycleTree.csx
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/SCC.test.csx
  - verify/graph/TopologicalSort.test.csx
documentation_of: library/graph/DirectedGraph.csx
layout: document
title: "Directed Graph(\u6709\u5411\u30B0\u30E9\u30D5)"
---

#### 説明

有向グラフを扱う.

#### 注意点
- とくになし

#### 関数
- `AddEdge(a, b, weight)`: $a$ から $b$ への重み $weight$ の辺を追加する