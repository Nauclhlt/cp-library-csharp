---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/EulerTour.csx
    title: "Euler Tour(\u30AA\u30A4\u30E9\u30FC\u30C4\u30A2\u30FC)"
  - icon: ':heavy_check_mark:'
    path: library/graph/Graph.csx
    title: "Graph(\u7121\u5411\u30B0\u30E9\u30D5)"
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_5_C
    links:
    - https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_5_C
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/graph/EulerTour.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_5_C\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint N = io.Int();\n\n\
    Graph<int> g = new(N);\n\nfor (int i = 0; i < N; i++)\n{\n    int k = io.Int();\n\
    \    for (int j = 0; j < k; j++)\n    {\n        int c = io.Int();\n        g.AddEdge(i,\
    \ c, 1);\n    }\n}\n\nvar et = g.ConstructEulerTour<int>(root: 0);\n\nint Q =\
    \ io.Int();\n\nfor (int i = 0; i < Q; i++)\n{\n    int u = io.Int();\n    int\
    \ v = io.Int();\n\n    io.Print(et.Lca(u, v));\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/graph/GraphBase.csx
  - library/graph/Graph.csx
  - library/graph/EulerTour.csx
  isVerificationFile: true
  path: verify/graph/EulerTour.test.csx
  requiredBy: []
  timestamp: '2026-05-31 11:56:47+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/graph/EulerTour.test.csx
layout: document
redirect_from:
- /verify/verify/graph/EulerTour.test.csx
- /verify/verify/graph/EulerTour.test.csx.html
title: verify/graph/EulerTour.test.csx
---
