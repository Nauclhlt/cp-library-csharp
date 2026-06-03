---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/math/ModCache.csx
    title: "Mod Cache (\u4F59\u308A\u95A2\u9023\u306E\u524D\u8A08\u7B97)"
  - icon: ':heavy_check_mark:'
    path: library/math/ModInt.csx
    title: ModInt
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    PROBLEM: https://yukicoder.me/problems/no/3146
    links:
    - https://yukicoder.me/problems/no/3146
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/math/ModCache.csx\"\n#load \"../../library/utility/CPIO.csx\"\
    \n// verification-helper: PROBLEM https://yukicoder.me/problems/no/3146\n\nglobal\
    \ using System.Collections;\nglobal using System.Runtime.CompilerServices;\nglobal\
    \ using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\nglobal\
    \ using System.Globalization;\n\nModCache<Mod998244353> cache = new(1000050);\n\
    \nCPIO io = new();\n\nint T = io.Int();\n\nList<ModInt<Mod998244353>> ans = new()\
    \ {0};\nModInt<Mod998244353> sum = 0;\nModInt<Mod998244353> catalan = 0;\n\nwhile\
    \ (T-- > 0)\n{\n    int N = io.Int();\n    if (N % 2 == 1) io.Print(\"0\");\n\
    \    else\n    {\n        N /= 2;\n\n        while (ans.Count <= N)\n        {\n\
    \            ModInt<Mod998244353> next = 3L * sum + catalan;\n            \n \
    \           ans.Add(next);\n            sum += next;\n            int x = ans.Count\
    \ - 1;\n            ModInt<Mod998244353> c = cache.Factorial(2 * x) * cache.InverseFactorial(x)\
    \ * cache.InverseFactorial(x) * cache.Inverse(x + 1);\n            \n        \
    \    catalan += c;\n        }\n\n        io.Print(ans[N].ValueLong);\n    }\n\
    }\n\nConsole.Out.Flush();"
  dependsOn:
  - library/math/ModInt.csx
  - library/math/ModCache.csx
  isVerificationFile: true
  path: verify/math/ModCache.test.csx
  requiredBy: []
  timestamp: '2026-06-03 15:40:08+09:00'
  verificationStatus: TEST_ACCEPTED
  verifiedWith: []
documentation_of: verify/math/ModCache.test.csx
layout: document
redirect_from:
- /verify/verify/math/ModCache.test.csx
- /verify/verify/math/ModCache.test.csx.html
title: verify/math/ModCache.test.csx
---
