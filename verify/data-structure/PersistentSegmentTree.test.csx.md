---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/data-structure/PersistentSegmentTree.csx
    title: "Persistent Segment Tree(\u5B8C\u5168\u6C38\u7D9A\u30BB\u30B0\u30E1\u30F3\
      \u30C8\u6728)"
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.yosupo.jp/problem/range_kth_smallest
    links:
    - https://judge.yosupo.jp/problem/range_kth_smallest
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/data-structure/PersistentSegmentTree.csx\"\n#load \"\
    ../../library/utility/CPIO.csx\"\n// verification-helper: PROBLEM https://judge.yosupo.jp/problem/range_kth_smallest\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint N = io.Int();\n\
    int Q = io.Int();\nlong[] A = io.LongArray(N);\n\nlong[] values = A.Distinct().Order().ToArray();\n\
    Dictionary<long, int> valueToIndex = new();\nfor (int i = 0; i < values.Length;\
    \ i++)\n{\n    valueToIndex[values[i]] = i;\n}\n\nint[] times = new int[values.Length];\n\
    List<int>[] indices = new List<int>[values.Length];\nfor (int i = 0; i < values.Length;\
    \ i++) indices[i] = new();\n\nfor (int i = 0; i < N; i++)\n{\n    int idx = valueToIndex[A[i]];\n\
    \    indices[idx].Add(i);\n}\n\nPersistentSegmentTree<int> seg = new(N, (x, y)\
    \ => x + y, (x, a) => x + a, 0);\n\nint init = seg.Fill(0);\n\nfor (int i = 0;\
    \ i < values.Length; i++)\n{\n    int prev = -1;\n    if (i == 0) prev = init;\n\
    \    else prev = times[i - 1];\n\n    for (int j = 0; j < indices[i].Count; j++)\n\
    \    {\n        prev = seg.Update(prev, indices[i][j], 1);\n    }\n\n    times[i]\
    \ = prev;\n}\n\nwhile (Q-- > 0)\n{\n    int l = io.Int();\n    int r = io.Int();\n\
    \    int k = io.Int();\n\n    int left = 0;\n    int right = values.Length;\n\
    \    while (right > left)\n    {\n        int mid = left + (right - left) / 2;\n\
    \n        int c = seg.Fold(times[mid], l, r);\n        if (c <= k)\n        {\n\
    \            left = mid + 1;\n        }\n        else\n        {\n           \
    \ right = mid;\n        }\n    }\n\n    io.Print(values[left]);\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/data-structure/PersistentSegmentTree.csx
  isVerificationFile: true
  path: verify/data-structure/PersistentSegmentTree.test.csx
  requiredBy: []
  timestamp: '2026-06-07 13:52:56+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/data-structure/PersistentSegmentTree.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/PersistentSegmentTree.test.csx
- /verify/verify/data-structure/PersistentSegmentTree.test.csx.html
title: verify/data-structure/PersistentSegmentTree.test.csx
---
