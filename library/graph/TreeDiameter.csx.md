---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/BFS.csx
    title: "BFS(\u5E45\u512A\u5148\u63A2\u7D22)"
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
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
  code: "#load \"BFS.csx\"\n#load \"Graph.csx\"\n\npublic partial class Graph<T>\n\
    {\n    /// <summary>\n    /// Calculates the diameter of the tree, the maximum\
    \ length of simple paths contained in the tree. Time complexity is O(V).\n   \
    \ /// </summary>\n    public T GetDiameter()\n    {\n        if (_vertexCount\
    \ - 1 != _edges.Count)\n        {\n            throw new InvalidOperationException(\"\
    Not a tree graph.\");\n        }\n\n        T[] dist = this.BfsFrom(0);\n\n  \
    \      T max = T.Zero;\n        int v = 0;\n        for (int i = 0; i < _vertexCount;\
    \ i++)\n        {\n            if (dist[i] > max)\n            {\n           \
    \     max = dist[i];\n                v = i;\n            }\n        }\n\n   \
    \     dist = this.BfsFrom(v);\n\n        return dist.Max();\n    }\n\n    public\
    \ (int, int) GetDiameterPair(out T diameter)\n    {\n        if (_vertexCount\
    \ - 1 != _edges.Count)\n        {\n            throw new InvalidOperationException(\"\
    Not a tree graph.\");\n        }\n\n        T[] dist = this.BfsFrom(0);\n\n  \
    \      T max = T.Zero;\n        int v = 0;\n        for (int i = 0; i < _vertexCount;\
    \ i++)\n        {\n            if (dist[i] > max)\n            {\n           \
    \     max = dist[i];\n                v = i;\n            }\n        }\n\n   \
    \     dist = this.BfsFrom(v);\n        diameter = dist.Max();\n        int u =\
    \ -1;\n        for (int i = 0; i < _vertexCount; i++)\n        {\n           \
    \ if (diameter == dist[i])\n            {\n                u = i;\n          \
    \      break;\n            }\n        }\n\n        return (u, v);\n    }\n}"
  dependsOn:
  - library/graph/GraphBase.csx
  - library/graph/BFS.csx
  isVerificationFile: false
  path: library/graph/TreeDiameter.csx
  requiredBy: []
  timestamp: '2026-06-01 17:36:36+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/TreeDiameter.test.csx
documentation_of: library/graph/TreeDiameter.csx
layout: document
title: "Tree Diameter(\u6728\u306E\u76F4\u5F84)"
---

#### 説明

木上の単純パスに含まれる辺の数の最大値をその木の直径という.

これは以下のアルゴリズムによって, 頂点数を $V$ として $O(V)$ 時間で求まる.

- 適当な頂点から最遠の頂点 $v$ をひとつ求める
- $v$ から最遠の頂点 $u$ をひとつ求める
- $u$ と $v$ を結ぶ単純パスに含まれる辺の数が直径である. すなわち, $u$ と $v$ は直径の両端の頂点である

#### 注意点
- とくになし

#### 関数
- `GetDiameter()`: 木の直径を求める
- `GetDiameterPair(out diameter)`: 木の直径の両端の頂点ペアをひとつ求める. そのさい $diameter$ に直径の値も格納される