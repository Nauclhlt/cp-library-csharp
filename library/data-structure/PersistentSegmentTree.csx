/// <summary>
/// Persistent segment tree.
/// </summary>
public sealed class PersistentSegmentTree<T>
{
    public delegate T Monoid(T x, T y);

    private sealed class Node
    {
        public T Data { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }

        public Node(T data)
        {
            Data = data;
            LeftNode = null;
            RightNode = null;
        }
    }

    private int _treeSize;
    private int _size;
    private Monoid _operator;
    private Monoid _update;
    private T _identity;
    private List<Node> _snapshots;

    public int Size => _size;
    public int TreeSize => _treeSize;
    public T Identity => _identity;

    public PersistentSegmentTree(int n, Monoid op, Monoid update, T identity)
    {
        _size = n;
        _treeSize = 2 * _size - 1;

        _identity = identity;
        _operator = op;
        _update = update;

        _snapshots = new();
    }

    /// <summary>
    /// Returns the value at the specified index, at the specified time. Time complexity is O(logn).
    /// </summary>
    public T this[int time, int index]
    {
        get
        {
            return Access(time, index);
        }
    }

    /// <summary>
    /// Builds the segment tree from the array. Time complexity is O(n).
    /// </summary>
    public int Build(T[] array)
    {
        if (_size != array.Length)
        {
            throw new InvalidOperationException("Size of the specified array does not match with the data size passed in the constructor.");
        }

        return RegisterNode(BuildRange(0, array.Length, array));
    }

    /// <summary>
    /// Fills the segment tree with the uniform value. Time complexity is O(n).
    /// </summary>
    public int Fill(T value)
    {
        return RegisterNode(BuildFillRange(0, _size, value));
    }

    private Node BuildFillRange(int l, int r, T value)
    {
        if (l + 1 >= r) return new Node(value);
        else return MergeNode(BuildFillRange(l, (l + r) / 2, value), BuildFillRange((l + r) / 2, r, value));
    }

    private Node BuildRange(int l, int r, T[] array)
    {
        if (l + 1 >= r) return new Node(array[l]);
        else return MergeNode(BuildRange(l, (l + r) / 2, array), BuildRange((l + r) / 2, r, array));
    }

    private Node MergeNode(Node l, Node r)
    {
        Node res = new (_operator(l.Data, r.Data))
        {
            LeftNode = l,
            RightNode = r
        };
        return res;
    }

    /// <summary>
    /// Clear all snapshots. Time complexity is O(1).
    /// </summary>
    public void ClearSnapshots()
    {
        _snapshots.Clear();
    }

    private int RegisterNode(Node node)
    {
        _snapshots.Add(node);
        return _snapshots.Count - 1;
    }

    private Node GetRoot(int time)
    {
        return _snapshots[time];
    }

    /// <summary>
    /// Updates the value at the specified index, at the specified time. Time complexity is O(logn).
    /// </summary>
    public int Update(int time, int index, T value)
    {
        return RegisterNode(ApplyRec(index, value, GetRoot(time), 0, _size));
    }

    private Node ApplyRec(int index, T value, Node node, int l, int r)
    {
        if (r <= index || index + 1 <= l)
        {
            return node;
        }
        else if (index <= l && r <= index + 1)
        {
            return new Node(_update(node.Data, value));
        }
        else
        {
            return MergeNode(ApplyRec(index, value, node.LeftNode, l, (l + r) / 2), ApplyRec(index, value, node.RightNode, (l + r) / 2, r));
        }
    }

    /// <summary>
    /// Returns the product of the interval [l, r), at the specified time. Time complexity is O(logn).
    /// </summary>
    public T Fold(int time, int l, int r)
    {
        return QueryRec(l, r, GetRoot(time), 0, _size);
    }

    private T QueryRec(int left, int right, Node node, int l, int r)
    {
        if (r <= left || right <= l)
        {
            return _identity;
        }
        else if (left <= l && r <= right)
        {
            return node.Data;
        }
        else
        {
            return _operator(QueryRec(left, right, node.LeftNode, l, (l + r) / 2), QueryRec(left, right, node.RightNode, (l + r) / 2, r));
        }
    }

    /// <summary>
    /// Returns the value at the specified index, at the specified time. Time complexity is O(logn).
    /// </summary>
    public T Access(int time, int index)
    {
        Node current = GetRoot(time);
        int l = 0;
        int r = _size;
        while (true)
        {
            if (l == index && l + 1 == r) return current.Data;

            if (index < (l + r) / 2)
            {
                r = (l + r) / 2;
                current = current.LeftNode;
            }
            else
            {
                l = (l + r) / 2;
                current = current.RightNode;
            }
        }
    }
}