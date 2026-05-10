#load "GraphBase.csx"

public partial class DirectedGraph<T> : GraphBase<T> where T : struct, INumber<T>, IMinMaxValue<T>
{
    private List<List<Edge<T>>> _reverseAdjList;
    private List<Edge<T>> _reverseEdges;

    public List<List<Edge<T>>> ReverseAdjList => _reverseAdjList;
    public List<Edge<T>> ReverseEdges => _reverseEdges;
    public List<Edge<T>> Edges => _directionAwareEdges;

    public DirectedGraph(int vertexCount)
    {
        Initialize(vertexCount);
        _reverseAdjList = new(vertexCount);
        for (int i = 0; i < vertexCount; i++)
        {
            _reverseAdjList.Add(new());
        }
        _reverseEdges = new();
    }

    public override void AddEdge(int a, int b, T weight)
    {
        if (!Validate(a) || !Validate(b)) return;

        Edge<T> e = new Edge<T>(a, b, weight);
        Edge<T> rev = new Edge<T>(b, a, weight);

        _adjList[a].Add(e);
        _reverseAdjList[b].Add(rev);
        _directionAwareEdges.Add(e);
        _reverseEdges.Add(rev);
    }
}