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
    PROBLEM: https://onlinejudge.u-aizu.ac.jp/courses/library/6/NTL/1/NTL_1_B
    links:
    - https://onlinejudge.u-aizu.ac.jp/courses/library/6/NTL/1/NTL_1_B
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: '#load "../../library/utility/CPIO.csx"

    #load "../../library/math/ModInt.csx"

    // verification-helper: PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/6/NTL/1/NTL_1_B


    global using System.Runtime.CompilerServices;


    CPIO io = new();


    long m = io.Long();

    long n = io.Long();


    ModInt<Mod1000000007> modint = m;

    io.Print(modint.Power(n).Value);'
  dependsOn:
  - library/utility/CPIO.csx
  isVerificationFile: true
  path: verify/math/ModInt.test.csx
  requiredBy: []
  timestamp: '2026-03-30 14:27:54+09:00'
  verificationStatus: TEST_WRONG_ANSWER
  verifiedWith: []
documentation_of: verify/math/ModInt.test.csx
layout: document
redirect_from:
- /verify/verify/math/ModInt.test.csx
- /verify/verify/math/ModInt.test.csx.html
title: verify/math/ModInt.test.csx
---
