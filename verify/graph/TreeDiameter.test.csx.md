---
data:
  _extendedDependsOn:
  - icon: ':question:'
    path: library/graph/GraphBase.csx
    title: library/graph/GraphBase.csx
  - icon: ':x:'
    path: library/graph/TreeDiameter.csx
    title: library/graph/TreeDiameter.csx
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: true
  _pathExtension: csx
  _verificationStatusIcon: ':x:'
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
  code: "#load \"../../library/graph/TreeDiameter.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_2_A\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint N = io.Int();\n\n\
    Graph<long> g = new(N);\n\nfor (int i = 0; i < N - 1; i++)\n{\n    int s = io.Int();\n\
    \    int t = io.Int();\n    long w = io.Long();\n\n    g.AddEdge(s, t, w);\n}\n\
    \nio.Print(g.GetDiameter());\n\nConsole.Out.Flush();"
  dependsOn:
  - library/graph/TreeDiameter.csx
  - library/graph/GraphBase.csx
  isVerificationFile: true
  path: verify/graph/TreeDiameter.test.csx
  requiredBy: []
  timestamp: '2026-05-10 21:00:58+09:00'
  verificationStatus: TEST_WRONG_ANSWER
  verifiedWith: []
documentation_of: verify/graph/TreeDiameter.test.csx
layout: document
redirect_from:
- /verify/verify/graph/TreeDiameter.test.csx
- /verify/verify/graph/TreeDiameter.test.csx.html
title: verify/graph/TreeDiameter.test.csx
---
