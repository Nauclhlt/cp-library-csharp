---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/data-structure/UnionFind.csx
    title: Union-Find
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
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
  code: "#load \"../../library/data-structure/UnionFind.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://judge.yosupo.jp/problem/unionfind\n\n\
    global using System.Runtime.CompilerServices;\n\nCPIO io = new();\n\nint N = io.Int();\n\
    int Q = io.Int();\n\nUnionFind uf = new(N);\n\nwhile (Q-- > 0)\n{\n    int t =\
    \ io.Int();\n    int u = io.Int();\n    int v = io.Int();\n\n    if (t == 0)\n\
    \    {\n        uf.Unite(u, v);\n    }\n    else if (t == 1)\n    {\n        if\
    \ (uf.Same(u, v)) io.Print(1);\n        else io.Print(0);\n    }\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/data-structure/UnionFind.csx
  isVerificationFile: true
  path: verify/data-structure/UnionFind.test.csx
  requiredBy: []
  timestamp: '2026-04-05 20:44:47+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/data-structure/UnionFind.test.csx
layout: document
redirect_from:
- /verify/verify/data-structure/UnionFind.test.csx
- /verify/verify/data-structure/UnionFind.test.csx.html
title: verify/data-structure/UnionFind.test.csx
---
