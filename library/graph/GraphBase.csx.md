---
data:
  _extendedDependsOn: []
  _extendedRequiredBy:
  - icon: ':warning:'
    path: library/graph/BFS.csx
    title: library/graph/BFS.csx
  - icon: ':heavy_check_mark:'
    path: library/graph/BellmannFord.csx
    title: library/graph/BellmannFord.csx
  - icon: ':heavy_check_mark:'
    path: library/graph/Dijkstra.csx
    title: library/graph/Dijkstra.csx
  - icon: ':warning:'
    path: library/graph/DirectedGraph.csx
    title: library/graph/DirectedGraph.csx
  - icon: ':warning:'
    path: library/graph/Graph.csx
    title: library/graph/Graph.csx
  - icon: ':heavy_check_mark:'
    path: library/graph/MST.csx
    title: library/graph/MST.csx
  - icon: ':heavy_check_mark:'
    path: library/graph/SCC.csx
    title: library/graph/SCC.csx
  - icon: ':warning:'
    path: library/graph/SplitCycleTree.csx
    title: library/graph/SplitCycleTree.csx
  - icon: ':heavy_check_mark:'
    path: library/graph/TopologicalSort.csx
    title: library/graph/TopologicalSort.csx
  - icon: ':heavy_check_mark:'
    path: library/graph/TreeDiameter.csx
    title: library/graph/TreeDiameter.csx
  - icon: ':heavy_check_mark:'
    path: library/graph/WarshallFloyd.csx
    title: library/graph/WarshallFloyd.csx
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/graph/BellmannFord.test.csx
    title: verify/graph/BellmannFord.test.csx
  - icon: ':heavy_check_mark:'
    path: verify/graph/Dijkstra.test.csx
    title: verify/graph/Dijkstra.test.csx
  - icon: ':heavy_check_mark:'
    path: verify/graph/MST.test.csx
    title: verify/graph/MST.test.csx
  - icon: ':heavy_check_mark:'
    path: verify/graph/SCC.test.csx
    title: verify/graph/SCC.test.csx
  - icon: ':heavy_check_mark:'
    path: verify/graph/TopologicalSort.test.csx
    title: verify/graph/TopologicalSort.test.csx
  - icon: ':heavy_check_mark:'
    path: verify/graph/TreeDiameter.test.csx
    title: verify/graph/TreeDiameter.test.csx
  - icon: ':heavy_check_mark:'
    path: verify/graph/WarshallFloyd.test.csx
    title: verify/graph/WarshallFloyd.test.csx
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
  code: "/// <summary>\n/// Abstract base class for graphs.\n/// </summary>\npublic\
    \ abstract partial class GraphBase<T> where T : struct, INumber<T>, IMinMaxValue<T>\n\
    {\n    protected List<List<Edge<T>>> _adjList;\n    protected List<Edge<T>> _directionAwareEdges;\n\
    \    protected int _vertexCount;\n\n    public int VertexCount => _vertexCount;\n\
    \    public List<List<Edge<T>>> AdjList => _adjList;\n    public List<Edge<T>>\
    \ DirectionAwareEdges => _directionAwareEdges;\n\n    protected void Initialize(int\
    \ vertexCount)\n    {\n        _vertexCount = vertexCount;\n        _adjList =\
    \ new(vertexCount);\n        for (int i = 0; i < vertexCount; i++)\n        {\n\
    \            _adjList.Add(new());\n        }\n        _directionAwareEdges = new();\n\
    \    }\n\n    public abstract void AddEdge(int a, int b, T weight);\n\n    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \    public bool Validate(int n)\n    {\n        return 0 <= n && n < _vertexCount;\n\
    \    }\n}\n\npublic readonly struct Edge<T> : IEquatable<Edge<T>>, IComparable<Edge<T>>\
    \ where T : struct, INumber<T>\n{\n    public readonly int To;\n    public readonly\
    \ int From;\n    public readonly T Weight;\n\n    public Edge(int to, T weight)\n\
    \    {\n        this.To = to;\n        this.Weight = weight;\n    }\n\n    public\
    \ Edge(int from, int to, T weight)\n    {\n        this.To = to;\n        this.From\
    \ = from;\n        this.Weight = weight;\n    }\n\n    public override bool Equals(object\
    \ obj)\n    {\n        if (obj is Edge<T> edge)\n        {\n            return\
    \ this.Equals(edge);\n        }\n        else\n        {\n            return false;\n\
    \        }\n    }\n\n    public int CompareTo(Edge<T> other)\n    {\n        return\
    \ Weight.CompareTo(other.Weight);\n    }\n\n    public bool Equals(Edge<T> edge)\n\
    \    {\n        return To == edge.To && From == edge.From && Weight == edge.Weight;\n\
    \    }\n\n    public override int GetHashCode()\n    {\n        return (To, From,\
    \ Weight).GetHashCode();\n    }\n\n    public static bool operator ==(Edge<T>\
    \ left, Edge<T> right)\n    {\n        return left.Equals(right);\n    }\n\n \
    \   public static bool operator !=(Edge<T> left, Edge<T> right)\n    {\n     \
    \   return !left.Equals(right);\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/graph/GraphBase.csx
  requiredBy:
  - library/graph/SplitCycleTree.csx
  - library/graph/BellmannFord.csx
  - library/graph/MST.csx
  - library/graph/TreeDiameter.csx
  - library/graph/DirectedGraph.csx
  - library/graph/BFS.csx
  - library/graph/WarshallFloyd.csx
  - library/graph/SCC.csx
  - library/graph/Dijkstra.csx
  - library/graph/Graph.csx
  - library/graph/TopologicalSort.csx
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/BellmannFord.test.csx
  - verify/graph/SCC.test.csx
  - verify/graph/MST.test.csx
  - verify/graph/TopologicalSort.test.csx
  - verify/graph/Dijkstra.test.csx
  - verify/graph/WarshallFloyd.test.csx
  - verify/graph/TreeDiameter.test.csx
documentation_of: library/graph/GraphBase.csx
layout: document
redirect_from:
- /library/library/graph/GraphBase.csx
- /library/library/graph/GraphBase.csx.html
title: library/graph/GraphBase.csx
---
