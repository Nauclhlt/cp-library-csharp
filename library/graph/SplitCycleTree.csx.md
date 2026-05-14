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
  code: "#load \"GraphBase.csx\"\n#load \"DirectedGraph.csx\"\n#load \"DivideSCC.csx\"\
    \n\npublic partial class DirectedGraph<T>\n{\n    /// <summary>\n    /// Divides\
    \ the functional graph into cycles and trees. Time complexity is O(V+E).\n   \
    \ /// </summary>\n    public (List<List<int>> cycles, Graph<T> trees) SplitCycleTree(bool\
    \ sortCycle = false)\n    {\n        List<List<int>> scc = this.DivideSCC();\n\
    \n        List<List<int>> cycles = new();\n        Graph<T> tree = new(_vertexCount);\n\
    \n        for (int i = 0; i < scc.Count; i++)\n        {\n            if (scc[i].Count\
    \ == 1 && _adjList[scc[i][0]][0].To != scc[i][0])\n            {\n           \
    \     // part of the trees\n                int u = scc[i][0];\n             \
    \   tree.AddEdge(u, _adjList[u][0].To, _adjList[u][0].Weight);\n            }\n\
    \            else\n            {\n                // cycle\n                if\
    \ (sortCycle)\n                {\n                    List<int> sorted = new(scc[i].Count);\n\
    \                    sorted.Add(scc[i][0]);\n                    for (int j =\
    \ 1; j < scc[i].Count; j++)\n                    {\n                        sorted.Add(_adjList[sorted[^1]][0].To);\n\
    \                    }\n\n                    cycles.Add(sorted);\n          \
    \      }\n                else\n                {\n                    cycles.Add(scc[i]);\n\
    \                }\n            }\n        }\n\n        return (cycles, tree);\n\
    \    }\n}"
  dependsOn:
  - library/graph/GraphBase.csx
  isVerificationFile: false
  path: library/graph/SplitCycleTree.csx
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: LIBRARY_NO_TESTS
  verifiedWith: []
documentation_of: library/graph/SplitCycleTree.csx
layout: document
redirect_from:
- /library/library/graph/SplitCycleTree.csx
- /library/library/graph/SplitCycleTree.csx.html
title: library/graph/SplitCycleTree.csx
---
