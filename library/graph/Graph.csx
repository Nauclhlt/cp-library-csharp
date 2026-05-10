#load "GraphBase.csx"

public partial class Graph<T> : GraphBase<T> where T : struct, INumber<T>, IMinMaxValue<T>
{
    private List<Edge<T>> _edges;

    public List<Edge<T>> Edges => _edges;

    public Graph(int vertexCount)
    {
        Initialize(vertexCount);
        _edges = new();
    }

    public override void AddEdge(int a, int b, T weight)
    {
        if (!Validate(a) || !Validate(b)) return;

        if (a > b)
        {
            (a, b) = (b, a);
        }

        Edge<T> right = new Edge<T>(a, b, weight);
        Edge<T> left = new Edge<T>(b, a, weight);

        _adjList[a].Add(right);
        _adjList[b].Add(left);
        _edges.Add(right);
        _directionAwareEdges.Add(left);
        _directionAwareEdges.Add(right);
    }

    public Graph<T> CreateComplement()
    {
        if ((long)_vertexCount * _vertexCount >= 100000000L)
        {
            throw new InvalidOperationException("Too large graph.");
        }

        HashSet<(int, int)> edgeSet = new();
        for (int i = 0; i < _edges.Count; i++)
        {
            edgeSet.Add((_edges[i].From, _edges[i].To));
        }

        Graph<T> g = new(_vertexCount);

        for (int i = 0; i < _vertexCount - 1; i++)
        {
            for (int j = i + 1; j < _vertexCount; j++)
            {
                if (!edgeSet.Contains((i, j)))
                {
                    g.AddEdge(i, j, default);
                }
            }
        }

        return g;
    }

    public bool IsBipartite()
    {
        bool[] seen = new bool[_vertexCount];

        Stack<(int, bool)> stack = new();

        bool[] memo = new bool[_vertexCount];

        for (int i = 0; i < _vertexCount; i++)
        {
            stack.Push((i, false));

            while (stack.Count > 0)
            {
                (int n, bool c) = stack.Pop();

                if (seen[n])
                {
                    if (memo[n] != !c) return false;
                    continue;
                }

                seen[n] = true;
                memo[n] = !c;

                var ch = _adjList[n];
                for (int j = 0; j < ch.Count; j++)
                {
                    stack.Push((ch[j].To, !c));
                }
            }
        }

        return true;
    }
}