---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/data-structure/SparseTable.csx
    title: Sparse Table
  - icon: ':heavy_check_mark:'
    path: library/data-structure/SparseTable2D.csx
    title: library/data-structure/SparseTable2D.csx
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=1068
    links:
    - https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=1068
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/data-structure/SparseTable2D.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=1068\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nwhile (true)\n{\n\n\
    \    int R = io.Int();\n    int C = io.Int();\n    int Q = io.Int();\n\n    if\
    \ (R == 0) break;\n\n    int[,] grid = new int[R, C];\n    for (int y = 0; y <\
    \ R; y++)\n    {\n        int[] row = io.IntArray(C);\n        for (int x = 0;\
    \ x < C; x++)\n        {\n            grid[y, x] = row[x];\n        }\n    }\n\
    \n    SparseTable2D<int> st = new(grid, int.MaxValue, int.Min);\n\n    for (int\
    \ i = 0; i < Q; i++)\n    {\n        int r1 = io.Int();\n        int c1 = io.Int();\n\
    \        int r2 = io.Int() + 1;\n        int c2 = io.Int() + 1;\n\n        io.Print(st.Fold(c1,\
    \ r1, c2, r2));\n    }\n\n    Console.Out.Flush();\n}\n"
  dependsOn:
  - library/data-structure/SparseTable.csx
  - library/data-structure/SparseTable2D.csx
  isVerificationFile: true
  path: verify/data-structure/SparseTable2D.test.csx
  requiredBy: []
  timestamp: '2026-06-01 18:17:15+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/data-structure/SparseTable2D.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/SparseTable2D.test.csx
- /verify/verify/data-structure/SparseTable2D.test.csx.html
title: verify/data-structure/SparseTable2D.test.csx
---
