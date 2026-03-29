---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/data-structure/SegmentTree.csx
    title: Segment Tree
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
  code: "#load \"../../library/data-structure/SegmentTree.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.yosupo.jp/problem/point_add_range_sum\n\
    \nglobal using System.Runtime.CompilerServices;\n\nCPIO io = new();\n\nint N =\
    \ io.Int();\nint Q = io.Int();\n\nvar seg = new SegmentTree<long>(N, (x, y) =>\
    \ x + y, (x, y) => x + y, 0L);\nlong[] arr = io.LongArray(N);\nseg.Build(arr);\n\
    \nwhile (Q-- > 0)\n{\n    int t = io.Int();\n\n    if (t == 0)\n    {\n      \
    \  int p = io.Int();\n        long x = io.Long();\n        seg.Update(p, x);\n\
    \    }\n    else\n    {\n        int l = io.Int();\n        int r = io.Int();\n\
    \        io.Print(seg.Fold(l, r));\n    }\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/data-structure/SegmentTree.csx
  isVerificationFile: true
  path: verify/data-structure/SegmentTree.test.csx
  requiredBy: []
  timestamp: '2026-03-29 21:55:43+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/data-structure/SegmentTree.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/SegmentTree.test.csx
- /verify/verify/data-structure/SegmentTree.test.csx.html
title: verify/data-structure/SegmentTree.test.csx
---
