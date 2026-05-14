---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/BellmannFord.csx
    title: "Bellmann-Ford\u6CD5"
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_1_B
    links:
    - https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_1_B
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/graph/BellmannFord.csx\"\n#load \"../../library/graph/GraphBase.csx\"\
    \n#load \"../../library/graph/DirectedGraph.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_1_B\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint V = io.Int();\n\
    int E = io.Int();\nint r = io.Int();\n\nDirectedGraph<long> g = new(V);\n\nfor\
    \ (int i = 0; i < E; i++)\n{\n    int s = io.Int();\n    int t = io.Int();\n \
    \   long d = io.Long();\n    g.AddEdge(s, t, d);\n}\n\nlong[] dist = g.BellmannFordFrom(r);\n\
    \nfor (int i = 0; i < V; i++)\n{\n    if (dist[i] == long.MinValue)\n    {\n \
    \       io.Print(\"NEGATIVE CYCLE\");\n        Console.Out.Flush();\n        return;\n\
    \    }\n}\n\nfor (int i = 0; i < V; i++)\n{\n    if (dist[i] == long.MaxValue)\n\
    \        io.Print(\"INF\");\n    else\n        io.Print(dist[i]);\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/graph/BellmannFord.csx
  - library/graph/GraphBase.csx
  isVerificationFile: true
  path: verify/graph/BellmannFord.test.csx
  requiredBy: []
  timestamp: '2026-05-14 21:28:54+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/graph/BellmannFord.test.csx
layout: document
redirect_from:
- /verify/verify/graph/BellmannFord.test.csx
- /verify/verify/graph/BellmannFord.test.csx.html
title: verify/graph/BellmannFord.test.csx
---
