---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
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
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_NO_TESTS
  verifiedWith: []
documentation_of: library/graph/DirectedGraph.csx
layout: document
redirect_from:
- /library/library/graph/DirectedGraph.csx
- /library/library/graph/DirectedGraph.csx.html
title: library/graph/DirectedGraph.csx
---
