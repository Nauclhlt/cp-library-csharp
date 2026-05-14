---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
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
  code: "#load \"GraphBase.csx\"\n#load \"Graph.csx\"\n\npublic partial class Graph<T>\n\
    {\n    /// <summary>\n    /// Runs BFS. For trees, this returns the distances\
    \ from the specified vertex. Time complexity is O(V+E).\n    /// </summary>\n\
    \    public T[] BfsFrom(int n)\n    {\n        if (!Validate(n)) return null;\n\
    \n        bool[] seen = new bool[_vertexCount];\n\n        T[] map = new T[_vertexCount];\n\
    \        map[n] = T.Zero;\n\n        Queue<(int, T)> queue = new();\n\n      \
    \  queue.Enqueue((n, T.Zero));\n\n        while (queue.Count > 0)\n        {\n\
    \            (int p, T w) = queue.Dequeue();\n\n            if (seen[p]) continue;\n\
    \n            seen[p] = true;\n            map[p] = w;\n\n            List<Edge<T>>\
    \ children = _adjList[p];\n            for (int i = 0; i < children.Count; i++)\n\
    \            {\n                queue.Enqueue((children[i].To, w + children[i].Weight));\n\
    \            }\n        }\n\n        return map;\n    }\n}"
  dependsOn:
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/BFS.csx
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_NO_TESTS
  verifiedWith: []
documentation_of: library/graph/BFS.csx
layout: document
title: "BFS(\u5E45\u512A\u5148\u63A2\u7D22)"
---

#### 説明

木において, 異なる $2$ 頂点を結ぶ単純パスは一意に定まる. よって, 単一始点最短経路の問題はBFSを用いれば, グラフの頂点数を $V$ として $O(V)$ 時間で解ける.

#### 注意点
- 一般の無向グラフでは最短経路を返すとは限らない

#### 関数
- `BfsFrom(n)`: (木の場合)頂点 $n$ から各頂点への最短距離を表す配列を返す