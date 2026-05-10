---
data:
  _extendedDependsOn:
  - icon: ':x:'
    path: library/data-structure/LazySegmentTree.csx
    title: library/data-structure/LazySegmentTree.csx
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: true
  _pathExtension: csx
  _verificationStatusIcon: ':x:'
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
    \ => (x.b * y.c, x.b * y.b + y.c), 0L);\nMINT[] arr = new MINT[N];\nseg.Build(arr);\n\
    \nwhile (Q-- > 0)\n{\n    int t = io.Int();\n\n    if (t == 0)\n    {\n      \
    \  int l = io.Int();\n        int r = io.Int();\n        long b = io.Long();\n\
    \        long c = io.Long();\n        seg.Update(l, r, (b, c));\n    }\n    else\n\
    \    {\n        int l = io.Int();\n        int r = io.Int();\n        io.Print(seg.Fold(l,\
    \ r));\n    }\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/data-structure/LazySegmentTree.csx
  isVerificationFile: true
  path: verify/data-structure/LazySegmentTree.test.csx
  requiredBy: []
  timestamp: '2026-05-10 11:02:50+09:00'
  verificationStatus: TEST_WRONG_ANSWER
  verifiedWith: []
documentation_of: verify/data-structure/LazySegmentTree.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/LazySegmentTree.test.csx
- /verify/verify/data-structure/LazySegmentTree.test.csx.html
title: verify/data-structure/LazySegmentTree.test.csx
---
