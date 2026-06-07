/// <summary>
/// Static wavelet matrix.
/// </summary>
public sealed class WaveletMatrix
{
    public sealed class BitVector
    {
        private int _length;
        private int[] _prefix;

        public int this[int k] => Access(k);

        public BitVector(BitArray source)
        {
            _length = source.Length;
            _prefix = new int[_length + 1];
            for (int i = 1; i <= _length; i++)
            {
                _prefix[i] = _prefix[i - 1] + (source[i - 1] ? 1 : 0);
            }
        }

        public int Access(int k) => _prefix[k + 1] - _prefix[k];

        public int Rank1(int r) => _prefix[r];

        public int Rank1(int l, int r) => _prefix[r] - _prefix[l];

        public int Rank0(int r) => r - Rank1(r);
        public int Rank0(int l, int r) => r - l - Rank1(l, r);
        public int Select1(int k)
        {
            if (k < 0 || k >= Rank1(_length)) return -1;

            k++;

            int l = 0;
            int r = _prefix.Length - 1;
            while (r > l)
            {
                int mid = l + (r - l) / 2;

                if (Rank1(mid) >= k)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return l - 1;
        }
        public int Select0(int k)
        {
            if (k < 0 || k >= Rank0(_length)) return -1;

            k++;

            int l = 0;
            int r = _prefix.Length - 1;
            while (r > l)
            {
                int mid = l + (r - l) / 2;

                if (Rank0(mid) >= k)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return l - 1;
        }
    }

    private int _length;
    private long[] _array;
    private BitVector[] _matrix;
    private int[] _zeros;
    private int _bits;


    /// <summary>
    /// Builds the wavelet matrix from the array. Time complexity is O(nlog(max)).
    /// </summary>
    public WaveletMatrix(int[] array) : this(array.Select(x => (long)x).ToArray())
    {
    }

    /// <summary>
    /// Builds the wavelet matrix from the array. Time complexity is O(nlog(max)).
    /// </summary>
    public WaveletMatrix(long[] array)
    {
        long max = array.Max();
        _bits = 0;
        _array = array;
        _length = array.Length;
        while ((1L << _bits) <= max) _bits++;
        if (_bits == 0) _bits++;

        _matrix = new BitVector[_bits];
        _zeros = new int[_bits];
        List<long> current = array.ToList();
        Queue<long> zero = new();
        Queue<long> one = new();

        for (int i = 0; i < _bits; i++)
        {
            int pos = _bits - i - 1;
            BitArray ba = new(_length);
            for (int j = 0; j < _length; j++)
            {
                ba[j] = ((current[j] >> pos) & 1) == 1;
            }

            _matrix[i] = new BitVector(ba);
            _zeros[i] = _matrix[i].Rank0(_length);

            // stable sort
            for (int j = 0; j < _length; j++)
            {
                if (ba[j])
                    one.Enqueue(current[j]);
                else
                    zero.Enqueue(current[j]);
            }

            current.Clear();
            while (zero.Count > 0) current.Add(zero.Dequeue());
            while (one.Count > 0) current.Add(one.Dequeue());
        }
    }

    /// <summary>
    /// Returns the value at the index k. Time complexity is O(1).
    /// </summary>
    public long Access(int k)
    {
        if (k < 0 || k >= _length) return -1;

        return _array[k];
    }

    /// <summary>
    /// Returns the number of the occurrences of v in the range [l, r). Time complexity is O(log(max)).
    /// </summary>
    public int Rank(int l, int r, long v)
    {
        if (l < 0 || l > r || r > _length) return -1;
        if (v < 0 || v >= (1L << _bits)) return 0;

        for (int i = 0; i < _bits; i++)
        {
            int pos = _bits - i - 1;

            if (((v >> pos) & 1) == 0)
            {
                l = _matrix[i].Rank0(l);
                r = _matrix[i].Rank0(r);
            }
            else
            {
                l = _zeros[i] + _matrix[i].Rank1(l);
                r = _zeros[i] + _matrix[i].Rank1(r);
            }
        }

        return r - l;
    }

    /// <summary>
    /// Returns k-th smallest value in the range [l, r). Time complexity is O(log(max)).
    /// </summary>
    public long Quantile(int l, int r, int k)
    {
        if (l < 0 || l > r || r > _length) return -1;
        if (k < 0 || k >= r - l) return -1;

        long result = 0L;

        for (int i = 0; i < _bits; i++)
        {
            int pos = _bits - i - 1;
            int zeroCount = _matrix[i].Rank0(l, r);

            if (k < zeroCount)
            {
                l = _matrix[i].Rank0(l);
                r = _matrix[i].Rank0(r);
            }
            else
            {
                result |= 1L << pos;
                k -= zeroCount;
                l = _zeros[i] + _matrix[i].Rank1(l);
                r = _zeros[i] + _matrix[i].Rank1(r);
            }
        }

        return result;
    }

    /// <summary>
    /// Returns the index of the k-th occurrence of v in the range [l, r). Time complexity is O(log(max)).
    /// </summary>
    public long Select(int l, int r, long v, int k)
    {
        if (l < 0 || l > r || r > _length) return -1;
        if (v < 0 || v >= (1L << _bits)) return -1;

        int left = l, right = r;
        for (int i = 0; i < _bits; i++)
        {
            int pos = _bits - i - 1;
            if (((v >> pos) & 1) == 0)
            {
                left = _matrix[i].Rank0(left);
                right = _matrix[i].Rank0(right);
            }
            else
            {
                left = _zeros[i] + _matrix[i].Rank1(left);
                right = _zeros[i] + _matrix[i].Rank1(right);
            }
        }

        if (right - left <= k) return -1;

        int index = left + k;

        for (int i = _bits - 1; i >= 0; i--)
        {
            int pos = _bits - i - 1;

            if (((v >> pos) & 1) == 0)
            {
                index = _matrix[i].Select0(index);
            }
            else
            {
                index = _matrix[i].Select1(index - _zeros[i]);
            }
        }

        if (l <= index && index < r)
            return index;
        else
            return -1;
    }

    /// <summary>
    /// Returns the number of values less than upperbound in the range [l, r). Time complexity is O(log(max)).
    /// </summary>
    public int Frequency(int l, int r, long upperbound)
    {
        if (l < 0 || l > r || r > _length) return -1;
        if (upperbound < 0) return 0;
        if (upperbound >= (1L << _bits)) return r - l;

        int result = 0;

        for (int i = 0; i < _bits; i++)
        {
            int pos = _bits - i - 1;

            if (((upperbound >> pos) & 1) == 0)
            {
                l = _matrix[i].Rank0(l);
                r = _matrix[i].Rank0(r);
            }
            else
            {
                result += _matrix[i].Rank0(l, r);
                l = _zeros[i] + _matrix[i].Rank1(l);
                r = _zeros[i] + _matrix[i].Rank1(r);
            }
        }

        return result;
    }

    /// <summary>
    /// Returns the number of values in [lower, upper) in the range [l, r). Time complexity is O(log(max)).
    /// </summary>
    public int Frequency(int l, int r, long lower, long upper) => Frequency(l, r, upper) - Frequency(l, r, lower);

    /// <summary>
    /// Returns the maximum value less than v in the range [l, r). Time complexity is O(log(max)).
    /// </summary>
    public long PrevValue(int l, int r, long v)
    {
        int count = Frequency(l, r, v);
        if (count <= 0) return -1;
        return Quantile(l, r, count - 1);
    }

    /// <summary>
    /// Returns the minimum value greater than or equals to v in the range [l, r). Time complexity is O(log(max)).
    /// </summary>
    public long NextValue(int l, int r, long v)
    {
        int count = Frequency(l, r, v);
        if (count == r - l) return -1;
        return Quantile(l, r, count);
    }

    /// <summary>
    /// Returns the minimum value in the range [l, r). Time complexity is O(log(max)).
    /// </summary>
    public long Min(int l, int r) => Quantile(l, r, 0);
    /// <summary>
    /// Returns the maximum value in the range [l, r). Time complexity is O(log(max)).
    /// </summary>
    public long Max(int l, int r) => Quantile(l, r, r - l - 1);
}