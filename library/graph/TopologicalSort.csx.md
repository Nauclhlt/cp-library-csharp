---
data:
  _extendedDependsOn:
  - icon: ':question:'
    path: library/graph/GraphBase.csx
    title: library/graph/GraphBase.csx
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':x:'
    path: verify/graph/TopologicalSort.test.csx
    title: verify/graph/TopologicalSort.test.csx
  _isVerificationFailed: true
  _pathExtension: csx
  _verificationStatusIcon: ':x:'
  attributes: {}
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"GraphBase.csx\"\n#load \"DirectedGraph.csx\"\n\npublic partial class\
    \ DirectedGraph<T>\n{\n    /// <summary>\n    /// Calculates the topological sort\
    \ of the vertices contained in the graph. Returns true if the graph is DAG and\
    \ sort is successfully completed, otherwise false.\n    /// Time complexity is\
    \ O(V+E).\n    /// </summary>\n    public bool TryTopologicalSort(out List<int>\
    \ sorted)\n    {\n        sorted = new List<int>(_vertexCount);\n\n        int[]\
    \ deg = new int[_vertexCount];\n        for (int i = 0; i < _directionAwareEdges.Count;\
    \ i++)\n        {\n            deg[_directionAwareEdges[i].To]++;\n        }\n\
    \n        Queue<int> queue = new();\n        for (int i = 0; i < _vertexCount;\
    \ i++)\n        {\n            if (deg[i] == 0) queue.Enqueue(i);\n        }\n\
    \n        while (queue.Count > 0)\n        {\n            int next = queue.Dequeue();\n\
    \            sorted.Add(next);\n\n            List<Edge<T>> p = _adjList[next];\n\
    \            for (int i = 0; i < p.Count; i++)\n            {\n              \
    \  deg[p[i].To]--;\n                if (deg[p[i].To] < 0) return false;\n\n  \
    \              if (deg[p[i].To] == 0)\n                {\n                   \
    \ queue.Enqueue(p[i].To);\n                }\n            }\n        }\n\n   \
    \     return sorted.Count == _vertexCount;\n    }\n\n    /// <summary>\n    ///\
    \ Calculates the topological sort of the vertices contained in the graph. Returns\
    \ true if the graph is DAG, sort is successfully completed, and also the graph\
    \ has only one topological sort, otherwise false.\n    /// Time complexity is\
    \ O(V+E).\n    /// </summary>\n    public bool TryUniqueTopologicalSort(out List<int>\
    \ sorted)\n    {\n        sorted = new List<int>(_vertexCount);\n\n        int[]\
    \ deg = new int[_vertexCount];\n        for (int i = 0; i < _directionAwareEdges.Count;\
    \ i++)\n        {\n            deg[_directionAwareEdges[i].To]++;\n        }\n\
    \n        Queue<int> queue = new();\n        for (int i = 0; i < _vertexCount;\
    \ i++)\n        {\n            if (deg[i] == 0) queue.Enqueue(i);\n        }\n\
    \n        while (queue.Count > 0)\n        {\n            if (queue.Count > 1)\
    \ return false;\n\n            int next = queue.Dequeue();\n            sorted.Add(next);\n\
    \n            List<Edge<T>> p = _adjList[next];\n            for (int i = 0; i\
    \ < p.Count; i++)\n            {\n                deg[p[i].To]--;\n          \
    \      if (deg[p[i].To] < 0) return false;\n\n                if (deg[p[i].To]\
    \ == 0)\n                {\n                    queue.Enqueue(p[i].To);\n    \
    \            }\n            }\n        }\n\n        return sorted.Count == _vertexCount;\n\
    \    }\n}"
  dependsOn:
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/TopologicalSort.csx
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_ALL_WA
  verifiedWith:
  - verify/graph/TopologicalSort.test.csx
documentation_of: library/graph/TopologicalSort.csx
layout: document
redirect_from:
- /library/library/graph/TopologicalSort.csx
- /library/library/graph/TopologicalSort.csx.html
title: library/graph/TopologicalSort.csx
---
