---
data:
  _extendedDependsOn:
  - icon: ':question:'
    path: library/graph/GraphBase.csx
    title: library/graph/GraphBase.csx
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
  code: "#load \"GraphBase.csx\"\n#load \"Graph.csx\"\n#load \"../data-structure/UnionFind.csx\"\
    \n\npublic partial class Graph<T>\n{\n    /// <summary>\n    /// Gets the sum\
    \ of weights of the edges in the maximum spanning tree of the graph.\n    ///\
    \ Time complexity is O(ElogE).\n    /// </summary>\n    public T MaxSpanningTreeWeight()\n\
    \    {\n        UnionFind unionFind = new(_vertexCount);\n\n        T ans = T.Zero;\n\
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
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/MST.csx
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/MST.test.csx
documentation_of: library/graph/MST.csx
layout: document
redirect_from:
- /library/library/graph/MST.csx
- /library/library/graph/MST.csx.html
title: library/graph/MST.csx
---
