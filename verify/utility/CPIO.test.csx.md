---
data:
  _extendedDependsOn:
  - icon: ':question:'
    path: library/utility/CPIO.csx
    title: CPIO
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://judge.yosupo.jp/problem/many_aplusb
    links:
    - https://judge.yosupo.jp/problem/many_aplusb
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/utility/CPIO.csx\"\n// verification-helper: PROBLEM\
    \ https://judge.yosupo.jp/problem/many_aplusb\n\nglobal using System.Runtime.CompilerServices;\n\
    \nCPIO io = new();\n\nint T = io.Int();\n\nwhile (T-- > 0)\n{\n    long A = io.Long();\n\
    \    long B = io.Long();\n\n    io.Print(A + B);\n}\n\nConsole.Out.Flush();"
  dependsOn:
  - library/utility/CPIO.csx
  isVerificationFile: true
  path: verify/utility/CPIO.test.csx
  requiredBy: []
  timestamp: '2026-03-30 00:44:43+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/utility/CPIO.test.csx
layout: document
redirect_from:
- /verify/verify/utility/CPIO.test.csx
- /verify/verify/utility/CPIO.test.csx.html
title: verify/utility/CPIO.test.csx
---
