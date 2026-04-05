---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/data-structure/FenwickTree.test.csx
    title: verify/data-structure/FenwickTree.test.csx
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
  code: "/// <summary>\n/// Fenwick Tree. (Binary-Indexed Tree)\n/// </summary>\n\
    /// <typeparam name=\"T\">Type of data.</typeparam>\npublic sealed class FenwickTree<T>\
    \ where T : INumber<T>\n{\n    private T[] _data;\n    private int _size;\n \n\
    \    public int Size => _size;\n\n    public FenwickTree(int n)\n    {\n     \
    \   _size = n;\n        _data = new T[n + 1];\n    }\n\n    public T this[int\
    \ index]\n    {\n        get => PrefixSum(index + 1) - PrefixSum(index);\n   \
    \ }\n\n    /// <summary>\n    /// Rebuilds the fenwick tree by the array. Time\
    \ complexity is O(nlogn).\n    /// </summary>\n    public void Build(T[] array)\n\
    \    {\n        Array.Fill(_data, T.Zero);\n\n        for (int i = 0; i < int.Min(array.Length,\
    \ _size); i++)\n        {\n            Add(i, array[i]);\n        }\n    }\n\n\
    \    /// <summary>\n    /// Adds the value to the index-th element.\n    /// </summary>\n\
    \    public void Add(int index, T value)\n    {\n        // 1-indexed\n      \
    \  index++;\n\n        while (index < _data.Length)\n        {\n            _data[index]\
    \ += value;\n            index += LSB(index);\n        }\n    }\n\n    /// <summary>\n\
    \    /// Updates the index-th element by value.\n    /// </summary>\n    public\
    \ void Update(int index, T value)\n    {\n        T delta = value - this[index];\n\
    \        Add(index, delta);\n    }\n\n    /// <summary>\n    /// Gets the sum\
    \ of the interval [0, length). Time complexity is O(logn).\n    /// </summary>\n\
    \    public T PrefixSum(int length)\n    {\n        if (length == 0) return T.Zero;\n\
    \n        T sum = T.Zero;\n\n        int index = length;\n        while (index\
    \ > 0)\n        {\n            sum += _data[index];\n            index -= LSB(index);\n\
    \        }\n\n        return sum;\n    }\n\n    /// <summary>\n    /// Gets the\
    \ sum of the interval [l, r). Time complexity is O(logn).\n    /// </summary>\n\
    \    public T Sum(int l, int r)\n    {\n        return PrefixSum(r) - PrefixSum(l);\n\
    \    }\n    \n    private int LSB(int x)\n    {\n        return x & (-x);\n  \
    \  }\n\n    /// <summary>\n    /// Returns the view span for the underlying data.\
    \ Time complexity is O(1).\n    /// </summary>\n    public ReadOnlySpan<T> AsSpan()\n\
    \    {\n        return _data;\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/data-structure/FenwickTree.csx
  requiredBy: []
  timestamp: '2026-04-05 11:08:18+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/data-structure/FenwickTree.test.csx
documentation_of: library/data-structure/FenwickTree.csx
layout: document
redirect_from:
- /library/library/data-structure/FenwickTree.csx
- /library/library/data-structure/FenwickTree.csx.html
title: library/data-structure/FenwickTree.csx
---
