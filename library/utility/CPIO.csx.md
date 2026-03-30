---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/data-structure/UnionFind.test.csx
    title: verify/data-structure/UnionFind.test.csx
  - icon: ':x:'
    path: verify/math/ModInt.test.csx
    title: verify/math/ModInt.test.csx
  - icon: ':heavy_check_mark:'
    path: verify/utility/CPIO.test.csx
    title: verify/utility/CPIO.test.csx
  _isVerificationFailed: true
  _pathExtension: csx
  _verificationStatusIcon: ':question:'
  attributes: {}
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "/// <summary>\n/// Standard input reader for competitive programming.\n///\
    \ </summary>\npublic sealed class CPIO\n{\n    Queue<string> _readQueue = new\
    \ Queue<string>();\n\n    static CPIO()\n    {\n        // faster standard output\n\
    \        StreamWriter writer = new StreamWriter(Console.OpenStandardOutput())\
    \ { AutoFlush = false };\n        Console.SetOut(writer);\n    }\n\n    private\
    \ void LoadQueue()\n    {\n        if (_readQueue.Count > 0) return;\n       \
    \ string line = Console.ReadLine();\n        string[] split = line.Split(' ',\
    \ StringSplitOptions.RemoveEmptyEntries);\n        for (int i = 0; i < split.Length;\
    \ i++) _readQueue.Enqueue(split[i]);\n    }\n\n    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \    private void Guard()\n    {\n        if (_readQueue.Count == 0)\n       \
    \ {\n            throw new Exception(\"Standard input queue was empty.\");\n \
    \       }\n    }\n\n    public int Int()\n    {\n        LoadQueue();\n      \
    \  Guard();\n        return int.Parse(_readQueue.Dequeue());\n    }\n\n    public\
    \ long Long()\n    {\n        LoadQueue();\n        Guard();\n        return long.Parse(_readQueue.Dequeue());\n\
    \    }\n\n    public string String()\n    {\n        LoadQueue();\n        Guard();\n\
    \        return _readQueue.Dequeue();\n    }\n\n    public short Short()\n   \
    \ {\n        LoadQueue();\n        Guard();\n        return short.Parse(_readQueue.Dequeue());\n\
    \    }\n\n    public byte Byte()\n    {\n        LoadQueue();\n        Guard();\n\
    \        return byte.Parse(_readQueue.Dequeue());\n    }\n\n    public char Char()\n\
    \    {\n        LoadQueue();\n        Guard();\n        return char.Parse(_readQueue.Dequeue());\n\
    \    }\n\n    public double Double()\n    {\n        LoadQueue();\n        Guard();\n\
    \        return double.Parse(_readQueue.Dequeue());\n    }\n\n    public float\
    \ Float()\n    {\n        LoadQueue();\n        Guard();\n        return float.Parse(_readQueue.Dequeue());\n\
    \    }\n\n    public T Read<T>()\n    {\n        Type type = typeof(T);\n    \
    \    if (type == typeof(int)) return (T)(object)Int();\n        else if (type\
    \ == typeof(long)) return (T)(object)Long();\n        else if (type == typeof(float))\
    \ return (T)(object)Float();\n        else if (type == typeof(double)) return\
    \ (T)(object)Double();\n        else if (type == typeof(short)) return (T)(object)Short();\n\
    \        else if (type == typeof(byte)) return (T)(object)Byte();\n        else\
    \ if (type == typeof(char)) return (T)(object)Char();\n        else if (type ==\
    \ typeof(string)) return (T)(object)String();\n        else return default(T);\n\
    \    }\n\n    public int[] IntArray(int n)\n    {\n        if (n == 0) return\
    \ Array.Empty<int>();\n\n        int[] arr = new int[n];\n        for (int i =\
    \ 0; i < n; i++)\n        {\n            arr[i] = Int();\n        }\n\n      \
    \  return arr;\n    }\n\n    public int[] ZeroIndexedPermutation(int n)\n    {\n\
    \        if (n == 0) return Array.Empty<int>();\n\n        int[] arr = new int[n];\n\
    \        for (int i = 0; i < n; i++)\n        {\n            arr[i] = Int() -\
    \ 1;\n        }\n\n        return arr;\n    }\n\n    public long[] LongArray(int\
    \ n)\n    {\n        if (n == 0) return Array.Empty<long>();\n\n        long[]\
    \ arr = new long[n];\n        for (int i = 0; i < n; i++)\n        {\n       \
    \     arr[i] = Long();\n        }\n\n        return arr;\n    }\n\n    public\
    \ double[] DoubleArray(int n)\n    {\n        if (n == 0) return Array.Empty<double>();\n\
    \n        double[] arr = new double[n];\n        for (int i = 0; i < n; i++)\n\
    \        {\n            arr[i] = Double();\n        }\n\n        return arr;\n\
    \    }\n\n    public string[] StringArray(int n)\n    {\n        if (n == 0) return\
    \ Array.Empty<string>();\n\n        string[] arr = new string[n];\n        for\
    \ (int i = 0; i < n; i++)\n        {\n            arr[i] = String();\n       \
    \ }\n\n        return arr;\n    }\n\n    public T[] ReadArray<T>(int n)\n    {\n\
    \        if (n == 0) return Array.Empty<T>();\n\n        T[] arr = new T[n];\n\
    \        for (int i = 0; i < n; i++)\n        {\n            arr[i] = Read<T>();\n\
    \        }\n\n        return arr;\n    }\n\n    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \    public void YesNo(bool t)\n    {\n        Console.WriteLine(t ? \"Yes\" :\
    \ \"No\");\n    }\n\n    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \    public void Print<T>(IEnumerable<T> array, char delimiter = ' ')\n    {\n\
    \        Console.WriteLine(string.Join(delimiter, array));\n    }\n\n    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \    public void Print(string value) => Console.WriteLine(value);\n    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \    public void Print(int value) => Console.WriteLine(value);\n    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \    public void Print(long value) => Console.WriteLine(value);\n    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \    public void Print(double value, int digits = 10) => Console.WriteLine(Math.Round(value,\
    \ digits).ToString());\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/utility/CPIO.csx
  requiredBy: []
  timestamp: '2026-03-29 21:55:43+09:00'
  verificationStatus: LIBRARY_SOME_WA
  verifiedWith:
  - verify/utility/CPIO.test.csx
  - verify/data-structure/UnionFind.test.csx
  - verify/math/ModInt.test.csx
documentation_of: library/utility/CPIO.csx
layout: document
title: CPIO
---

#### 説明

競プロ用I/Oユーティリティクラス. staticコンストラクタで自動flushを無効にしている.

スペース区切り/改行区切りにかかわらず各関数で順に読んでくれる.

#### 注意点
- flushが必要な際は適宜`Console.Out.Flush()`すること

#### 関数
- `Int()`: int型で値を受け取る
- `Long()`: long型で値を受け取る
- `String()`: 文字列として値を受け取る
- `Short()`: short型で値を受け取る
- `Byte()`: byte型で値を受け取る
- `Char()`: 文字として値を受け取る
- `Double()`: double型で値を受け取る
- `Float()`: float型で値を受け取る
- `Read<T>()`: $T$ 型で値を受け取る
- `IntArray(n)`: 長さ $n$ のint型配列を受け取る
- `ZeroIndexedPermutation(n)`: 長さ $n$ 順列(配列)の入力を受け取る際, 全要素を $-1$ したものを返す
- `LongArray(n)`: 長さ $n$ のlong型配列を受け取る
- `DoubleArray(n)`: 長さ $n$ のdouble型配列を受け取る
- `StringArray(n)`: 長さ $n$ の文字列配列を受け取る
- `ReadArray<T>(n)`: 長さ $n$ の $T$ 型配列を受け取る
- `YesNo(t)`: $t$ の真偽に応じて `Yes` または `No` を出力する
- `Print<T>(array, delimiter)`: $T$ 型の列挙可能型 $array$ の要素を $delimiter$ 区切りで出力する
- `Print(value)`: $value$ を出力する
- `Print(value, digits)`: double型の $value$ を小数点以下 $digits$ まで(それ以下があればroundして)出力する