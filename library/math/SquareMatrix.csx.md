---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/math/SquareMatrix.test.csx
    title: verify/math/SquareMatrix.test.csx
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes: {}
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "/// <summary>\n/// Represents a square matrix on T.\n/// </summary>\npublic\
    \ sealed class SquareMatrix<T> : IEquatable<SquareMatrix<T>>\n               \
    \                     where T :\n                                    IAdditionOperators<T,\
    \ T, T>,\n                                    IMultiplyOperators<T, T, T>,\n \
    \                                   IAdditiveIdentity<T, T>,\n               \
    \                     IMultiplicativeIdentity<T, T>,\n                       \
    \             IEqualityOperators<T, T, bool>\n{\n    private T[,] _m;\n    private\
    \ int _size;\n\n    /// <summary>\n    /// Get the element (r, c).\n    /// </summary>\n\
    \    public T this[int r, int c]\n    {\n        get\n        {\n            return\
    \ _m[r, c];\n        }\n        set\n        {\n            _m[r, c] = value;\n\
    \        }\n    }\n\n    public T[,] M => _m;\n    public int Size => _size;\n\
    \n    private SquareMatrix()\n    {\n    }\n\n    private SquareMatrix(int size)\n\
    \    {\n        if (size <= 0)\n        {\n            throw new InvalidOperationException();\n\
    \        }\n\n        _size = size;\n        _m = new T[size, size];\n    }\n\n\
    \    /// <summary>\n    /// Calculates the power to e. Time complexity is O(size^3loge).\n\
    \    /// </summary>\n    public SquareMatrix<T> Power(long e)\n    {\n       \
    \ if (e == 0) return Identity(_size);\n        if (e == 1) return this;\n\n  \
    \      SquareMatrix<T> half = Power(e / 2);\n        SquareMatrix<T> res = half\
    \ * half;\n        if (e % 2 == 1) res *= this;\n\n        return res;\n    }\n\
    \n    /// <summary>\n    /// Returns the transposed matrix. Time complexity is\
    \ O(size^2).\n    /// </summary>\n    public SquareMatrix<T> Transpose()\n   \
    \ {\n        SquareMatrix<T> result = new(_size);\n\n        for (int i = 0; i\
    \ < _size; i++)\n        {\n            for (int j = 0; j < _size; j++)\n    \
    \        {\n                result[j, i] = this[i, j];\n            }\n      \
    \  }\n\n        return result;\n    }\n\n    /// <summary>\n    /// Returns a\
    \ zero matrix. Time complexity is O(size^2).\n    /// </summary>\n    public static\
    \ SquareMatrix<T> Zero(int size)\n    {\n        SquareMatrix<T> result = new\
    \ SquareMatrix<T>(size);\n\n        for (int i = 0; i < size; i++)\n        {\n\
    \            for (int j = 0; j < size; j++)\n            {\n                result[i,\
    \ j] = T.AdditiveIdentity;\n            }\n        }\n\n        return result;\n\
    \    }\n\n    /// <summary>\n    /// Returns an identity matrix. Time complexity\
    \ is O(size^2).\n    /// </summary>\n    public static SquareMatrix<T> Identity(int\
    \ size)\n    {\n        SquareMatrix<T> result = new SquareMatrix<T>(size);\n\n\
    \        for (int i = 0; i < size; i++)\n        {\n            for (int j = 0;\
    \ j < size; j++)\n            {\n                if (i == j) result[i, j] = T.MultiplicativeIdentity;\n\
    \                else result[i, j] = T.AdditiveIdentity;\n            }\n    \
    \    }\n\n        return result;\n    }\n\n\n\n    public static bool operator\
    \ ==(SquareMatrix<T> a, SquareMatrix<T> b) => a.Equals(b);\n    public static\
    \ bool operator !=(SquareMatrix<T> a, SquareMatrix<T> b) => !a.Equals(b);\n\n\
    \    public static SquareMatrix<T> operator +(SquareMatrix<T> left, SquareMatrix<T>\
    \ right)\n    {\n        if (left.Size != right.Size)\n        {\n           \
    \ throw new InvalidOperationException();\n        }\n        \n        SquareMatrix<T>\
    \ dest = Zero(left.Size);\n\n        for (int r = 0; r < left.Size; r++)\n   \
    \     {\n            for (int c = 0; c < left.Size; c++)\n            {\n    \
    \            dest[r, c] = left[r, c] + right[r, c];\n            }\n        }\n\
    \n        return dest;\n    }\n\n    public static SquareMatrix<T> operator *(SquareMatrix<T>\
    \ left, SquareMatrix<T> right)\n    {\n        if (left.Size != right.Size)\n\
    \        {\n            throw new InvalidOperationException();\n        }\n\n\
    \        SquareMatrix<T> result = Zero(left.Size);\n\n        for (int r = 0;\
    \ r < result.Size; r++)\n        {\n            for (int c = 0; c < result.Size;\
    \ c++)\n            {\n                for (int i = 0; i < result.Size; i++)\n\
    \                {\n                    result[r, c] += right[i, c] * left[r,\
    \ i];\n                }\n            }\n        }\n\n        return result;\n\
    \    }\n\n    public bool Equals(SquareMatrix<T> other)\n    {\n        if (_size\
    \ != other.Size) return false;\n\n        for (int i = 0; i < _size; i++)\n  \
    \      {\n            for (int j = 0; j < _size; j++)\n            {\n       \
    \         if (this[i, j] != other[i, j]) return false;\n            }\n      \
    \  }\n\n        return true;\n    }\n\n    public override bool Equals(object\
    \ obj)\n    {\n        if (obj is SquareMatrix<T> mat)\n        {\n          \
    \  return Equals(mat);\n        }\n        else\n            return false;\n \
    \   }\n\n    public override int GetHashCode()\n    {\n        return base.GetHashCode();\n\
    \    }\n\n    public override string ToString()\n    {\n        int[] maxwidths\
    \ = new int[_size];\n        for (int i = 0; i < _size; i++)\n        {\n    \
    \        for (int j = 0; j < _size; j++)\n            {\n                maxwidths[j]\
    \ = int.Max(maxwidths[j], _m[i, j].ToString().Length);\n            }\n      \
    \  }\n\n        StringBuilder sb = new();\n\n        for (int i = 0; i < _size;\
    \ i++)\n        {\n            sb.Append('|');\n            sb.Append(' ');\n\
    \            for (int j = 0; j < _size; j++)\n            {\n                sb.Append(_m[i,\
    \ j].ToString().PadRight(maxwidths[j], ' '));\n                if (j < _size -\
    \ 1) sb.Append(' ');\n            }\n            sb.Append(' ');\n           \
    \ sb.Append('|');\n            if (i < _size - 1)\n                sb.Append(Environment.NewLine);\n\
    \        }\n\n        return sb.ToString();\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/math/SquareMatrix.csx
  requiredBy: []
  timestamp: '2026-05-31 09:59:20+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/math/SquareMatrix.test.csx
documentation_of: library/math/SquareMatrix.csx
layout: document
title: Square Matrix
---

#### 説明

正方行列を扱う.

#### 注意点
- $T$ はいい感じに演算子系のインターフェースを実装してないとダメ

#### 関数
- `Power(e)`: $e$ 乗を求める
- `Transpose()`: 転置行列を返す
- `static Zero(size)`: サイズが $size$ の零行列を返す
- `static Identity(size)`: サイズが $size$ の単位行列を返す