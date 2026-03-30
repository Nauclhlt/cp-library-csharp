---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/data-structure/SparseTable.csx
    title: Sparse Table
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.yosupo.jp/problem/staticrmq
    links:
    - https://judge.yosupo.jp/problem/staticrmq
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/data-structure/SparseTable.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.yosupo.jp/problem/staticrmq\n\n\
    global using System.Runtime.CompilerServices;\n\nCPIO io = new();\n\nint N = io.Int();\n\
    int Q = io.Int();\n\nlong[] a = io.LongArray(N);\n\nSparseTable<long> table =\
    \ new(a, long.MaxValue, long.Min);\n\nwhile (Q-- > 0)\n{\n    int l = io.Int();\n\
    \    int r = io.Int();\n\n    io.Print(table.Fold(l, r));\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/data-structure/SparseTable.csx
  isVerificationFile: true
  path: verify/data-structure/SparseTable.test.csx
  requiredBy: []
  timestamp: '2026-03-30 12:01:12+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/data-structure/SparseTable.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/SparseTable.test.csx
- /verify/verify/data-structure/SparseTable.test.csx.html
title: verify/data-structure/SparseTable.test.csx
---
