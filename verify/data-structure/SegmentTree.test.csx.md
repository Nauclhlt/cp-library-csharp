---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: true
  _pathExtension: csx
  _verificationStatusIcon: ':x:'
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
  code: "// verification-helper: PROBLEM https://judge.yosupo.jp/problem/point_add_range_sum\n\
    \n#load \"../../library/data-structure/SegmentTree.cs\"\n\nstring[] nq = Console.ReadLine().Split();\n\
    int N = int.Parse(nq[0]);\nint Q = int.Parse(nq[1]);\n\nvar seg = new SegmentTree<long>(N,\
    \ (x, y) => x + y, (x, y) => x + y, 0L);\n\nlong[] arr = Console.ReadLine().Split().Select(x\
    \ => long.Parse(x)).ToArray();\nseg.Build(arr);\n\nwhile (Q-- > 0)\n{\n    var\
    \ q = Console.ReadLine().Split();\n    int t = int.Parse(q[0]);\n\n    if (t ==\
    \ 0)\n    {\n        int p = int.Parse(q[1]);\n        int x = int.Parse(q[2]);\n\
    \        seg.Update(p, x);\n    }\n    else\n    {\n        int l = int.Parse(q[1]);\n\
    \        int r = int.Parse(q[2]);\n        Console.WriteLine(seg.Fold(l, r));\n\
    \    }\n}"
  dependsOn: []
  isVerificationFile: true
  path: verify/data-structure/SegmentTree.test.csx
  requiredBy: []
  timestamp: '2026-03-28 23:41:09+09:00'
  verificationStatus: TEST_WRONG_ANSWER
  verifiedWith: []
documentation_of: verify/data-structure/SegmentTree.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/SegmentTree.test.csx
- /verify/verify/data-structure/SegmentTree.test.csx.html
title: verify/data-structure/SegmentTree.test.csx
---
