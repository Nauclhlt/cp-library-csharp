---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/string/SuffixArray.csx
    title: "Suffix Array(\u63A5\u5C3E\u8F9E\u914D\u5217)"
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://yukicoder.me/problems/no/430
    links:
    - https://yukicoder.me/problems/no/430
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/string/SuffixArray.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://yukicoder.me/problems/no/430\n\nglobal\
    \ using System.Collections;\nglobal using System.Runtime.CompilerServices;\nglobal\
    \ using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\nglobal\
    \ using System.Globalization;\n\nCPIO io = new();\n\nstring S = io.String();\n\
    int M = io.Int();\nstring[] C = io.StringArray(M);\n\nSuffixArray sa = new(S);\n\
    long ans = 0;\nfor (int i = 0; i < M; i++)\n{\n    ans += sa.CountOf(C[i]);\n\
    }\n\nio.Print(ans);\n\nConsole.Out.Flush();"
  dependsOn:
  - library/string/SuffixArray.csx
  isVerificationFile: true
  path: verify/string/SuffixArray.test.csx
  requiredBy: []
  timestamp: '2026-06-03 15:40:08+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/string/SuffixArray.test.csx
layout: document
redirect_from:
- /verify/verify/string/SuffixArray.test.csx
- /verify/verify/string/SuffixArray.test.csx.html
title: verify/string/SuffixArray.test.csx
---
