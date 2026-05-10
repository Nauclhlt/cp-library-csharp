---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: library/graph/GraphBase.csx
  - icon: ':heavy_check_mark:'
    path: library/graph/SCC.csx
    title: library/graph/SCC.csx
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.yosupo.jp/problem/scc
    links:
    - https://judge.yosupo.jp/problem/scc
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/graph/SCC.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.yosupo.jp/problem/scc\n\nglobal\
    \ using System.Collections;\nglobal using System.Runtime.CompilerServices;\nglobal\
    \ using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\nglobal\
    \ using System.Globalization;\n\nCPIO io = new();\n\nint N = io.Int();\nint M\
    \ = io.Int();\n\nDirectedGraph<int> g = new(N);\n\nfor (int i = 0; i < M; i++)\n\
    {\n    int a = io.Int();\n    int b = io.Int();\n\n    g.AddEdge(a, b, 0);\n}\n\
    \nList<List<int>> scc = g.DivideSCC();\nio.Print(scc.Count);\nfor (int i = 0;\
    \ i < scc.Count; i++)\n{\n    Console.Write(scc[i].Count + \" \");\n    io.Print(scc[i]);\n\
    }\n\nConsole.Out.Flush();"
  dependsOn:
  - library/graph/SCC.csx
  - library/graph/GraphBase.csx
  isVerificationFile: true
  path: verify/graph/SCC.test.csx
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/graph/SCC.test.csx
layout: document
redirect_from:
- /verify/verify/graph/SCC.test.csx
- /verify/verify/graph/SCC.test.csx.html
title: verify/graph/SCC.test.csx
---
