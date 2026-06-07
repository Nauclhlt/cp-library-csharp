---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/data-structure/WaveletMatrix.test.csx
    title: verify/data-structure/WaveletMatrix.test.csx
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
  code: "/// <summary>\n/// Static wavelet matrix.\n/// </summary>\npublic sealed\
    \ class WaveletMatrix\n{\n    public sealed class BitVector\n    {\n        private\
    \ int _length;\n        private int[] _prefix;\n\n        public int this[int\
    \ k] => Access(k);\n\n        public BitVector(BitArray source)\n        {\n \
    \           _length = source.Length;\n            _prefix = new int[_length +\
    \ 1];\n            for (int i = 1; i <= _length; i++)\n            {\n       \
    \         _prefix[i] = _prefix[i - 1] + (source[i - 1] ? 1 : 0);\n           \
    \ }\n        }\n\n        public int Access(int k) => _prefix[k + 1] - _prefix[k];\n\
    \n        public int Rank1(int r) => _prefix[r];\n\n        public int Rank1(int\
    \ l, int r) => _prefix[r] - _prefix[l];\n\n        public int Rank0(int r) =>\
    \ r - Rank1(r);\n        public int Rank0(int l, int r) => r - l - Rank1(l, r);\n\
    \        public int Select1(int k)\n        {\n            if (k < 0 || k >= Rank1(_length))\
    \ return -1;\n\n            k++;\n\n            int l = 0;\n            int r\
    \ = _prefix.Length - 1;\n            while (r > l)\n            {\n          \
    \      int mid = l + (r - l) / 2;\n\n                if (Rank1(mid) >= k)\n  \
    \              {\n                    r = mid;\n                }\n          \
    \      else\n                {\n                    l = mid + 1;\n           \
    \     }\n            }\n\n            return l - 1;\n        }\n        public\
    \ int Select0(int k)\n        {\n            if (k < 0 || k >= Rank0(_length))\
    \ return -1;\n\n            k++;\n\n            int l = 0;\n            int r\
    \ = _prefix.Length - 1;\n            while (r > l)\n            {\n          \
    \      int mid = l + (r - l) / 2;\n\n                if (Rank0(mid) >= k)\n  \
    \              {\n                    r = mid;\n                }\n          \
    \      else\n                {\n                    l = mid + 1;\n           \
    \     }\n            }\n\n            return l - 1;\n        }\n    }\n\n    private\
    \ int _length;\n    private long[] _array;\n    private BitVector[] _matrix;\n\
    \    private int[] _zeros;\n    private int _bits;\n\n\n    /// <summary>\n  \
    \  /// Builds the wavelet matrix from the array. Time complexity is O(nlog(max)).\n\
    \    /// </summary>\n    public WaveletMatrix(int[] array) : this(array.Select(x\
    \ => (long)x).ToArray())\n    {\n    }\n\n    /// <summary>\n    /// Builds the\
    \ wavelet matrix from the array. Time complexity is O(nlog(max)).\n    /// </summary>\n\
    \    public WaveletMatrix(long[] array)\n    {\n        long max = array.Max();\n\
    \        _bits = 0;\n        _array = array;\n        _length = array.Length;\n\
    \        while ((1L << _bits) <= max) _bits++;\n        if (_bits == 0) _bits++;\n\
    \n        _matrix = new BitVector[_bits];\n        _zeros = new int[_bits];\n\
    \        List<long> current = array.ToList();\n        Queue<long> zero = new();\n\
    \        Queue<long> one = new();\n\n        for (int i = 0; i < _bits; i++)\n\
    \        {\n            int pos = _bits - i - 1;\n            BitArray ba = new(_length);\n\
    \            for (int j = 0; j < _length; j++)\n            {\n              \
    \  ba[j] = ((current[j] >> pos) & 1) == 1;\n            }\n\n            _matrix[i]\
    \ = new BitVector(ba);\n            _zeros[i] = _matrix[i].Rank0(_length);\n\n\
    \            // stable sort\n            for (int j = 0; j < _length; j++)\n \
    \           {\n                if (ba[j])\n                    one.Enqueue(current[j]);\n\
    \                else\n                    zero.Enqueue(current[j]);\n       \
    \     }\n\n            current.Clear();\n            while (zero.Count > 0) current.Add(zero.Dequeue());\n\
    \            while (one.Count > 0) current.Add(one.Dequeue());\n        }\n  \
    \  }\n\n    /// <summary>\n    /// Returns the value at the index k. Time complexity\
    \ is O(1).\n    /// </summary>\n    public long Access(int k)\n    {\n       \
    \ if (k < 0 || k >= _length) return -1;\n\n        return _array[k];\n    }\n\n\
    \    /// <summary>\n    /// Returns the number of the occurrences of v in the\
    \ range [l, r). Time complexity is O(log(max)).\n    /// </summary>\n    public\
    \ int Rank(int l, int r, long v)\n    {\n        if (l < 0 || l > r || r > _length)\
    \ return -1;\n        if (v < 0 || v >= (1L << _bits)) return 0;\n\n        for\
    \ (int i = 0; i < _bits; i++)\n        {\n            int pos = _bits - i - 1;\n\
    \n            if (((v >> pos) & 1) == 0)\n            {\n                l = _matrix[i].Rank0(l);\n\
    \                r = _matrix[i].Rank0(r);\n            }\n            else\n \
    \           {\n                l = _zeros[i] + _matrix[i].Rank1(l);\n        \
    \        r = _zeros[i] + _matrix[i].Rank1(r);\n            }\n        }\n\n  \
    \      return r - l;\n    }\n\n    /// <summary>\n    /// Returns k-th smallest\
    \ value in the range [l, r). Time complexity is O(log(max)).\n    /// </summary>\n\
    \    public long Quantile(int l, int r, int k)\n    {\n        if (l < 0 || l\
    \ > r || r > _length) return -1;\n        if (k < 0 || k >= r - l) return -1;\n\
    \n        long result = 0L;\n\n        for (int i = 0; i < _bits; i++)\n     \
    \   {\n            int pos = _bits - i - 1;\n            int zeroCount = _matrix[i].Rank0(l,\
    \ r);\n\n            if (k < zeroCount)\n            {\n                l = _matrix[i].Rank0(l);\n\
    \                r = _matrix[i].Rank0(r);\n            }\n            else\n \
    \           {\n                result |= 1L << pos;\n                k -= zeroCount;\n\
    \                l = _zeros[i] + _matrix[i].Rank1(l);\n                r = _zeros[i]\
    \ + _matrix[i].Rank1(r);\n            }\n        }\n\n        return result;\n\
    \    }\n\n    /// <summary>\n    /// Returns the index of the k-th occurrence\
    \ of v in the range [l, r). Time complexity is O(log(max)).\n    /// </summary>\n\
    \    public long Select(int l, int r, long v, int k)\n    {\n        if (l < 0\
    \ || l > r || r > _length) return -1;\n        if (v < 0 || v >= (1L << _bits))\
    \ return -1;\n\n        int left = l, right = r;\n        for (int i = 0; i <\
    \ _bits; i++)\n        {\n            int pos = _bits - i - 1;\n            if\
    \ (((v >> pos) & 1) == 0)\n            {\n                left = _matrix[i].Rank0(left);\n\
    \                right = _matrix[i].Rank0(right);\n            }\n           \
    \ else\n            {\n                left = _zeros[i] + _matrix[i].Rank1(left);\n\
    \                right = _zeros[i] + _matrix[i].Rank1(right);\n            }\n\
    \        }\n\n        if (right - left <= k) return -1;\n\n        int index =\
    \ left + k;\n\n        for (int i = _bits - 1; i >= 0; i--)\n        {\n     \
    \       int pos = _bits - i - 1;\n\n            if (((v >> pos) & 1) == 0)\n \
    \           {\n                index = _matrix[i].Select0(index);\n          \
    \  }\n            else\n            {\n                index = _matrix[i].Select1(index\
    \ - _zeros[i]);\n            }\n        }\n\n        if (l <= index && index <\
    \ r)\n            return index;\n        else\n            return -1;\n    }\n\
    \n    /// <summary>\n    /// Returns the number of values less than upperbound\
    \ in the range [l, r). Time complexity is O(log(max)).\n    /// </summary>\n \
    \   public int Frequency(int l, int r, long upperbound)\n    {\n        if (l\
    \ < 0 || l > r || r > _length) return -1;\n        if (upperbound < 0) return\
    \ 0;\n        if (upperbound >= (1L << _bits)) return r - l;\n\n        int result\
    \ = 0;\n\n        for (int i = 0; i < _bits; i++)\n        {\n            int\
    \ pos = _bits - i - 1;\n\n            if (((upperbound >> pos) & 1) == 0)\n  \
    \          {\n                l = _matrix[i].Rank0(l);\n                r = _matrix[i].Rank0(r);\n\
    \            }\n            else\n            {\n                result += _matrix[i].Rank0(l,\
    \ r);\n                l = _zeros[i] + _matrix[i].Rank1(l);\n                r\
    \ = _zeros[i] + _matrix[i].Rank1(r);\n            }\n        }\n\n        return\
    \ result;\n    }\n\n    /// <summary>\n    /// Returns the number of values in\
    \ [lower, upper) in the range [l, r). Time complexity is O(log(max)).\n    ///\
    \ </summary>\n    public int Frequency(int l, int r, long lower, long upper) =>\
    \ Frequency(l, r, upper) - Frequency(l, r, lower);\n\n    /// <summary>\n    ///\
    \ Returns the maximum value less than v in the range [l, r). Time complexity is\
    \ O(log(max)).\n    /// </summary>\n    public long PrevValue(int l, int r, long\
    \ v)\n    {\n        int count = Frequency(l, r, v);\n        if (count <= 0)\
    \ return -1;\n        return Quantile(l, r, count - 1);\n    }\n\n    /// <summary>\n\
    \    /// Returns the minimum value greater than or equals to v in the range [l,\
    \ r). Time complexity is O(log(max)).\n    /// </summary>\n    public long NextValue(int\
    \ l, int r, long v)\n    {\n        int count = Frequency(l, r, v);\n        if\
    \ (count == r - l) return -1;\n        return Quantile(l, r, count);\n    }\n\n\
    \    /// <summary>\n    /// Returns the minimum value in the range [l, r). Time\
    \ complexity is O(log(max)).\n    /// </summary>\n    public long Min(int l, int\
    \ r) => Quantile(l, r, 0);\n    /// <summary>\n    /// Returns the maximum value\
    \ in the range [l, r). Time complexity is O(log(max)).\n    /// </summary>\n \
    \   public long Max(int l, int r) => Quantile(l, r, r - l - 1);\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/data-structure/WaveletMatrix.csx
  requiredBy: []
  timestamp: '2026-06-07 13:52:56+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/data-structure/WaveletMatrix.test.csx
documentation_of: library/data-structure/WaveletMatrix.csx
layout: document
title: Wavelet Matrix
---

#### 説明

Wavelet Matrix(ウェーブレット行列)というデータ構造. 静的な列の任意区間に対して, Binary Trieでできる操作はだいたいできる. 

長さ $N$ の列 $A$ (ただし, $\forall i, 0\leq A_i<2^M$) に対して以下のような手順で行列を構成する.

- $i=1, 2, \cdots, M$ の順に以下に従って行 $i$ をつくる
- $i=1$ なら, 元の列 $A$ の最上位ビットを並べたもの, $i>1$ なら, 元の列 $A$ を上から $i-1$ ビット目で安定ソートした列の上から $i$ ビット目を並べたもの

こうすることで, 区間 $[l, r)$ に対するBinary Trieを考えるとき, すべての深さ $d$ のノードが $d$ 行目において連続した区間として現れる. よってBinary Trieのノードを降りていくような処理が, 区間の変換によって実現できる. これにより各クエリは $O(\log M)$ で処理できる.

各行を完備辞書(簡潔ビットベクトル)で持つことで各種クエリの処理に必要な操作が低メモリかつ定数時間で行える. (このあたりはメモリ使用量と実装量のトレードオフでいい感じに)

#### 注意点
- ビットベクトルは累積和で空間 $O(N\log N)$ のものを使っている

#### 関数
- `Access(k)`: $k$ 番目の値を取得する
- `Rank(l, r, v)`: 区間 $[l, r)$ に含まれる値 $v$ の個数を取得する
- `Quantile(l, r, k)`: 区間 $[l, r)$ に含まれる値を昇順に並べたときの, $k$ 番目の値を取得する
- `Select(l, r, v, k)`: 区間 $[l, r)$ に含まれる $v$ のうち, $k$ 番目に出現するものの位置を取得する
- `Frequency(l, r, upperbound)`: 区間 $[l, r)$ に含まれる値のうち, $upperbound$ 未満のものの個数を取得する
- `Frequency(l, r, lower, upper)`: 区間 $[l, r)$ に含まれる値のうち, $lower$ 以上 $upper$ 未満であるものの個数を取得する
- `PrevValue(l, r, v)`: 区間 $[l, r)$ に含まれる $v$ 未満の値のうち, 最大のものを取得する
- `NextValue(l, r, v)`: 区間 $[l, r)$ に含まれる $v$ 以上の値のうち, 最小のものを取得する
- `Min(l, r)`: 区間 $[l, r)$ の最小値を取得する
- `Max(l, r)`: 区間 $[l, r)$ の最大値を取得する