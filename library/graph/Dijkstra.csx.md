---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: library/graph/GraphBase.csx
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/graph/Dijkstra.test.csx
    title: verify/graph/Dijkstra.test.csx
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
    \ <summary>\n    /// Calculates the distances from vertex n using Dijkstra algorithm.\
    \ Do not use this for graphs with one or more negative cycles.\n    /// Time complexity\
    \ is O((E+V)logV).\n    /// </summary>\n    public T[] DijkstraFrom(int n)\n \
    \   {\n        if (!Validate(n)) return null;\n\n        bool[] seen = new bool[_vertexCount];\n\
    \        T[] map = new T[_vertexCount];\n        Array.Fill(map, T.MaxValue);\n\
    \n        map[n] = T.Zero;\n\n        PriorityQueue<int, T> pq = new();\n\n  \
    \      pq.Enqueue(n, T.Zero);\n\n        while (pq.Count > 0)\n        {\n   \
    \         int p = pq.Dequeue();\n\n            if (seen[p]) continue;\n\n    \
    \        seen[p] = true;\n\n            List<Edge<T>> children = _adjList[p];\n\
    \            for (int i = 0; i < children.Count; i++)\n            {\n       \
    \         T w = map[p] + children[i].Weight;\n                if (w < map[children[i].To])\n\
    \                {\n                    map[children[i].To] = w;\n           \
    \         pq.Enqueue(children[i].To, map[children[i].To]);\n                }\n\
    \            }\n        }\n\n        return map;\n    }\n\n    /// <summary>\n\
    \    /// Calculates the distances from vertex n using Dijkstra algorithm. Do not\
    \ use this for graphs with one or more negative cycles.\n    /// Time complexity\
    \ is O((E+V)logV).\n    /// </summary>\n    public T[] ImplicitDijkstraFrom(int\
    \ n)\n    {\n        if (!Validate(n)) \n            return null;\n\n        T[]\
    \ map = new T[_vertexCount];\n        Array.Fill(map, T.MaxValue);\n\n       \
    \ map[n] = T.Zero;\n\n        PriorityQueue<(int, T), T> pq = new();\n       \
    \ pq.Enqueue((n, T.Zero), T.Zero);\n\n        while (pq.Count > 0)\n        {\n\
    \            (int p, T d) = pq.Dequeue();\n\n            if (map[p] < d) continue;\n\
    \n            List<Edge<T>> children = _adjList[p];\n            for (int i =\
    \ 0; i < children.Count; i++)\n            {\n                T w = map[p] + children[i].Weight;\n\
    \                if (w < map[children[i].To])\n                {\n           \
    \         map[children[i].To] = w;\n                    pq.Enqueue((children[i].To,\
    \ map[children[i].To]), map[children[i].To]);\n                }\n           \
    \ }\n        }\n\n        return map;\n    }\n}"
  dependsOn:
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/Dijkstra.csx
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/Dijkstra.test.csx
documentation_of: library/graph/Dijkstra.csx
layout: document
redirect_from:
- /library/library/graph/Dijkstra.csx
- /library/library/graph/Dijkstra.csx.html
title: library/graph/Dijkstra.csx
---
