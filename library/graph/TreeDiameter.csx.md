---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: library/graph/GraphBase.csx
  _extendedRequiredBy: []
  _extendedVerifiedWith:
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
  code: "#load \"GraphBase.csx\"\n#load \"Graph.csx\"\n#load \"BFS.csx\"\n\npublic\
    \ partial class Graph<T>\n{\n    /// <summary>\n    /// Calculates the diameter\
    \ of the tree, the maximum length of simple paths contained in the tree. Time\
    \ complexity is O(V).\n    /// </summary>\n    public T GetDiameter()\n    {\n\
    \        if (_vertexCount - 1 != _edges.Count)\n        {\n            throw new\
    \ InvalidOperationException(\"Not a tree graph.\");\n        }\n\n        T[]\
    \ dist = this.BfsFrom(0);\n\n        T max = T.Zero;\n        int v = 0;\n   \
    \     for (int i = 0; i < _vertexCount; i++)\n        {\n            if (dist[i]\
    \ > max)\n            {\n                max = dist[i];\n                v = i;\n\
    \            }\n        }\n\n        dist = this.BfsFrom(v);\n\n        return\
    \ dist.Max();\n    }\n}"
  dependsOn:
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/TreeDiameter.csx
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/TreeDiameter.test.csx
documentation_of: library/graph/TreeDiameter.csx
layout: document
redirect_from:
- /library/library/graph/TreeDiameter.csx
- /library/library/graph/TreeDiameter.csx.html
title: library/graph/TreeDiameter.csx
---
