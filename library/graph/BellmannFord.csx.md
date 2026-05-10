---
data:
  _extendedDependsOn:
  - icon: ':question:'
    path: library/graph/GraphBase.csx
    title: library/graph/GraphBase.csx
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/graph/BellmannFord.test.csx
    title: verify/graph/BellmannFord.test.csx
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
    \ <summary>\n    /// Calculates the distances from vertex n using Bellmann-Ford\
    \ algorithm. Returns true if the graph contains at least one negative cycle, otherwise\
    \ false. \n    /// Time complexity is O(VE).\n    /// </summary>\n    public T[]\
    \ BellmannFordFrom(int n)\n    {\n        if (!Validate(n))\n        {\n     \
    \       return null;\n        }\n\n        T[] map = new T[_vertexCount];\n  \
    \      Array.Fill(map, T.MaxValue);\n\n        map[n] = T.Zero;\n\n        for\
    \ (int i = 0; i < _vertexCount - 1; i++)\n        {\n            for (int j =\
    \ 0; j < _directionAwareEdges.Count; j++)\n            {\n                Edge<T>\
    \ e = _directionAwareEdges[j];\n                if (map[e.From] == T.MaxValue)\
    \ continue;\n\n                T w = map[e.From] + e.Weight;\n               \
    \ if (w < map[e.To])\n                {\n                    map[e.To] = w;\n\
    \                }\n            }\n        }\n\n        bool[] negative = new\
    \ bool[_vertexCount];\n        for (int i = 0; i < _vertexCount; i++)\n      \
    \  {\n            for (int j = 0; j < _directionAwareEdges.Count; j++)\n     \
    \       {\n                Edge<T> e = _directionAwareEdges[j];\n            \
    \    if (map[e.From] == T.MaxValue) continue;\n\n                T w = map[e.From]\
    \ + e.Weight;\n                if (w < map[e.To])\n                {\n       \
    \             map[e.To] = w;\n                    negative[e.To] = true;\n   \
    \             }\n                if (negative[e.From])\n                {\n  \
    \                  negative[e.To] = true;\n                }\n            }\n\
    \        }\n\n        for (int i = 0; i < _vertexCount; i++)\n        {\n    \
    \        if (negative[i])\n            {\n                map[i] = T.MinValue;\n\
    \            }\n        }\n\n        return map;\n    }\n}"
  dependsOn:
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/BellmannFord.csx
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/BellmannFord.test.csx
documentation_of: library/graph/BellmannFord.csx
layout: document
redirect_from:
- /library/library/graph/BellmannFord.csx
- /library/library/graph/BellmannFord.csx.html
title: library/graph/BellmannFord.csx
---
