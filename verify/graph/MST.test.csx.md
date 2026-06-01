---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/Graph.csx
    title: "Graph(\u7121\u5411\u30B0\u30E9\u30D5)"
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
  - icon: ':heavy_check_mark:'
    path: library/graph/MST.csx
    title: "Minimum/Maximum Spanning Tree(\u30AF\u30E9\u30B9\u30AB\u30EB\u6CD5)"
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_2_A
    links:
    - https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_2_A
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/graph/MST.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_2_A\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint V = io.Int();\n\
    int E = io.Int();\n\nGraph<long> g = new(V);\n\nfor (int i = 0; i < E; i++)\n\
    {\n    int s = io.Int();\n    int t = io.Int();\n    long w = io.Long();\n\n \
    \   g.AddEdge(s, t, w);\n}\n\nio.Print(g.MinSpanningTreeWeight());\n\nConsole.Out.Flush();"
  dependsOn:
  - library/graph/Graph.csx
  - library/graph/MST.csx
  - library/graph/GraphBase.csx
  isVerificationFile: true
  path: verify/graph/MST.test.csx
  requiredBy: []
  timestamp: '2026-05-31 11:56:47+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/graph/MST.test.csx
layout: document
redirect_from:
- /verify/verify/graph/MST.test.csx
- /verify/verify/graph/MST.test.csx.html
title: verify/graph/MST.test.csx
---
