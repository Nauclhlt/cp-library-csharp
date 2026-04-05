/// <summary>
/// Fenwick Tree. (Binary-Indexed Tree)
/// </summary>
/// <typeparam name="T">Type of data.</typeparam>
public sealed class FenwickTree<T> where T : INumber<T>
{
    private T[] _data;
    private int _size;
 
    public int Size => _size;

    public FenwickTree(int n)
    {
        _size = n;
        _data = new T[n + 1];
    }

    public T this[int index]
    {
        get => PrefixSum(index + 1) - PrefixSum(index);
    }

    /// <summary>
    /// Rebuilds the fenwick tree by the array. Time complexity is O(nlogn).
    /// </summary>
    public void Build(T[] array)
    {
        Array.Fill(_data, T.Zero);

        for (int i = 0; i < int.Min(array.Length, _size); i++)
        {
            Add(i, array[i]);
        }
    }

    /// <summary>
    /// Adds the value to the index-th element.
    /// </summary>
    public void Add(int index, T value)
    {
        // 1-indexed
        index++;

        while (index < _data.Length)
        {
            _data[index] += value;
            index += LSB(index);
        }
    }

    /// <summary>
    /// Updates the index-th element by value.
    /// </summary>
    public void Update(int index, T value)
    {
        T delta = value - this[index];
        Add(index, delta);
    }

    /// <summary>
    /// Gets the sum of the interval [0, length). Time complexity is O(logn).
    /// </summary>
    public T PrefixSum(int length)
    {
        if (length == 0) return T.Zero;

        T sum = T.Zero;

        int index = length;
        while (index > 0)
        {
            sum += _data[index];
            index -= LSB(index);
        }

        return sum;
    }

    /// <summary>
    /// Gets the sum of the interval [l, r). Time complexity is O(logn).
    /// </summary>
    public T Sum(int l, int r)
    {
        return PrefixSum(r) - PrefixSum(l);
    }
    
    private int LSB(int x)
    {
        return x & (-x);
    }

    /// <summary>
    /// Returns the view span for the underlying data. Time complexity is O(1).
    /// </summary>
    public ReadOnlySpan<T> AsSpan()
    {
        return _data;
    }
}