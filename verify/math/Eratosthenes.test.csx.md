---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/math/Eratosthenes.csx
    title: Sieve of Eratosthenes
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_D
    links:
    - http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_D
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/math/Eratosthenes.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_D\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint a = io.Int();\n\
    int b = io.Int();\nint c = io.Int();\n\nEratosthenes e = new(c + 100);\n\nList<int>\
    \ div = e.GetDivisors(c);\n\nint ans = 0;\nfor (int i = 0; i < div.Count; i++)\n\
    {\n    if (a <= div[i] && div[i] <= b)\n    {\n        ans++;\n    }\n}\n\nio.Print(ans);\n\
    \nConsole.Out.Flush();"
  dependsOn:
  - library/math/Eratosthenes.csx
  isVerificationFile: true
  path: verify/math/Eratosthenes.test.csx
  requiredBy: []
  timestamp: '2026-05-14 21:28:54+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/math/Eratosthenes.test.csx
layout: document
redirect_from:
- /verify/verify/math/Eratosthenes.test.csx
- /verify/verify/math/Eratosthenes.test.csx.html
title: verify/math/Eratosthenes.test.csx
---
