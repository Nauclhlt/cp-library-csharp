// @title Segment Tree

/// <summary>
/// Segment tree. (Non-recursive, compatible for non-commutative monoid)
/// </summary>
/// <typeparam name="T">Type of values.</typeparam>
public sealed class SegmentTree<T> where T : struct
{
    public delegate T Monoid(T x, T y);

    private int _treeSize;
    private int _dataSize;
    private int _originalDataSize;
    private T[] _data;
    private Monoid _operator;
    private Monoid _update;
    private T _identity;

    public int OriginalDataSize => _originalDataSize;
    public int TreeSize => _treeSize;
    public T Identity => _identity;

    /// <summary>
    /// Gets the value by index. Time complexity is O(1).
    /// </summary>
    public T this[int index]
    {
        get
        {
            return _data[_dataSize - 1 + index];
        }
    }

    /// <summary>
    /// Builds the segment tree. Time complexity is O(n).
    /// </summary>
    public SegmentTree(int n, Monoid op, Monoid update, T identity)
    {
        _originalDataSize = n;

        int size = 1;
        while (n > size)
        {
            size <<= 1;
        }

        _dataSize = size;
        _treeSize = 2 * size - 1;

        _data = new T[_treeSize];
        Array.Fill(_data, identity);
        _identity = identity;
        _operator = op;
        _update = update;
    }

    /// <summary>
    /// Rebuild the segment tree from the array. Time complexity is O(n).
    /// Since the time complexity of n Update() calls is O(nlogn), when initializing the segment tree with an array, 
    /// call this function to make it faster.
    /// </summary>
    public void Build(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            _data[i + _dataSize - 1] = array[i];
        }

        for (int i = _dataSize - 2; i >= 0; i--)
        {
            _data[i] = _operator(_data[(i << 1) + 1], _data[(i << 1) + 2]);
        }
    }

    public void UpdateByArray(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            _data[i + _dataSize - 1] = _update(_data[i + _dataSize - 1], array[i]);
        }

        for (int i = _dataSize - 2; i >= 0; i--)
        {
            _data[i] = _operator(_data[(i << 1) + 1], _data[(i << 1) + 2]);
        }
    }

    /// <summary>
    /// Fill the array with the uniform value. Time complexity is O(n).
    /// </summary>
    public void Fill(T value)
    {
        for (int i = 0; i < _originalDataSize; i++)
        {
            _data[i + _dataSize - 1] = value;
        }

        for (int i = _dataSize - 2; i >= 0; i--)
        {
            _data[i] = _operator(_data[(i << 1) + 1], _data[(i << 1) + 2]);
        }
    }

    /// <summary>
    /// Update the value at the specified position. Time complexity is O(logn).
    /// </summary>
    public void Update(int index, T value)
    {
        index += _dataSize - 1;
        _data[index] = _update(_data[index], value);

        while (index > 0)
        {
            index = (index - 1) >> 1;
            _data[index] = _operator(_data[(index << 1) + 1], _data[(index << 1) + 2]);
        }
    }

    /// <summary>
    /// Gets the product of the range [l, r). Time complexity is O(logn).
    /// </summary>
    public T Fold(int l, int r)
    {
        l += _dataSize - 1;
        r += _dataSize - 1;

        T leftFold = _identity;
        T rightFold = _identity;
        while (l < r)
        {
            if ((l & 1) == 0)
            {
                leftFold = _operator(leftFold, _data[l]);
                l++;
            }
            if ((r & 1) == 0)
            {
                r--;
                rightFold = _operator(_data[r], rightFold);
            }

            l = (l - 1) >> 1;
            r = (r - 1) >> 1;
        }

        return _operator(leftFold, rightFold);
    }

    /// <summary>
    /// Returns the span of the underlying data. Time complexity is O(1).
    /// </summary>
    public ReadOnlySpan<T> AsSpan()
    {
        return _data.AsSpan(_dataSize - 1, _originalDataSize);
    }
}