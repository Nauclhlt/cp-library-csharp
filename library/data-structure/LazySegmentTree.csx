/// <summary>
/// Segment Tree with lazy evaluation. (Recursive, can be used with non-commutative monoid)
/// </summary>
public sealed class LazySegmentTree<T, M> where T : struct, IEquatable<T> where M : struct, IEquatable<M>
{
    public delegate T Monoid(T x, T y);
    public delegate M Composition(M x, M y);
    public delegate T Mapping(T x, M y, int l);

    private int _treeSize;
    private int _dataSize;
    private int _originalDataSize;
    private T[] _data;
    private M?[] _lazy;
    private Monoid _operator;
    private Mapping _mapping;
    private Composition _composition;
    private T _identity;

    /// <summary>
    /// Gets the value by index. Time complexity is O(logn).
    /// </summary>
    public T this[int index]
    {
        get
        {
            return Access(index);
        }
    }

    /// <summary>
    /// Builds the segment tree. Time complexity is O(n).
    /// </summary>
    /// <param name="n">Size of the segment tree.</param>
    /// <param name="op">Binary operation.</param>
    /// <param name="mapping">Mapping function.</param>
    /// <param name="composition">Composition function. composition(x, y) := yox</param>
    /// <param name="identity">Identity.</param>
    public LazySegmentTree(int n, Monoid op, Mapping mapping, Composition composition, T identity)
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
        _data.AsSpan().Fill(_identity);
        _lazy = new M?[_treeSize];

        _identity = identity;
        _operator = op;
        _mapping = mapping;
        _composition = composition;
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

    private void Evaluate(int index, int l, int r)
    {
        if (_lazy[index] is null)
        {
            return;
        }

        if (index < _dataSize - 1)
        {
            _lazy[(index << 1) + 1] = GuardComposition(_lazy[(index << 1) + 1], _lazy[index]);
            _lazy[(index << 1) + 2] = GuardComposition(_lazy[(index << 1) + 2], _lazy[index]);
        }

        _data[index] = _mapping(_data[index], (M)_lazy[index], r - l);
        _lazy[index] = null;
    }

    private M GuardComposition(M? a, M? b)
    {
        if (a is null)
        {
            return (M)b;
        }
        else
        {
            return _composition((M)a, (M)b);
        }
    }

    /// <summary>
    /// Update the range [l, r) by m. Time complexity is O(logn).
    /// </summary>
    public void Update(int l, int r, M m)
    {
        if (l == r) return;

        if (0 <= l && l < r && r <= _originalDataSize)
            ApplyRec(l, r, m, 0, 0, _dataSize);
    }
    
    private void ApplyRec(int a, int b, M m, int index, int l, int r)
    {
        Evaluate(index, l, r);

        if (a >= r || b <= l)
        {
            return;
        }

        if (a <= l && r <= b)
        {
            _lazy[index] = GuardComposition(_lazy[index], m);
            Evaluate(index, l, r);
        }
        else
        {
            ApplyRec(a, b, m, (index << 1) + 1, l, (l + r) / 2);
            ApplyRec(a, b, m, (index << 1) + 2, (l + r) / 2, r);
            _data[index] = _operator(_data[(index << 1) + 1], _data[(index << 1) + 2]);
        }
    }

    /// <summary>
    /// Gets the product of the range [l, r). Time complexity is O(logn).
    /// </summary>
    /// <param name="l"></param>
    /// <param name="r"></param>
    /// <returns></returns>
    public T Fold(int l, int r)
    {
        if (l == r) return _identity;

        if (0 <= l && l < r && r <= _originalDataSize)
            return QueryRec(l, r, 0, 0, _dataSize);
        else
            return _identity;
    }

    private T QueryRec(int left, int right, int index, int nodeLeft, int nodeRight)
    {
        Evaluate(index, nodeLeft, nodeRight);

        if (left >= nodeRight || right <= nodeLeft)
        {
            return _identity;
        }

        if (left <= nodeLeft && nodeRight <= right)
        {
            return _data[index];
        }

        T leftChild = QueryRec(left, right, (index << 1) + 1, nodeLeft, (nodeLeft + nodeRight) >> 1);
        T rightChild = QueryRec(left, right, (index << 1) + 2, (nodeLeft + nodeRight) >> 1, nodeRight);

        return _operator(leftChild, rightChild);
    }

    /// <summary>
    /// Gets the value at the specified index. Time complexity is O(logn).
    /// </summary>
    public T Access(int index)
    {
        if (index < 0 || index >= _originalDataSize)
        {
            throw new Exception("Index is out of range.");
        }

        return AccessRec(index, 0, 0, _dataSize);
    }

    private T AccessRec(int target, int index, int l, int r)
    {
        Evaluate(index, l, r);

        if (index >= _dataSize - 1)
        {
            return _data[index];
        }

        int mid = (l + r) / 2;
        if (target < mid)
        {
            return AccessRec(target, (index << 1) + 1, l, mid);
        }
        else
        {
            return AccessRec(target, (index << 1) + 2, mid, r);
        }
    }

    private void EvaluateAll(int index, int l, int r)
    {
        if (_lazy[index] is null)
        {
            if (index < _dataSize - 1)
            {
                EvaluateAll((index << 1) + 1, l, (l + r) / 2);
                EvaluateAll((index << 1) + 2, (l + r) / 2, r);
            }
            return;
        }

        if (index < _dataSize - 1)
        {
            _lazy[(index << 1) + 1] = GuardComposition(_lazy[(index << 1) + 1], _lazy[index]);
            _lazy[(index << 1) + 2] = GuardComposition(_lazy[(index << 1) + 2], _lazy[index]);
            EvaluateAll((index << 1) + 1, l, (l + r) / 2);
            EvaluateAll((index << 1) + 2, (l + r) / 2, r);
        }

        _data[index] = _mapping(_data[index], (M)_lazy[index], r - l);
        _lazy[index] = null;
    }

    /// <summary>
    /// Returns the span of the underlying data. Time complexity is O(n).
    /// </summary>
    /// <returns></returns>
    public ReadOnlySpan<T> AsSpan()
    {
        EvaluateAll(0, 0, _dataSize);

        return _data.AsSpan(_dataSize - 1, _originalDataSize);
    }
}