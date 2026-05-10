---
data:
  _extendedDependsOn:
  - icon: ':question:'
    path: library/graph/GraphBase.csx
    title: library/graph/GraphBase.csx
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
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_NO_TESTS
  verifiedWith: []
documentation_of: library/graph/Graph.csx
layout: document
redirect_from:
- /library/library/graph/Graph.csx
- /library/library/graph/Graph.csx.html
title: library/graph/Graph.csx
---
