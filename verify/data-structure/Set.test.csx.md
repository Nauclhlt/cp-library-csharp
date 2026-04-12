---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/data-structure/Set.csx
    title: Set
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.yosupo.jp/problem/ordered_set
    links:
    - https://judge.yosupo.jp/problem/ordered_set
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/data-structure/Set.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.yosupo.jp/problem/ordered_set\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint N = io.Int();\n\
    int Q = io.Int();\n\nSet<long> set = new();\n\nif (N > 0)\n{\n    long[] a = io.LongArray(N);\n\
    \    for (int i = 0; i < N; i++) set.Add(a[i]);\n}\nelse\n{\n    Console.ReadLine();\n\
    }\n\nfor (int i = 0; i < Q; i++)\n{\n    int t = io.Int();\n    long x = io.Long();\n\
    \n    if (t == 0)\n    {\n        if (!set.Contains(x)) set.Add(x);\n    }\n \
    \   else if (t == 1)\n    {\n        if (set.Contains(x)) set.Remove(x);\n   \
    \ }\n    else if (t == 2)\n    {\n        x--;\n        if (0 <= x && x < set.Count)\n\
    \        {\n            io.Print(set.GetByIndex((int)x));\n        }\n       \
    \ else\n        {\n            io.Print(-1);\n        }\n    }\n    else if (t\
    \ == 3)\n    {\n        io.Print(set.LowerBound(x + 1));\n    }\n    else if (t\
    \ == 4)\n    {\n        int p = set.LowerBound(x + 1);\n        p--;\n       \
    \ if (0 <= p && p < set.Count)\n        {\n            io.Print(set.GetByIndex(p));\n\
    \        }\n        else\n        {\n            io.Print(-1);\n        }\n  \
    \  }\n    else if (t == 5)\n    {\n        int p = set.LowerBound(x);\n      \
    \  if (0 <= p && p < set.Count)\n        {\n            io.Print(set.GetByIndex(p));\n\
    \        }\n        else\n        {\n            io.Print(-1);\n        }\n  \
    \  }\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/data-structure/Set.csx
  isVerificationFile: true
  path: verify/data-structure/Set.test.csx
  requiredBy: []
  timestamp: '2026-04-12 11:42:44+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/data-structure/Set.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/Set.test.csx
- /verify/verify/data-structure/Set.test.csx.html
title: verify/data-structure/Set.test.csx
---
