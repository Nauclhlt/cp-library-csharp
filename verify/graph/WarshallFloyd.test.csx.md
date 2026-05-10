---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: library/graph/GraphBase.csx
  - icon: ':heavy_check_mark:'
    path: library/graph/WarshallFloyd.csx
    title: library/graph/WarshallFloyd.csx
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_1_C
    links:
    - https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_1_C
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/graph/WarshallFloyd.csx\"\n#load \"../../library/graph/GraphBase.csx\"\
    \n#load \"../../library/graph/DirectedGraph.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_1_C\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint V = io.Int();\n\
    int E = io.Int();\n\nDirectedGraph<long> g = new(V);\n\nfor (int i = 0; i < E;\
    \ i++)\n{\n    int s = io.Int();\n    int t = io.Int();\n    long d = io.Long();\n\
    \n    g.AddEdge(s, t, d);\n}\n\nlong[,] dist = g.WarshallFloyd();\n\nfor (int\
    \ i = 0; i < V; i++)\n{\n    if (dist[i, i] < 0L)\n    {\n        io.Print(\"\
    NEGATIVE CYCLE\");\n        Console.Out.Flush();\n        return;\n    }\n}\n\n\
    for (int i = 0; i < V; i++)\n{\n    for (int j = 0; j < V; j++)\n    {\n     \
    \   if (j > 0) Console.Write(\" \");\n        if (dist[i, j] == long.MaxValue)\n\
    \        {\n            Console.Write(\"INF\");\n        }\n        else\n   \
    \     {\n            Console.Write(dist[i, j]);\n        }\n    }\n    Console.WriteLine();\n\
    }\n\nConsole.Out.Flush();"
  dependsOn:
  - library/graph/WarshallFloyd.csx
  - library/graph/GraphBase.csx
  isVerificationFile: true
  path: verify/graph/WarshallFloyd.test.csx
  requiredBy: []
  timestamp: '2026-05-10 21:30:20+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/graph/WarshallFloyd.test.csx
layout: document
redirect_from:
- /verify/verify/graph/WarshallFloyd.test.csx
- /verify/verify/graph/WarshallFloyd.test.csx.html
title: verify/graph/WarshallFloyd.test.csx
---
