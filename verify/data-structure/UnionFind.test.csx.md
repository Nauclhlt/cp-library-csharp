---
data:
  _extendedDependsOn:
  - icon: ':question:'
    path: library/utility/CPIO.csx
    title: CPIO
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: true
  _pathExtension: csx
  _verificationStatusIcon: ':x:'
  attributes:
    PROBLEM: https://judge.yosupo.jp/problem/unionfind
    links:
    - https://judge.yosupo.jp/problem/unionfind
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/utility/CPIO.csx\"\n#load \"../../library/data-structure/UnionFind.csx\"\
    \n// verification-helper: PROBLEM https://judge.yosupo.jp/problem/unionfind\n\n\
    global using System.Runtime.CompilerServices;\n\nCPIO io = new();\n\nint N = io.Int();\n\
    int Q = io.Int();\n\nUnionFind uf = new(Q);\n\nwhile (Q-- > 0)\n{\n    int t =\
    \ io.Int();\n    int u = io.Int();\n    int v = io.Int();\n\n    if (t == 0)\n\
    \    {\n        uf.Unite(u, v);\n    }\n    else if (t == 1)\n    {\n        if\
    \ (uf.Same(u, v)) io.Print(1);\n        else io.Print(0);\n    }\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/utility/CPIO.csx
  isVerificationFile: true
  path: verify/data-structure/UnionFind.test.csx
  requiredBy: []
  timestamp: '2026-03-30 11:41:30+09:00'
  verificationStatus: TEST_WRONG_ANSWER
  verifiedWith: []
documentation_of: verify/data-structure/UnionFind.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/UnionFind.test.csx
- /verify/verify/data-structure/UnionFind.test.csx.html
title: verify/data-structure/UnionFind.test.csx
---
