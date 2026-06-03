/// <summary>
/// Suffix array.
/// </summary>
public sealed class SuffixArray
{
    private readonly string _source;
    private readonly int _length;
    private int[] _suffixArray;

    public int[] InnerArray => _suffixArray;

    /// <summary>
    /// Builds the suffix array of the specified source string. Time complexity is O(n).
    /// </summary>
    public SuffixArray(string source)
    {
        _source = source;
        _length = _source.Length;
        Build();
    }

    /// <summary>
    /// Determines if the source string contains the specified string s. Time complexity is O(nlogn)
    /// </summary>
    public bool Contains(string s)
    {
        if (string.IsNullOrEmpty(s)) return true;

        ReadOnlySpan<char> spanS = s.AsSpan();
        ReadOnlySpan<char> sourceSpan = _source.AsSpan();

        int left = 0;
        int right = _length;

        while (right > left)
        {
            int mid = left + (right - left) / 2;
            int suffixStart = _suffixArray[mid];
            int cmpLength = Math.Min(_length - suffixStart, spanS.Length);

            if (sourceSpan.Slice(suffixStart, cmpLength).SequenceCompareTo(spanS) < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left < _length && sourceSpan.Slice(_suffixArray[left]).StartsWith(spanS);
    }

    /// <summary>
    /// Returns the number of the occurrences of the specified string s in the source string. Time complexity is O(nlogn).
    /// </summary>
    public int CountOf(string s)
    {
        if (string.IsNullOrEmpty(s)) return _length;

        ReadOnlySpan<char> spanS = s.AsSpan();
        ReadOnlySpan<char> sourceSpan = _source.AsSpan();

        int lower = 0;
        {
            int left = 0;
            int right = _length;
            while (right > left)
            {
                int mid = left + (right - left) / 2;
                int suffixStart = _suffixArray[mid];
                int cmpLength = Math.Min(_length - suffixStart, spanS.Length);

                if (sourceSpan.Slice(suffixStart, cmpLength).SequenceCompareTo(spanS) < 0)
                    left = mid + 1;
                else
                    right = mid;
            }
            lower = left;
        }

        int upper = 0;
        {
            int left = 0;
            int right = _length;
            while (right > left)
            {
                int mid = left + (right - left) / 2;
                int suffixStart = _suffixArray[mid];
                int cmpLength = Math.Min(_length - suffixStart, spanS.Length);

                if (sourceSpan.Slice(suffixStart, cmpLength).SequenceCompareTo(spanS) <= 0)
                    left = mid + 1;
                else
                    right = mid;
            }
            upper = left;
        }

        return upper - lower;
    }

    private void Build()
    {
        if (_length == 0)
        {
            _suffixArray = Array.Empty<int>();
            return;
        }

        int[] str = new int[_length + 1];
        int maxChar = 0;
        
        for (int i = 0; i < _length; i++)
        {
            str[i] = _source[i] + 1;
            if (str[i] > maxChar) maxChar = str[i];
        }
        str[_length] = 0;

        int[] temp = SAIS(str, maxChar + 1);
        
        _suffixArray = new int[_length];
        Array.Copy(temp, 1, _suffixArray, 0, _length);
    }

    public override string ToString()
    {
        return $"[{string.Join(" ", _suffixArray)}]";
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsLMS(int i, BitArray isS) => i > 0 && isS[i] && !isS[i - 1];

    private int[] SAIS(int[] str, int charCount)
    {
        int n = str.Length;
        //bool[] isS = new bool[n];
        BitArray isS = new(n);
        isS[n - 1] = true;

        for (int i = n - 2; i >= 0; i--)
        {
            isS[i] = str[i] < str[i + 1] || (str[i] == str[i + 1] && isS[i + 1]);
        }

        int lmsCount = 0;
        for (int i = 1; i < n; i++)
        {
            if (isS[i] && !isS[i - 1]) lmsCount++;
        }

        int[] lms = new int[lmsCount];
        int lmsIdx = 0;
        for (int i = 1; i < n; i++)
        {
            if (isS[i] && !isS[i - 1]) lms[lmsIdx++] = i;
        }

        int[] psa = InducedSort(str, lms, isS, charCount);

        int[] orderedLMS = new int[lmsCount];
        int index = 0;
        for (int i = 0; i < psa.Length; i++)
        {
            int p = psa[i];
            if (IsLMS(p, isS))
            {
                orderedLMS[index++] = p;
            }
        }

        psa[orderedLMS[0]] = 0;
        int rank = 0;
        if (lmsCount > 1) psa[orderedLMS[1]] = ++rank;

        for (int i = 1; i < lmsCount - 1; i++)
        {
            bool diff = false;
            int p = orderedLMS[i];
            int q = orderedLMS[i + 1];

            for (int j = 0; j < n; j++)
            {
                int jp = p + j;
                int jq = q + j;

                if (str[jp] != str[jq] || isS[jp] != isS[jq])
                {
                    diff = true;
                    break;
                }
                
                if (j > 0 && (IsLMS(jp, isS) || IsLMS(jq, isS)))
                {
                    break;
                }
            }

            psa[q] = diff ? ++rank : rank;
        }

        int[] nstr = new int[lmsCount];
        index = 0;
        for (int i = 0; i < n; i++)
        {
            if (IsLMS(i, isS))
            {
                nstr[index++] = psa[i];
            }
        }

        int[] lmssa;
        if (rank + 1 == lmsCount)
        {
            lmssa = orderedLMS;
        }
        else
        {
            lmssa = SAIS(nstr, rank + 1);
            for (int i = 0; i < lmssa.Length; i++)
            {
                lmssa[i] = lms[lmssa[i]];
            }
        }

        return InducedSort(str, lmssa, isS, charCount);
    }

    private int[] InducedSort(int[] str, int[] lms, BitArray isS, int charCount)
    {
        int n = str.Length;
        int[] buckets = new int[n];
        buckets.AsSpan().Fill(-1);

        int[] bucketHeads = new int[charCount];
        int[] bucketTails = new int[charCount];
        int[] counts = new int[charCount];

        for (int i = 0; i < n; i++)
        {
            counts[str[i]]++;
        }

        int sum = 0;
        for (int i = 0; i < charCount; i++)
        {
            bucketHeads[i] = sum;
            sum += counts[i];
            bucketTails[i] = sum - 1;
        }

        int[] tails = (int[])bucketTails.Clone();
        for (int i = lms.Length - 1; i >= 0; i--)
        {
            int c = str[lms[i]];
            buckets[bucketTails[c]--] = lms[i];
        }

        for (int i = 0; i < n; i++)
        {
            int p = buckets[i];
            if (p > 0 && !isS[p - 1])
            {
                int c = str[p - 1];
                buckets[bucketHeads[c]++] = p - 1;
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            int p = buckets[i];
            if (p > 0 && isS[p - 1])
            {
                int c = str[p - 1];
                buckets[tails[c]--] = p - 1;
            }
        }

        return buckets;
    }
}