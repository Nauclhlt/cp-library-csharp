---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/DirectedGraph.csx
    title: "Directed Graph(\u6709\u5411\u30B0\u30E9\u30D5)"
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
  code: "#load \"DirectedGraph.csx\"\n#load \"SCC.csx\"\n\npublic partial class DirectedGraph<T>\n\
    {\n    /// <summary>\n    /// Divides the functional graph into cycles and trees.\
    \ Time complexity is O(V+E).\n    /// </summary>\n    public (List<List<int>>\
    \ cycles, Graph<T> trees) SplitCycleTree(bool sortCycle = false)\n    {\n    \
    \    List<List<int>> scc = this.DivideSCC();\n\n        List<List<int>> cycles\
    \ = new();\n        Graph<T> tree = new(_vertexCount);\n\n        for (int i =\
    \ 0; i < scc.Count; i++)\n        {\n            if (scc[i].Count == 1 && _adjList[scc[i][0]][0].To\
    \ != scc[i][0])\n            {\n                // part of the trees\n       \
    \         int u = scc[i][0];\n                tree.AddEdge(u, _adjList[u][0].To,\
    \ _adjList[u][0].Weight);\n            }\n            else\n            {\n  \
    \              // cycle\n                if (sortCycle)\n                {\n \
    \                   List<int> sorted = new(scc[i].Count);\n                  \
    \  sorted.Add(scc[i][0]);\n                    for (int j = 1; j < scc[i].Count;\
    \ j++)\n                    {\n                        sorted.Add(_adjList[sorted[^1]][0].To);\n\
    \                    }\n\n                    cycles.Add(sorted);\n          \
    \      }\n                else\n                {\n                    cycles.Add(scc[i]);\n\
    \                }\n            }\n        }\n\n        return (cycles, tree);\n\
    \    }\n}"
  dependsOn:
  - library/graph/DirectedGraph.csx
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/SplitCycleTree.csx
  requiredBy: []
  timestamp: '2026-06-01 17:36:36+09:00'
  verificationStatus: LIBRARY_NO_TESTS
  verifiedWith: []
documentation_of: library/graph/SplitCycleTree.csx
layout: document
title: "Split-Cycle-Tree (\u9589\u8DEF+\u6728\u5206\u89E3)"
---

#### 説明

Functional Graph(任意の頂点の出次数が $1$ であるような有向グラフ) において, 各弱連結成分(辺の向きをなくした無向グラフにおける連結成分) に着目すると, 有向閉路がひとつ存在し, それに含まれるいくつかの頂点に有向木が刺さったような形をしている.

そこで, このグラフを閉路のリスト+木の部分のグラフに分割することで, (閉路に沿った木DPなど) 一定の目的で実装がしやすくなる(と思う).

#### 注意点
- 内部で強連結成分分解を利用していることに注意

#### 関数
- `SplitCycleTree(sortCycle)`: グラフを閉路のリストと木に分解する. $sortCycle$ フラグが `true` なら, 閉路に登場する順に頂点をソートして返す