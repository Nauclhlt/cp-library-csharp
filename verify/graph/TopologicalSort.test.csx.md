---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
  - icon: ':heavy_check_mark:'
    path: library/graph/TopologicalSort.csx
    title: library/graph/TopologicalSort.csx
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_4_A
    links:
    - https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_4_A
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/graph/TopologicalSort.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_4_A\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint V = io.Int();\n\
    int E = io.Int();\n\nDirectedGraph<int> g = new(V);\n\nfor (int i = 0; i < E;\
    \ i++)\n{\n    int s = io.Int();\n    int t = io.Int();\n\n    g.AddEdge(s, t,\
    \ 0);\n}\n\nio.Print(g.TryTopologicalSort(out List<int> _) ? \"0\" : \"1\");\n\
    \nConsole.Out.Flush();"
  dependsOn:
  - library/graph/GraphBase.csx
  - library/graph/TopologicalSort.csx
  isVerificationFile: true
  path: verify/graph/TopologicalSort.test.csx
  requiredBy: []
  timestamp: '2026-05-10 21:47:32+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/graph/TopologicalSort.test.csx
layout: document
redirect_from:
- /verify/verify/graph/TopologicalSort.test.csx
- /verify/verify/graph/TopologicalSort.test.csx.html
title: verify/graph/TopologicalSort.test.csx
---
