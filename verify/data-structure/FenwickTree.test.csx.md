---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/data-structure/FenwickTree.csx
    title: library/data-structure/FenwickTree.csx
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.yosupo.jp/problem/point_add_range_sum
    links:
    - https://judge.yosupo.jp/problem/point_add_range_sum
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/data-structure/FenwickTree.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.yosupo.jp/problem/point_add_range_sum\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint N = io.Int();\n\
    int Q = io.Int();\n\nFenwickTree<long> ft = new(N);\nlong[] arr = io.LongArray(N);\n\
    ft.Build(arr);\n\nwhile (Q-- > 0)\n{\n    int t = io.Int();\n\n    if (t == 0)\n\
    \    {\n        int p = io.Int();\n        long x = io.Long();\n        ft.Add(p,\
    \ x);\n    }\n    else\n    {\n        int l = io.Int();\n        int r = io.Int();\n\
    \        io.Print(ft.Sum(l, r));\n    }\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/data-structure/FenwickTree.csx
  isVerificationFile: true
  path: verify/data-structure/FenwickTree.test.csx
  requiredBy: []
  timestamp: '2026-04-05 11:13:50+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/data-structure/FenwickTree.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/FenwickTree.test.csx
- /verify/verify/data-structure/FenwickTree.test.csx.html
title: verify/data-structure/FenwickTree.test.csx
---
