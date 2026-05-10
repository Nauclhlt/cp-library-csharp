#load "LazySegmentTree.csx"

public sealed class CirnoArray<T> where T : struct, INumber<T>, IMinMaxValue<T>
{
    private LazySegmentTree<Node, (T b, T c)> _data;

    private struct Node : IEquatable<Node>
    {
        public T Sum;
        public T Max;
        public T Min;

        public Node(T sum, T max, T min)
        {
            Sum = sum;
            Max = max;
            Min = min;
        }

        public bool Equals(Node other)
        {
            return Sum == other.Sum && Max == other.Max && Min == other.Min;
        }
    }

    public CirnoArray(int n)
    {
        InitSegmentTree(n);
        _data.Fill(new(T.Zero, T.Zero, T.Zero));
    }

    public CirnoArray(T[] source)
    {
        InitSegmentTree(source.Length);
        Node[] arr = new Node[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            arr[i] = new(source[i], source[i], source[i]);
        }
        _data.Build(arr);
    }

    private void InitSegmentTree(int n)
    {
        _data = new(n, (x, y) => new(x.Sum + y.Sum, T.Max(x.Max, y.Max), T.Min(x.Min, y.Min)), (x, a, l) => new(x.Sum * a.b + T.CreateChecked(l) * a.c, a.b > T.Zero ? x.Max * a.b + a.c : x.Min * a.b + a.c, a.b > T.Zero ? x.Min * a.b + a.c : x.Max * a.b + a.c), (x, y) => (x.b * y.b, y.b * x.c + y.c), new(T.Zero, T.MinValue, T.MaxValue));
    }

    public T this[int index]
    {
        get => _data.Access(index).Sum;
        set => _data.Update(index, index + 1, (T.Zero, value));
    }

    public void Add(int index, T value)
    {
        _data.Update(index, index + 1, (T.MultiplicativeIdentity, value));
    }

    public void Add(int l, int r, T value)
    {
        _data.Update(l, r, (T.MultiplicativeIdentity, value));
    }

    public void Multiply(int index, T value)
    {
        _data.Update(index, index + 1, (value, T.AdditiveIdentity));
    }

    public void Multiply(int l, int r, T value)
    {
        _data.Update(l, r, (value, T.AdditiveIdentity));
    }

    public T Sum(int l, int r)
    {
        return _data.Fold(l, r).Sum;
    }

    public T Max(int l, int r)
    {
        return _data.Fold(l, r).Max;
    }

    public T Min(int l, int r)
    {
        return _data.Fold(l, r).Min;
    }
}