/// <summary>
/// Abstract base class for graphs.
/// </summary>
public abstract partial class GraphBase<T> where T : struct, INumber<T>, IMinMaxValue<T>
{
    protected List<List<Edge<T>>> _adjList;
    protected List<Edge<T>> _directionAwareEdges;
    protected int _vertexCount;

    public int VertexCount => _vertexCount;
    public List<List<Edge<T>>> AdjList => _adjList;
    public List<Edge<T>> DirectionAwareEdges => _directionAwareEdges;

    protected void Initialize(int vertexCount)
    {
        _vertexCount = vertexCount;
        _adjList = new(vertexCount);
        for (int i = 0; i < vertexCount; i++)
        {
            _adjList.Add(new());
        }
        _directionAwareEdges = new();
    }

    public abstract void AddEdge(int a, int b, T weight);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Validate(int n)
    {
        return 0 <= n && n < _vertexCount;
    }
}

public readonly struct Edge<T> : IEquatable<Edge<T>>, IComparable<Edge<T>> where T : struct, INumber<T>
{
    public readonly int To;
    public readonly int From;
    public readonly T Weight;

    public Edge(int to, T weight)
    {
        this.To = to;
        this.Weight = weight;
    }

    public Edge(int from, int to, T weight)
    {
        this.To = to;
        this.From = from;
        this.Weight = weight;
    }

    public override bool Equals(object obj)
    {
        if (obj is Edge<T> edge)
        {
            return this.Equals(edge);
        }
        else
        {
            return false;
        }
    }

    public int CompareTo(Edge<T> other)
    {
        return Weight.CompareTo(other.Weight);
    }

    public bool Equals(Edge<T> edge)
    {
        return To == edge.To && From == edge.From && Weight == edge.Weight;
    }

    public override int GetHashCode()
    {
        return (To, From, Weight).GetHashCode();
    }

    public static bool operator ==(Edge<T> left, Edge<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Edge<T> left, Edge<T> right)
    {
        return !left.Equals(right);
    }
}