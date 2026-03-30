---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith: []
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':warning:'
  attributes: {}
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "/// <summary>\n/// Integer on F_p. (p: prime)\n/// </summary>\n/// <typeparam\
    \ name=\"T\">Modulus.</typeparam>\npublic readonly struct ModInt<T> : INumber<ModInt<T>>\n\
    \                                    where T : struct, IMod\n{\n    public static\
    \ long Mod => _mod.Mod;\n\n    private static readonly T _mod = default;\n\n \
    \   public readonly long Value;\n\n    /// <summary>\n    /// Returns 1. Time\
    \ complexity is O(1).\n    /// </summary>\n    public static ModInt<T> One { get;\
    \ } = CreateFast(1L);\n\n    /// <summary>\n    /// Returns 0. Time complexity\
    \ is O(1).\n    /// </summary>\n    public static ModInt<T> Zero { get; } = CreateFast(0L);\n\
    \n    public static int Radix => 10;\n    public static ModInt<T> MinValue =>\
    \ CreateFast(0L);\n    public static ModInt<T> MaxValue => CreateFast(_mod.Mod\
    \ - 1);\n\n    /// <summary>\n    /// Returns the additive identity, 0. Time complexity\
    \ is O(1).\n    /// </summary>\n    public static ModInt<T> AdditiveIdentity {\
    \ get; } = CreateFast(0L);\n    /// <summary>\n    /// Returns the multiplicative\
    \ identity, 1. Time complexity is O(1).\n    /// </summary>\n    public static\
    \ ModInt<T> MultiplicativeIdentity { get; } = CreateFast(1L);\n\n    public ModInt(long\
    \ value)\n    {\n        Value = SafeMod(value);\n    }\n\n    private ModInt(long\
    \ value, bool dummy)\n    {\n        Value = value;\n    }\n\n    /// <summary>\n\
    \    /// Constructs the modint with the value. Can only be used when 0 <= value\
    \ < MOD. Maybe slightly faster than implicit cast. Time complexity is O(1).\n\
    \    /// </summary>\n    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \    public static ModInt<T> CreateFast(long value)\n    {\n        return new\
    \ ModInt<T>(value, false);\n    }\n\n    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \    private static long SafeMod(long a)\n    {\n        return a % _mod.Mod +\
    \ ((a >> 63) & _mod.Mod);\n    }\n\n    /// <summary>\n    /// Calculates the\
    \ power to e. Time complexity is O(loge)\n    /// </summary>\n    public readonly\
    \ ModInt<T> Power(long e)\n    {\n        if (e < 0)\n        {\n            return\
    \ Power(-e).Inv();\n        }\n        else\n        {\n            long res =\
    \ 1L;\n            long b = Value;\n            while (e > 0)\n            {\n\
    \                if ((e & 1) == 1) res = res * b % _mod.Mod;\n               \
    \ b = b * b % _mod.Mod;\n                e >>= 1;\n            }\n\n         \
    \   return CreateFast(res);\n        }\n    }\n\n    /// <summary>\n    /// Returns\
    \ the inverse. Do not call this function when 0. Time complexity is O(logp).\n\
    \    /// </summary>\n    public readonly ModInt<T> Inv()\n    {\n        long\
    \ x = 1, y = 0;\n        long x1 = 0, y1 = 1;\n        long b = _mod.Mod;\n  \
    \      long a = Value;\n\n        while (b != 0)\n        {\n            long\
    \ q = a / b;\n            long t = a % b;\n            a = b;\n            b =\
    \ t;\n\n            long tx = x - q * x1;\n            long ty = y - q * y1;\n\
    \            x = x1;\n            y = y1;\n            x1 = tx;\n            y1\
    \ = ty;\n        }\n\n        return new(x);\n    }\n\n    [MethodImpl(256)]\n\
    \    public static ModInt<T> operator +(ModInt<T> left, ModInt<T> right) => CreateFast((left.Value\
    \ + right.Value) % _mod.Mod);\n\n    [MethodImpl(256)]\n    public static ModInt<T>\
    \ operator +(ModInt<T> self) => self;\n\n    [MethodImpl(256)]\n    public static\
    \ ModInt<T> operator -(ModInt<T> left, ModInt<T> right) => CreateFast((left.Value\
    \ - right.Value + _mod.Mod) % _mod.Mod);\n\n    [MethodImpl(256)]\n    public\
    \ static ModInt<T> operator -(ModInt<T> self) => CreateFast(_mod.Mod - self.Value);\n\
    \n    [MethodImpl(256)]\n    public static ModInt<T> operator *(ModInt<T> left,\
    \ ModInt<T> right) => CreateFast(left.Value * right.Value % _mod.Mod);\n\n   \
    \ [MethodImpl(256)]\n    public static ModInt<T> operator /(ModInt<T> left, ModInt<T>\
    \ right)\n    {\n        if (right.Value == 0L)\n        {\n            throw\
    \ new DivideByZeroException();\n        }\n\n        ModInt<T> inv = right.Inv();\n\
    \        return CreateFast(left.Value * inv.Value % _mod.Mod);\n    }\n\n    public\
    \ static ModInt<T> operator %(ModInt<T> left, ModInt<T> right)\n    {\n      \
    \  throw new NotImplementedException();\n    }\n\n    public static bool operator\
    \ <(ModInt<T> left, ModInt<T> right)\n    {\n        throw new NotImplementedException();\n\
    \    }\n\n    public static bool operator >(ModInt<T> left, ModInt<T> right)\n\
    \    {\n        throw new NotImplementedException();\n    }\n\n    public static\
    \ bool operator <=(ModInt<T> left, ModInt<T> right)\n    {\n        throw new\
    \ NotImplementedException();\n    }\n\n    public static bool operator >=(ModInt<T>\
    \ left, ModInt<T> right)\n    {\n        throw new NotImplementedException();\n\
    \    }\n\n    [MethodImpl(256)]\n    public static bool operator ==(ModInt<T>\
    \ left, ModInt<T> right) => left.Value == right.Value;\n\n    [MethodImpl(256)]\n\
    \    public static bool operator !=(ModInt<T> left, ModInt<T> right) => !(left\
    \ == right);\n\n    [MethodImpl(256)]\n    public static ModInt<T> operator ++(ModInt<T>\
    \ self) => CreateFast((self.Value + 1) % _mod.Mod);\n\n    [MethodImpl(256)]\n\
    \    public static ModInt<T> operator --(ModInt<T> self) => CreateFast((self.Value\
    \ - 1 + _mod.Mod) % _mod.Mod);\n\n    [MethodImpl(256)]\n    public bool Equals(ModInt<T>\
    \ other) => Value == other.Value;\n\n    [MethodImpl(256)]\n    public override\
    \ bool Equals(object other)\n    {\n        if (other is ModInt<T> m)\n      \
    \  {\n            return this == m;\n        }\n        else return false;\n \
    \   }\n\n    [MethodImpl(256)]\n    public override int GetHashCode() => Value.GetHashCode();\n\
    \n    [MethodImpl(256)]\n    public static implicit operator ModInt<T>(long v)\
    \ => new ModInt<T>(v);\n\n    [MethodImpl(256)]\n    public static implicit operator\
    \ ModInt<T>(int v) => new ModInt<T>(v);\n\n    [MethodImpl(256)]\n    public static\
    \ implicit operator long(in ModInt<T> m) => m.Value;\n\n    [MethodImpl(256)]\n\
    \    public static implicit operator int(in ModInt<T> m) => (int)m.Value;\n\n\
    \    public override string ToString() => Value.ToString();\n\n    public string\
    \ ToString(string format, IFormatProvider provider) => Value.ToString(format,\
    \ provider);\n\n    #region INumberBase<TSelf> Implementation\n\n    public static\
    \ ModInt<T> Abs(ModInt<T> value) => value;\n    public static bool IsCanonical(ModInt<T>\
    \ value) => true;\n    public static bool IsComplexNumber(ModInt<T> value) =>\
    \ false;\n    public static bool IsFinite(ModInt<T> value) => true;\n    public\
    \ static bool IsImaginaryNumber(ModInt<T> value) => false;\n    public static\
    \ bool IsInfinity(ModInt<T> value) => false;\n    public static bool IsInteger(ModInt<T>\
    \ value) => true;\n    public static bool IsNaN(ModInt<T> value) => false;\n \
    \   public static bool IsNegative(ModInt<T> value) => false;\n    public static\
    \ bool IsPositive(ModInt<T> value) => value.Value != 0L;\n    public static bool\
    \ IsRealNumber(ModInt<T> value) => true;\n    public static bool IsZero(ModInt<T>\
    \ value) => value.Value == 0L;\n    public static bool IsEvenInteger(ModInt<T>\
    \ value) => (value.Value & 1) == 0;\n    public static bool IsOddInteger(ModInt<T>\
    \ value) => (value.Value & 1) == 1;\n    public static bool IsPositiveInfinity(ModInt<T>\
    \ value) => false;\n    public static bool IsNegativeInfinity(ModInt<T> value)\
    \ => false;\n    public static bool IsNormal(ModInt<T> value) => false;\n    public\
    \ static bool IsSubnormal(ModInt<T> value) => false;\n\n\n    public static ModInt<T>\
    \ MaxMagnitude(ModInt<T> x, ModInt<T> y)\n    {\n        if (x.Value > y.Value)\
    \ return x;\n        else return y;\n    }\n    public static ModInt<T> MaxMagnitudeNumber(ModInt<T>\
    \ x, ModInt<T> y) => MaxMagnitude(x, y);\n    public static ModInt<T> MinMagnitude(ModInt<T>\
    \ x, ModInt<T> y)\n    {\n        if (x.Value < y.Value) return x;\n        else\
    \ return y;\n    }\n    public static ModInt<T> MinMagnitudeNumber(ModInt<T> x,\
    \ ModInt<T> y) => MinMagnitude(x, y);\n\n    public static ModInt<T> CreateChecked<TOther>(TOther\
    \ value) where TOther : INumberBase<TOther>\n        => new(long.CreateChecked(value));\n\
    \    public static ModInt<T> CreateSaturating<TOther>(TOther value) where TOther\
    \ : INumberBase<TOther>\n        => new(long.CreateSaturating(value));\n    public\
    \ static ModInt<T> CreateTruncating<TOther>(TOther value) where TOther : INumberBase<TOther>\n\
    \        => new(long.CreateTruncating(value));\n\n    public static ModInt<T>\
    \ Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s.AsSpan(),\
    \ style, provider);\n\n    public static ModInt<T> Parse(ReadOnlySpan<char> s,\
    \ NumberStyles style, IFormatProvider provider) => new(long.Parse(s, style, provider));\n\
    \n    public static ModInt<T> Parse(ReadOnlySpan<byte> s, NumberStyles style,\
    \ IFormatProvider provider) => new(long.Parse(s, style, provider));\n\n    public\
    \ static ModInt<T> Parse(string s, IFormatProvider provider) => new(long.Parse(s,\
    \ provider));\n\n    public static ModInt<T> Parse(ReadOnlySpan<char> s, IFormatProvider\
    \ provider) => new(long.Parse(s, provider));\n\n    public bool TryFormat(Span<byte>\
    \ dest, out int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)\n\
    \    {\n        return Value.TryFormat(dest, out bytesWritten, format, provider);\n\
    \    }\n\n    public bool TryFormat(Span<char> destination, out int charsWritten,\
    \ ReadOnlySpan<char> format, IFormatProvider provider)\n    {\n        return\
    \ Value.TryFormat(destination, out charsWritten, format, provider);\n    }\n\n\
    \    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider\
    \ provider, out ModInt<T> result)\n    {\n        if (long.TryParse(s, style,\
    \ provider, out long inner))\n        {\n            result = new(inner);\n  \
    \          return true;\n        }\n        else\n        {\n            result\
    \ = Zero;\n            return false;\n        }\n\n    }\n\n    public static\
    \ bool TryParse(string s, NumberStyles style, IFormatProvider provider, out ModInt<T>\
    \ result)\n    {\n        if (long.TryParse(s, style, provider, out long inner))\n\
    \        {\n            result = new(inner);\n            return true;\n     \
    \   }\n        else\n        {\n            result = Zero;\n            return\
    \ false;\n        }\n    }\n\n\n\n    public static bool TryParse(ReadOnlySpan<char>\
    \ s, IFormatProvider provider, out ModInt<T> result)\n    {\n        if (long.TryParse(s,\
    \ provider, out long inner))\n        {\n            result = new(inner);\n  \
    \          return true;\n        }\n        else\n        {\n            result\
    \ = Zero;\n            return false;\n        }\n    }\n\n    public static bool\
    \ TryParse(string s, IFormatProvider provider, out ModInt<T> result)\n    {\n\
    \        if (long.TryParse(s, provider, out long inner))\n        {\n        \
    \    result = new(inner);\n            return true;\n        }\n        else\n\
    \        {\n            result = Zero;\n            return false;\n        }\n\
    \    }\n\n    public static bool TryConvertFromChecked<TOther>(TOther value, out\
    \ ModInt<T> result) where TOther : INumberBase<TOther>\n    {\n        throw new\
    \ NotImplementedException();\n    }\n\n    public static bool TryConvertFromSaturating<TOther>(TOther\
    \ value, out ModInt<T> result) where TOther : INumberBase<TOther>\n    {\n   \
    \     throw new NotImplementedException();\n    }\n\n    public static bool TryConvertFromTruncating<TOther>(TOther\
    \ value, [MaybeNullWhen(false)] out ModInt<T> result) where TOther : INumberBase<TOther>\n\
    \    {\n        throw new NotImplementedException();\n    }\n\n    public static\
    \ bool TryConvertToChecked<TOther>(ModInt<T> value, [MaybeNullWhen(false)] out\
    \ TOther result) where TOther : INumberBase<TOther>\n    {\n        throw new\
    \ NotImplementedException();\n    }\n\n    public static bool TryConvertToSaturating<TOther>(ModInt<T>\
    \ value, [MaybeNullWhen(false)] out TOther result) where TOther : INumberBase<TOther>\n\
    \    {\n        throw new NotImplementedException();\n    }\n\n    public static\
    \ bool TryConvertToTruncating<TOther>(ModInt<T> value, [MaybeNullWhen(false)]\
    \ out TOther result) where TOther : INumberBase<TOther>\n    {\n        throw\
    \ new NotImplementedException();\n    }\n\n\n    #endregion\n\n    #region INumber<TSelf>\
    \ Implementation\n\n    public int CompareTo(ModInt<T> other) => Value.CompareTo(other.Value);\n\
    \    public int CompareTo(object other) => Value.CompareTo(other);\n\n\n    #endregion\n\
    }\n\n/// <summary>\n/// Used to specify modulus.\n/// </summary>\npublic interface\
    \ IMod\n{\n    public long Mod { get; }\n}\n\npublic readonly struct Mod998244353\
    \ : IMod { public long Mod => 998244353L; }\npublic readonly struct Mod1000000007\
    \ : IMod { public long Mod => 1000000007L; }\npublic readonly struct Mod897581057\
    \ : IMod { public long Mod => 897581057; }\npublic readonly struct Mod880803841\
    \ : IMod { public long Mod => 880803841; }"
  dependsOn: []
  isVerificationFile: false
  path: library/math/ModInt.csx
  requiredBy: []
  timestamp: '2026-03-30 14:27:54+09:00'
  verificationStatus: LIBRARY_NO_TESTS
  verifiedWith: []
documentation_of: library/math/ModInt.csx
layout: document
redirect_from:
- /library/library/math/ModInt.csx
- /library/library/math/ModInt.csx.html
title: library/math/ModInt.csx
---
