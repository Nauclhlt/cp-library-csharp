---
data:
  _extendedDependsOn:
  - icon: ':x:'
    path: library/math/SquareMatrix.csx
    title: Square Matrix
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: true
  _pathExtension: csx
  _verificationStatusIcon: ':x:'
  attributes:
    PROBLEM: https://yukicoder.me/problems/no/1340
    links:
    - https://yukicoder.me/problems/no/1340
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"../../library/math/SquareMatrix.csx\"\n#load \"../../library/math/ModInt.csx\"\
    \n#load \"../../library/utility/CPIO.csx\"\n// verification-helper: PROBLEM https://yukicoder.me/problems/no/1340\n\
    \nglobal using System.Collections;\nglobal using System.Runtime.CompilerServices;\n\
    global using System.Numerics;\nglobal using System.Diagnostics.CodeAnalysis;\n\
    global using System.Globalization;\n\nCPIO io = new();\n\nint N = io.Int();\n\
    int M = io.Int();\nlong T = io.Long();\n\nSquareMatrix<ANDOR> mat = SquareMatrix<ANDOR>.Zero(N);\n\
    \nfor (int i = 0; i < M; i++)\n{\n    int a = io.Int();\n    int b = io.Int();\n\
    \n    mat[b, a] = new(1);\n}\n\nSquareMatrix<ANDOR> power = mat.Power(T);\n\n\
    int ans = 0;\nfor (int i = 0; i < N; i++)\n{\n    if (power[i, 0].Value == 1)\
    \ ans++;\n}\n\nio.Print(ans);\n\nConsole.Out.Flush();\n\npublic struct ANDOR :\
    \ IAdditionOperators<ANDOR, ANDOR, ANDOR>, IMultiplyOperators<ANDOR, ANDOR, ANDOR>,\
    \ IAdditiveIdentity<ANDOR, ANDOR>, IMultiplicativeIdentity<ANDOR, ANDOR>, IEqualityOperators<ANDOR,\
    \ ANDOR, bool>\n{\n    public static ANDOR AdditiveIdentity => new(0);\n    public\
    \ static ANDOR MultiplicativeIdentity => new(1);\n\n\n    public long Value;\n\
    \n    public ANDOR(long v)\n    {\n        Value = v;\n    }\n\n    public static\
    \ ANDOR operator +(ANDOR a, ANDOR b)\n    {\n        return new(a.Value | b.Value);\n\
    \    }\n\n    public static ANDOR operator *(ANDOR a, ANDOR b)\n    {\n      \
    \  return new ANDOR(a.Value & b.Value);\n    }\n\n    public static bool operator\
    \ ==(ANDOR a, ANDOR b) => a.Value == b.Value;\n    public static bool operator\
    \ !=(ANDOR a, ANDOR b) => a.Value != b.Value;\n\n    public override bool Equals([NotNullWhen(true)]\
    \ object obj)\n    {\n        if (obj is ANDOR m) return this == m;\n        else\
    \ return false;\n    }\n\n    public override int GetHashCode()\n    {\n     \
    \   return base.GetHashCode();\n    }\n\n    public override string ToString()\n\
    \    {\n        return Value.ToString();\n    }\n}"
  dependsOn:
  - library/math/SquareMatrix.csx
  isVerificationFile: true
  path: verify/math/SquareMatrix.test.csx
  requiredBy: []
  timestamp: '2026-05-14 21:28:54+09:00'
  verificationStatus: TEST_WRONG_ANSWER
  verifiedWith: []
documentation_of: verify/math/SquareMatrix.test.csx
layout: document
redirect_from:
- /verify/verify/math/SquareMatrix.test.csx
- /verify/verify/math/SquareMatrix.test.csx.html
title: verify/math/SquareMatrix.test.csx
---
