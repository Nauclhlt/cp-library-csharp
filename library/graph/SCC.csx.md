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
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/graph/SCC.test.csx
    title: verify/graph/SCC.test.csx
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
  code: "#load \"DirectedGraph.csx\"\n\npublic partial class DirectedGraph<T>\n{\n\
    \    /// <summary>\n    /// Divides the vertices into strongly connected components.\
    \ Time complexity is O(V+E).\n    /// </summary>\n    public List<List<int>> DivideSCC()\n\
    \    {\n        bool[] seen = new bool[_vertexCount];\n        List<int> postorder\
    \ = new(_vertexCount);\n\n        void dfs1(int n)\n        {\n            seen[n]\
    \ = true;\n\n            var ch = _adjList[n];\n            for (int i = 0; i\
    \ < ch.Count; i++)\n            {\n                if (!seen[ch[i].To])\n    \
    \                dfs1(ch[i].To);\n            }\n\n            postorder.Add(n);\n\
    \        }\n\n        for (int i = 0; i < _vertexCount; i++)\n        {\n    \
    \        if (!seen[i])\n            {\n                dfs1(i);\n            }\n\
    \        }\n\n        Array.Clear(seen);\n\n        List<List<int>> res = new();\n\
    \        Stack<int> stack = new();\n\n        for (int i = postorder.Count - 1;\
    \ i >= 0; i--)\n        {\n            int p = postorder[i];\n            if (seen[p])\
    \ continue;\n\n            List<int> list = new();\n\n            stack.Push(p);\n\
    \n            while (stack.Count > 0)\n            {\n                int n =\
    \ stack.Pop();\n\n                if (seen[n]) continue;\n\n                seen[n]\
    \ = true;\n                list.Add(n);\n\n                var ch = _reverseAdjList[n];\n\
    \                for (int j = 0; j < ch.Count; j++)\n                {\n     \
    \               stack.Push(ch[j].To);\n                }\n            }\n\n  \
    \          res.Add(list);\n        }\n\n        return res;\n    }\n}"
  dependsOn:
  - library/graph/GraphBase.csx
  - library/graph/DirectedGraph.csx
  isVerificationFile: false
  path: library/graph/SCC.csx
  requiredBy: []
  timestamp: '2026-06-01 17:36:36+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/SCC.test.csx
documentation_of: library/graph/SCC.csx
layout: document
title: "Strongly Connected Components(\u5F37\u9023\u7D50\u6210\u5206\u5206\u89E3)"
---

#### 説明

有向グラフを強連結成分分解する.

強連結成分とは, 含まれる任意の $2$ 頂点間にパスが存在するような部分グラフのうち極大なもの. 強連結成分をひとまとまりに見たとき, DAGを成すので, トポロジカルソートの順に結果を返す.

計算量はグラフの頂点数, 辺数を $V, E$ として $O(V+E)$.

#### 注意点
- とくになし

#### 関数
- `DivideSCC()`: 強連結成分のリストを返す