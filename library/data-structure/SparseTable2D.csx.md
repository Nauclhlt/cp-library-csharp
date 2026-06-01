---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/data-structure/SparseTable.csx
    title: Sparse Table
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/data-structure/SparseTable2D.test.csx
    title: verify/data-structure/SparseTable2D.test.csx
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
  code: "#load \"SparseTable.csx\"\n\n/// <summary>\n/// 2D sparse table.\n/// </summary>\n\
    public sealed class SparseTable2D<T>\n{\n    private Func<T, T, T> _op;\n    private\
    \ T _identity;\n    private SparseTable<T>[][] _table;\n    private int[] _lookup;\n\
    \    private int _height;\n    private int _width;\n    private int _maxLength;\n\
    \n    public int Height => _height;\n    public int Width => _width;\n\n    ///\
    \ <summary>\n    /// Builds the sparse table. Time complexity is O(HWlogHlogW).\n\
    \    /// </summary>\n    public SparseTable2D(T[,] source, T identity, Func<T,\
    \ T, T> op)\n    {\n        _height = source.GetLength(0);\n        _width = source.GetLength(1);\n\
    \n        _identity = identity;\n        _op = op;\n        _maxLength = int.Max(_height,\
    \ _width);\n\n        _lookup = new int[_maxLength + 1];\n        for (int i =\
    \ 2; i <= _maxLength; i++)\n        {\n            _lookup[i] = _lookup[i >> 1]\
    \ + 1;\n        }\n\n        int log = _lookup[_maxLength] + 1;\n\n        _table\
    \ = new SparseTable<T>[log][];\n        for (int i = 0; i < log; i++)\n      \
    \  {\n            _table[i] = new SparseTable<T>[_height];\n        }\n\n    \
    \    for (int y = 0; y < _height; y++)\n        {\n            T[] v = new T[_width];\n\
    \            for (int x = 0; x < _width; x++)\n            {\n               \
    \ v[x] = source[y, x];\n            }\n\n            _table[0][y] = new (v, _identity,\
    \ _op);\n        }\n\n        for (int h = 1; h < log; h++)\n        {\n     \
    \       for (int i = 0; i + (1 << h) <= _height; i++)\n            {\n       \
    \         T[] v = new T[_width];\n                for (int j = 0; j < _width;\
    \ j++)\n                {\n                    v[j] = _op(_table[h - 1][i].Fold(j,\
    \ j + 1), _table[h - 1][i + (1 << (h - 1))].Fold(j, j + 1));\n               \
    \ }\n\n                _table[h][i] = new(v, _identity, _op);\n            }\n\
    \        }\n    }\n\n    /// <summary>\n    /// Calculates the product of the\
    \ rectangle range [x1, x2)--[y1, y2). Time complexity is O(1).\n    /// </summary>\n\
    \    public T Fold(int x1, int y1, int x2, int y2)\n    {\n        if (x1 == x2\
    \ || y1 == y2) return _identity;\n        int h = _lookup[y2 - y1];\n        return\
    \ _op(_table[h][y1].Fold(x1, x2), _table[h][y2 - (1 << h)].Fold(x1, x2));\n  \
    \  }\n}"
  dependsOn:
  - library/data-structure/SparseTable.csx
  isVerificationFile: false
  path: library/data-structure/SparseTable2D.csx
  requiredBy: []
  timestamp: '2026-06-01 18:17:15+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/data-structure/SparseTable2D.test.csx
documentation_of: library/data-structure/SparseTable2D.csx
layout: document
redirect_from:
- /library/library/data-structure/SparseTable2D.csx
- /library/library/data-structure/SparseTable2D.csx.html
title: library/data-structure/SparseTable2D.csx
---
