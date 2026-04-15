---
data:
  _extendedDependsOn:
  - icon: ':x:'
    path: library/math/ModInt.csx
    title: ModInt
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: true
  _pathExtension: csx
  _verificationStatusIcon: ':x:'
  attributes:
    PROBLEM: https://onlinejudge.u-aizu.ac.jp/courses/library/6/NTL/1/NTL_1_B
    links:
    - https://onlinejudge.u-aizu.ac.jp/courses/library/6/NTL/1/NTL_1_B
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: '#load "../../library/math/ModInt.csx"

    #load "../../library/utility/CPIO.csx"

    // verification-helper: PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/6/NTL/1/NTL_1_B


    global using System.Collections;

    global using System.Runtime.CompilerServices;

    global using System.Numerics;

    global using System.Diagnostics.CodeAnalysis;

    global using System.Globalization;


    CPIO io = new();


    long m = io.Long();

    long n = io.Long();


    ModInt<Mod1000000007> modint = m;

    io.Print(modint.Power(n).Value);


    Console.Out.Flush();'
  dependsOn:
  - library/math/ModInt.csx
  isVerificationFile: true
  path: verify/math/ModInt.test.csx
  requiredBy: []
  timestamp: '2026-04-15 20:12:15+09:00'
  verificationStatus: TEST_WRONG_ANSWER
  verifiedWith: []
documentation_of: verify/math/ModInt.test.csx
layout: document
redirect_from:
- /verify/verify/math/ModInt.test.csx
- /verify/verify/math/ModInt.test.csx.html
title: verify/math/ModInt.test.csx
---
