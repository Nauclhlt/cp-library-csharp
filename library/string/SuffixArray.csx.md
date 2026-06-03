---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/string/SuffixArray.test.csx
    title: verify/string/SuffixArray.test.csx
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
  code: "/// <summary>\n/// Suffix array.\n/// </summary>\npublic sealed class SuffixArray\n\
    {\n    private readonly string _source;\n    private readonly int _length;\n \
    \   private int[] _suffixArray;\n\n    public int[] InnerArray => _suffixArray;\n\
    \n    /// <summary>\n    /// Builds the suffix array of the specified source string.\
    \ Time complexity is O(n).\n    /// </summary>\n    public SuffixArray(string\
    \ source)\n    {\n        _source = source;\n        _length = _source.Length;\n\
    \        Build();\n    }\n\n    /// <summary>\n    /// Determines if the source\
    \ string contains the specified string s. Time complexity is O(nlogn)\n    ///\
    \ </summary>\n    public bool Contains(string s)\n    {\n        if (string.IsNullOrEmpty(s))\
    \ return true;\n\n        ReadOnlySpan<char> spanS = s.AsSpan();\n        ReadOnlySpan<char>\
    \ sourceSpan = _source.AsSpan();\n\n        int left = 0;\n        int right =\
    \ _length;\n\n        while (right > left)\n        {\n            int mid = left\
    \ + (right - left) / 2;\n            int suffixStart = _suffixArray[mid];\n  \
    \          int cmpLength = Math.Min(_length - suffixStart, spanS.Length);\n\n\
    \            if (sourceSpan.Slice(suffixStart, cmpLength).SequenceCompareTo(spanS)\
    \ < 0)\n            {\n                left = mid + 1;\n            }\n      \
    \      else\n            {\n                right = mid;\n            }\n    \
    \    }\n\n        return left < _length && sourceSpan.Slice(_suffixArray[left]).StartsWith(spanS);\n\
    \    }\n\n    /// <summary>\n    /// Returns the number of the occurrences of\
    \ the specified string s in the source string. Time complexity is O(nlogn).\n\
    \    /// </summary>\n    public int CountOf(string s)\n    {\n        if (string.IsNullOrEmpty(s))\
    \ return _length;\n\n        ReadOnlySpan<char> spanS = s.AsSpan();\n        ReadOnlySpan<char>\
    \ sourceSpan = _source.AsSpan();\n\n        int lower = 0;\n        {\n      \
    \      int left = 0;\n            int right = _length;\n            while (right\
    \ > left)\n            {\n                int mid = left + (right - left) / 2;\n\
    \                int suffixStart = _suffixArray[mid];\n                int cmpLength\
    \ = Math.Min(_length - suffixStart, spanS.Length);\n\n                if (sourceSpan.Slice(suffixStart,\
    \ cmpLength).SequenceCompareTo(spanS) < 0)\n                    left = mid + 1;\n\
    \                else\n                    right = mid;\n            }\n     \
    \       lower = left;\n        }\n\n        int upper = 0;\n        {\n      \
    \      int left = 0;\n            int right = _length;\n            while (right\
    \ > left)\n            {\n                int mid = left + (right - left) / 2;\n\
    \                int suffixStart = _suffixArray[mid];\n                int cmpLength\
    \ = Math.Min(_length - suffixStart, spanS.Length);\n\n                if (sourceSpan.Slice(suffixStart,\
    \ cmpLength).SequenceCompareTo(spanS) <= 0)\n                    left = mid +\
    \ 1;\n                else\n                    right = mid;\n            }\n\
    \            upper = left;\n        }\n\n        return upper - lower;\n    }\n\
    \n    private void Build()\n    {\n        if (_length == 0)\n        {\n    \
    \        _suffixArray = Array.Empty<int>();\n            return;\n        }\n\n\
    \        int[] str = new int[_length + 1];\n        int maxChar = 0;\n       \
    \ \n        for (int i = 0; i < _length; i++)\n        {\n            str[i] =\
    \ _source[i] + 1;\n            if (str[i] > maxChar) maxChar = str[i];\n     \
    \   }\n        str[_length] = 0;\n\n        int[] temp = SAIS(str, maxChar + 1);\n\
    \        \n        _suffixArray = new int[_length];\n        Array.Copy(temp,\
    \ 1, _suffixArray, 0, _length);\n    }\n\n    public override string ToString()\n\
    \    {\n        return $\"[{string.Join(\" \", _suffixArray)}]\";\n    }\n\n \
    \   [MethodImpl(MethodImplOptions.AggressiveInlining)]\n    private static bool\
    \ IsLMS(int i, BitArray isS) => i > 0 && isS[i] && !isS[i - 1];\n\n    private\
    \ int[] SAIS(int[] str, int charCount)\n    {\n        int n = str.Length;\n \
    \       //bool[] isS = new bool[n];\n        BitArray isS = new(n);\n        isS[n\
    \ - 1] = true;\n\n        for (int i = n - 2; i >= 0; i--)\n        {\n      \
    \      isS[i] = str[i] < str[i + 1] || (str[i] == str[i + 1] && isS[i + 1]);\n\
    \        }\n\n        int lmsCount = 0;\n        for (int i = 1; i < n; i++)\n\
    \        {\n            if (isS[i] && !isS[i - 1]) lmsCount++;\n        }\n\n\
    \        int[] lms = new int[lmsCount];\n        int lmsIdx = 0;\n        for\
    \ (int i = 1; i < n; i++)\n        {\n            if (isS[i] && !isS[i - 1]) lms[lmsIdx++]\
    \ = i;\n        }\n\n        int[] psa = InducedSort(str, lms, isS, charCount);\n\
    \n        int[] orderedLMS = new int[lmsCount];\n        int index = 0;\n    \
    \    for (int i = 0; i < psa.Length; i++)\n        {\n            int p = psa[i];\n\
    \            if (IsLMS(p, isS))\n            {\n                orderedLMS[index++]\
    \ = p;\n            }\n        }\n\n        psa[orderedLMS[0]] = 0;\n        int\
    \ rank = 0;\n        if (lmsCount > 1) psa[orderedLMS[1]] = ++rank;\n\n      \
    \  for (int i = 1; i < lmsCount - 1; i++)\n        {\n            bool diff =\
    \ false;\n            int p = orderedLMS[i];\n            int q = orderedLMS[i\
    \ + 1];\n\n            for (int j = 0; j < n; j++)\n            {\n          \
    \      int jp = p + j;\n                int jq = q + j;\n\n                if\
    \ (str[jp] != str[jq] || isS[jp] != isS[jq])\n                {\n            \
    \        diff = true;\n                    break;\n                }\n       \
    \         \n                if (j > 0 && (IsLMS(jp, isS) || IsLMS(jq, isS)))\n\
    \                {\n                    break;\n                }\n          \
    \  }\n\n            psa[q] = diff ? ++rank : rank;\n        }\n\n        int[]\
    \ nstr = new int[lmsCount];\n        index = 0;\n        for (int i = 0; i < n;\
    \ i++)\n        {\n            if (IsLMS(i, isS))\n            {\n           \
    \     nstr[index++] = psa[i];\n            }\n        }\n\n        int[] lmssa;\n\
    \        if (rank + 1 == lmsCount)\n        {\n            lmssa = orderedLMS;\n\
    \        }\n        else\n        {\n            lmssa = SAIS(nstr, rank + 1);\n\
    \            for (int i = 0; i < lmssa.Length; i++)\n            {\n         \
    \       lmssa[i] = lms[lmssa[i]];\n            }\n        }\n\n        return\
    \ InducedSort(str, lmssa, isS, charCount);\n    }\n\n    private int[] InducedSort(int[]\
    \ str, int[] lms, BitArray isS, int charCount)\n    {\n        int n = str.Length;\n\
    \        int[] buckets = new int[n];\n        buckets.AsSpan().Fill(-1);\n\n \
    \       int[] bucketHeads = new int[charCount];\n        int[] bucketTails = new\
    \ int[charCount];\n        int[] counts = new int[charCount];\n\n        for (int\
    \ i = 0; i < n; i++)\n        {\n            counts[str[i]]++;\n        }\n\n\
    \        int sum = 0;\n        for (int i = 0; i < charCount; i++)\n        {\n\
    \            bucketHeads[i] = sum;\n            sum += counts[i];\n          \
    \  bucketTails[i] = sum - 1;\n        }\n\n        int[] tails = (int[])bucketTails.Clone();\n\
    \        for (int i = lms.Length - 1; i >= 0; i--)\n        {\n            int\
    \ c = str[lms[i]];\n            buckets[bucketTails[c]--] = lms[i];\n        }\n\
    \n        for (int i = 0; i < n; i++)\n        {\n            int p = buckets[i];\n\
    \            if (p > 0 && !isS[p - 1])\n            {\n                int c =\
    \ str[p - 1];\n                buckets[bucketHeads[c]++] = p - 1;\n          \
    \  }\n        }\n\n        for (int i = n - 1; i >= 0; i--)\n        {\n     \
    \       int p = buckets[i];\n            if (p > 0 && isS[p - 1])\n          \
    \  {\n                int c = str[p - 1];\n                buckets[tails[c]--]\
    \ = p - 1;\n            }\n        }\n\n        return buckets;\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/string/SuffixArray.csx
  requiredBy: []
  timestamp: '2026-06-03 15:40:08+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/string/SuffixArray.test.csx
documentation_of: library/string/SuffixArray.csx
layout: document
title: "Suffix Array(\u63A5\u5C3E\u8F9E\u914D\u5217)"
---

#### 説明

文字列 $S$ (長さ $N$) に対して, $S$ の接尾辞 $N$ 個を辞書順に並べた列を $S$ の接尾辞配列(suffix array)という. データ構造としては, 各接尾辞の始まりが何文字目かという整数で管理する.

愚直に文字列を生成してソートする方法では, $O(N^2\log N)$ などの計算量になってしまうが, SA-IS法を用いることで $O(N)$ となる.

#### 注意点
- とくになし

#### 関数
- `Contains(s)`: $s$ が(連続)部分文字列として含まれるかを返す
- `CountOf(s)`: $s$ が何個(連続)部分文字列として含まれるかを返す