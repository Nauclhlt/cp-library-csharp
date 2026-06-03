---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/BFS.csx
    title: "BFS(\u5E45\u512A\u5148\u63A2\u7D22)"
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
  - icon: ':heavy_check_mark:'
    path: library/graph/TreeDiameter.csx
    title: "Tree Diameter(\u6728\u306E\u76F4\u5F84)"
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_5_A
    links:
    - https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_5_A
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/graph/TreeDiameter.csx\"\n#load \"../../library/graph/BFS.csx\"\
    \n#load \"../../library/utility/CPIO.csx\"\n// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_5_A\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint N = io.Int();\n\n\
    Graph<long> g = new(N);\n\nfor (int i = 0; i < N - 1; i++)\n{\n    int s = io.Int();\n\
    \    int t = io.Int();\n    long w = io.Long();\n\n    g.AddEdge(s, t, w);\n}\n\
    \nio.Print(g.GetDiameter());\n\nConsole.Out.Flush();"
  dependsOn:
  - library/graph/TreeDiameter.csx
  - library/graph/GraphBase.csx
  - library/graph/BFS.csx
  isVerificationFile: true
  path: verify/graph/TreeDiameter.test.csx
  requiredBy: []
  timestamp: '2026-06-01 17:36:36+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/graph/TreeDiameter.test.csx
layout: document
redirect_from:
- /verify/verify/graph/TreeDiameter.test.csx
- /verify/verify/graph/TreeDiameter.test.csx.html
title: verify/graph/TreeDiameter.test.csx
---
