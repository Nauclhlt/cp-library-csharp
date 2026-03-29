---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/data-structure/Deque.csx
    title: Deque
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.yosupo.jp/problem/deque
    links:
    - https://judge.yosupo.jp/problem/deque
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/data-structure/Deque.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.yosupo.jp/problem/deque\n\nglobal\
    \ using System.Runtime.CompilerServices;\nglobal using System.Collections;\n\n\
    CPIO io = new();\n\nint Q = io.Int();\n\nDeque<long> deque = new();\n\nwhile (Q--\
    \ > 0)\n{\n    int q = io.Int();\n\n    if (q == 0)\n    {\n        long x = io.Long();\n\
    \        deque.PushFront(x);\n    }\n    else if (q == 1)\n    {\n        long\
    \ x = io.Long();\n        deque.PushBack(x);\n    }\n    else if (q == 2)\n  \
    \  {\n        deque.PopFront();\n    }\n    else if (q == 3)\n    {\n        deque.PopBack();\n\
    \    }\n    else if (q == 4)\n    {\n        int i = io.Int();\n        io.Print(deque[i]);\n\
    \    }\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/data-structure/Deque.csx
  isVerificationFile: true
  path: verify/data-structure/Deque.test.csx
  requiredBy: []
  timestamp: '2026-03-30 02:29:29+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/data-structure/Deque.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/Deque.test.csx
- /verify/verify/data-structure/Deque.test.csx.html
title: verify/data-structure/Deque.test.csx
---
