---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
  _extendedRequiredBy: []
  _extendedVerifiedWith:
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
  code: "#load \"GraphBase.csx\"\n#load \"DirectedGraph.csx\"\n\npublic partial class\
    \ DirectedGraph<T>\n{\n    /// <summary>\n    /// Calculates the topological sort\
    \ of the vertices contained in the graph. Returns true if the graph is DAG and\
    \ sort is successfully completed, otherwise false.\n    /// Time complexity is\
    \ O(V+E).\n    /// </summary>\n    public bool TryTopologicalSort(out List<int>\
    \ sorted)\n    {\n        sorted = new List<int>(_vertexCount);\n\n        int[]\
    \ deg = new int[_vertexCount];\n        for (int i = 0; i < _directionAwareEdges.Count;\
    \ i++)\n        {\n            deg[_directionAwareEdges[i].To]++;\n        }\n\
    \n        Stack<int> stack = new();\n        for (int i = 0; i < _vertexCount;\
    \ i++)\n        {\n            if (deg[i] == 0) stack.Push(i);\n        }\n\n\
    \        while (stack.Count > 0)\n        {\n            int next = stack.Pop();\n\
    \            sorted.Add(next);\n\n            List<Edge<T>> p = _adjList[next];\n\
    \            for (int i = 0; i < p.Count; i++)\n            {\n              \
    \  deg[p[i].To]--;\n                if (deg[p[i].To] < 0) return false;\n\n  \
    \              if (deg[p[i].To] == 0)\n                {\n                   \
    \ stack.Push(p[i].To);\n                }\n            }\n        }\n\n      \
    \  return sorted.Count == _vertexCount;\n    }\n\n    /// <summary>\n    /// Calculates\
    \ the topological sort of the vertices contained in the graph. Returns true if\
    \ the graph is DAG, sort is successfully completed, and also the graph has only\
    \ one topological sort, otherwise false.\n    /// Time complexity is O(V+E).\n\
    \    /// </summary>\n    public bool TryUniqueTopologicalSort(out List<int> sorted)\n\
    \    {\n        sorted = new List<int>(_vertexCount);\n\n        int[] deg = new\
    \ int[_vertexCount];\n        for (int i = 0; i < _directionAwareEdges.Count;\
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
  timestamp: '2026-05-10 21:30:20+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/TopologicalSort.test.csx
documentation_of: library/graph/TopologicalSort.csx
layout: document
title: "Topological Sort(\u30C8\u30DD\u30ED\u30B8\u30AB\u30EB\u30BD\u30FC\u30C8)"
---

#### 説明

有向非巡回グラフ(DAG)の頂点を順に並べた列であって, 後に登場する頂点から前に登場する頂点への辺が存在するような $2$ 頂点のペアが無いようなものがトポロジカルソート.

アルゴリズムは単純で, 入次数が $0$ であるような頂点をひとつ選んで列に追加し, 削除するような操作を繰り返せば良い. (途中でそのような頂点を選べなくなれば, 閉路が存在する)

計算量は頂点数を $V$, 辺数を $E$ として $O(V+E)$.

トポロジカルソートが一意に定まるかどうかは, 入次数が $0$ である頂点がつねに $1$ つ, すなわち選ぶことができる頂点を入れておくstack(あるいはqueue)の要素数が $2$ 以上にならないという条件に言い換えられるため, これも判定できる.

#### 注意点
- とくになし

#### 関数
- `TryTopologicalSort(out sorted)`: トポロジカルソートが可能かどうかを返し, 可能であれば $sorted$ に結果が格納される
- `TryUniqueTopologicalSort(out sorted)`: トポロジカルソートが可能かつ一意に定まるかどうかを返し, そうであれば $sorted$ に結果が格納される