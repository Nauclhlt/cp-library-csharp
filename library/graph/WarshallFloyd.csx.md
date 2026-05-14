---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
  _extendedRequiredBy: []
  _extendedVerifiedWith:
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
  code: "#load \"GraphBase.csx\"\n\npublic partial class GraphBase<T>\n{\n    ///\
    \ <summary>\n    /// Calculates the distances between any two vertices contained\
    \ in the graph. Time complexity is O(E+V^3).\n    /// </summary>\n    public T[,]\
    \ WarshallFloyd()\n    {\n        if (_vertexCount > 800)\n        {\n       \
    \     throw new InvalidOperationException(\"Too large graph.\");\n        }\n\n\
    \        T[,] map = new T[_vertexCount, _vertexCount];\n\n        for (int i =\
    \ 0; i < _vertexCount; i++)\n        {\n            for (int j = 0; j < _vertexCount;\
    \ j++)\n            {\n                map[i, j] = T.MaxValue;\n            }\n\
    \        }\n\n        for (int i = 0; i < _vertexCount; i++)\n        {\n    \
    \        map[i, i] = T.Zero;\n        }\n\n        for (int i = 0; i < _directionAwareEdges.Count;\
    \ i++)\n        {\n            Edge<T> e = _directionAwareEdges[i];\n        \
    \    map[e.From, e.To] = T.Min(e.Weight, map[e.From, e.To]);\n        }\n\n  \
    \      for (int k = 0; k < _vertexCount; k++)\n        {\n            for (int\
    \ i = 0; i < _vertexCount; i++)\n            {\n                for (int j = 0;\
    \ j < _vertexCount; j++)\n                {\n                    if (map[i, k]\
    \ != T.MaxValue && map[k, j] != T.MaxValue)\n                    {\n         \
    \               if (map[i, k] + map[k, j] < map[i, j])\n                     \
    \   {\n                            map[i, j] = map[i, k] + map[k, j];\n      \
    \                  }\n                    }\n                }\n            }\n\
    \        }\n\n        return map;\n    }\n}"
  dependsOn:
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/WarshallFloyd.csx
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/WarshallFloyd.test.csx
documentation_of: library/graph/WarshallFloyd.csx
layout: document
redirect_from:
- /library/library/graph/WarshallFloyd.csx
- /library/library/graph/WarshallFloyd.csx.html
title: library/graph/WarshallFloyd.csx
---
