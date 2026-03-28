---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/data-structure/SegmentTree.test.csx
    title: verify/data-structure/SegmentTree.test.csx
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes:
    links: []
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "// @title Segment Tree\n\n/// <summary>\n/// Segment tree. (Non-recursive,\
    \ compatible for non-commutative monoid)\n/// </summary>\n/// <typeparam name=\"\
    T\">Type of values.</typeparam>\npublic sealed class SegmentTree<T> where T :\
    \ struct\n{\n    public delegate T Monoid(T x, T y);\n\n    private int _treeSize;\n\
    \    private int _dataSize;\n    private int _originalDataSize;\n    private T[]\
    \ _data;\n    private Monoid _operator;\n    private Monoid _update;\n    private\
    \ T _identity;\n\n    public int OriginalDataSize => _originalDataSize;\n    public\
    \ int TreeSize => _treeSize;\n    public T Identity => _identity;\n\n    /// <summary>\n\
    \    /// Gets the value by index. Time complexity is O(1).\n    /// </summary>\n\
    \    public T this[int index]\n    {\n        get\n        {\n            return\
    \ _data[_dataSize - 1 + index];\n        }\n    }\n\n    /// <summary>\n    ///\
    \ Builds the segment tree. Time complexity is O(n).\n    /// </summary>\n    public\
    \ SegmentTree(int n, Monoid op, Monoid update, T identity)\n    {\n        _originalDataSize\
    \ = n;\n\n        int size = 1;\n        while (n > size)\n        {\n       \
    \     size <<= 1;\n        }\n\n        _dataSize = size;\n        _treeSize =\
    \ 2 * size - 1;\n\n        _data = new T[_treeSize];\n        Array.Fill(_data,\
    \ identity);\n        _identity = identity;\n        _operator = op;\n       \
    \ _update = update;\n    }\n\n    /// <summary>\n    /// Rebuild the segment tree\
    \ from the array. Time complexity is O(n).\n    /// Since the time complexity\
    \ of n Update() calls is O(nlogn), when initializing the segment tree with an\
    \ array, \n    /// call this function to make it faster.\n    /// </summary>\n\
    \    public void Build(T[] array)\n    {\n        for (int i = 0; i < array.Length;\
    \ i++)\n        {\n            _data[i + _dataSize - 1] = array[i];\n        }\n\
    \n        for (int i = _dataSize - 2; i >= 0; i--)\n        {\n            _data[i]\
    \ = _operator(_data[(i << 1) + 1], _data[(i << 1) + 2]);\n        }\n    }\n\n\
    \    public void UpdateByArray(T[] array)\n    {\n        for (int i = 0; i <\
    \ array.Length; i++)\n        {\n            _data[i + _dataSize - 1] = _update(_data[i\
    \ + _dataSize - 1], array[i]);\n        }\n\n        for (int i = _dataSize -\
    \ 2; i >= 0; i--)\n        {\n            _data[i] = _operator(_data[(i << 1)\
    \ + 1], _data[(i << 1) + 2]);\n        }\n    }\n\n    /// <summary>\n    ///\
    \ Fill the array with the uniform value. Time complexity is O(n).\n    /// </summary>\n\
    \    public void Fill(T value)\n    {\n        for (int i = 0; i < _originalDataSize;\
    \ i++)\n        {\n            _data[i + _dataSize - 1] = value;\n        }\n\n\
    \        for (int i = _dataSize - 2; i >= 0; i--)\n        {\n            _data[i]\
    \ = _operator(_data[(i << 1) + 1], _data[(i << 1) + 2]);\n        }\n    }\n\n\
    \    /// <summary>\n    /// Update the value at the specified position. Time complexity\
    \ is O(logn).\n    /// </summary>\n    public void Update(int index, T value)\n\
    \    {\n        index += _dataSize - 1;\n        _data[index] = _update(_data[index],\
    \ value);\n\n        while (index > 0)\n        {\n            index = (index\
    \ - 1) >> 1;\n            _data[index] = _operator(_data[(index << 1) + 1], _data[(index\
    \ << 1) + 2]);\n        }\n    }\n\n    /// <summary>\n    /// Gets the product\
    \ of the range [l, r). Time complexity is O(logn).\n    /// </summary>\n    public\
    \ T Fold(int l, int r)\n    {\n        l += _dataSize - 1;\n        r += _dataSize\
    \ - 1;\n\n        T leftFold = _identity;\n        T rightFold = _identity;\n\
    \        while (l < r)\n        {\n            if ((l & 1) == 0)\n           \
    \ {\n                leftFold = _operator(leftFold, _data[l]);\n             \
    \   l++;\n            }\n            if ((r & 1) == 0)\n            {\n      \
    \          r--;\n                rightFold = _operator(_data[r], rightFold);\n\
    \            }\n\n            l = (l - 1) >> 1;\n            r = (r - 1) >> 1;\n\
    \        }\n\n        return _operator(leftFold, rightFold);\n    }\n\n    ///\
    \ <summary>\n    /// Returns the span of the underlying data. Time complexity\
    \ is O(1).\n    /// </summary>\n    public ReadOnlySpan<T> AsSpan()\n    {\n \
    \       return _data.AsSpan(_dataSize - 1, _originalDataSize);\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/data-structure/SegmentTree.csx
  requiredBy: []
  timestamp: '2026-03-29 01:28:06+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/data-structure/SegmentTree.test.csx
documentation_of: library/data-structure/SegmentTree.csx
layout: document
redirect_from:
- /library/library/data-structure/SegmentTree.csx
- /library/library/data-structure/SegmentTree.csx.html
title: library/data-structure/SegmentTree.csx
---
