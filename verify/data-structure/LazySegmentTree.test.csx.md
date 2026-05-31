---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/data-structure/LazySegmentTree.csx
    title: "Lazy Segment Tree(\u9045\u5EF6\u8A55\u4FA1\u30BB\u30B0\u30E1\u30F3\u30C8\
      \u6728)"
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.yosupo.jp/problem/range_affine_range_sum
    links:
    - https://judge.yosupo.jp/problem/range_affine_range_sum
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/data-structure/LazySegmentTree.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n#load \"../../library/math/ModInt.csx\"\n// verification-helper: PROBLEM https://judge.yosupo.jp/problem/range_affine_range_sum\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\nusing MINT = ModInt<Mod998244353>;\n\nCPIO\
    \ io = new();\n\nint N = io.Int();\nint Q = io.Int();\n\nvar seg = new LazySegmentTree<MINT,\
    \ (MINT b, MINT c)>(N, (x, y) => x + y, (x, a, l) => x * a.b + l * a.c, (x, y)\
    \ => (x.b * y.b, y.b * x.c + y.c), 0L);\nMINT[] arr = new MINT[N];\nfor (int i\
    \ = 0; i < N; i++) arr[i] = io.Long();\nseg.Build(arr);\n\nwhile (Q-- > 0)\n{\n\
    \    int t = io.Int();\n\n    if (t == 0)\n    {\n        int l = io.Int();\n\
    \        int r = io.Int();\n        long b = io.Long();\n        long c = io.Long();\n\
    \        seg.Update(l, r, (b, c));\n    }\n    else\n    {\n        int l = io.Int();\n\
    \        int r = io.Int();\n        io.Print(seg.Fold(l, r).Value.ToString());\n\
    \    }\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/data-structure/LazySegmentTree.csx
  isVerificationFile: true
  path: verify/data-structure/LazySegmentTree.test.csx
  requiredBy: []
  timestamp: '2026-05-10 15:24:54+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/data-structure/LazySegmentTree.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/LazySegmentTree.test.csx
- /verify/verify/data-structure/LazySegmentTree.test.csx.html
title: verify/data-structure/LazySegmentTree.test.csx
---
