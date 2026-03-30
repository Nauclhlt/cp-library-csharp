/// <summary>
/// Union-Find(disjoint set union).
/// </summary>
public sealed class UnionFind
{
    private int[] _parents;
    private int[] _size;
    private int _vertexCount;

    public int VertexCount => _vertexCount;

    public UnionFind(int n)
    {
        _vertexCount = n;
        _parents = new int[n];
        _size = new int[n];
        for (int i = 0; i < n; i++)
        {
            _parents[i] = i;
            _size[i] = 1;
        }
    }

    /// <summary>
    /// Gets the leader(root) of the connected component x belongs to. Time complexity is O(α(n)).
    /// </summary>
    public int Leader(int x)
    {
        if (_parents[x] == x)
            return x;
        return _parents[x] = Leader(_parents[x]);
    }

    /// <summary>
    /// Gets the size of the connected component x belongs to. Time complexity is O(α(n)).
    /// </summary>
    public int Size(int x)
    {
        return _size[Leader(x)];
    }

    /// <summary>
    /// Merge the two connected components. Time complexity is O(α(n)).
    /// </summary>
    public void Unite(int x, int y)
    {
        int rootX = Leader(x);
        int rootY = Leader(y);
        if (rootX == rootY)
            return;
            
        int from = rootX;
        int to = rootY;
        
        // union by size.(small-to-large merging)
        if (_size[from] > _size[to])
        {
            (from, to) = (to, from);
        }

        _size[to] += _size[from];
        _parents[from] = to;
    }

    /// <summary>
    /// Gets the list of vertices which belong to the connected component of x. Time complexity is O(n).
    /// </summary>
    public List<int> GetGroup(int x)
    {
        int rootX = Leader(x);
        List<int> set = new List<int>();
        for (int i = 0; i < _vertexCount; i++)
        {
            if (Leader(i) == rootX)
                set.Add(i);
        }

        return set;
    }

    /// <summary>
    /// Gets the vertex list of all connected components. Time complexity is O(n).
    /// </summary>
    public Dictionary<int, List<int>> FindAll()
    {
        Dictionary<int, List<int>> sets = new Dictionary<int, List<int>>();
        for (int i = 0; i < _vertexCount; i++)
        {
            int root = Leader(i);
            if (sets.ContainsKey(root))
                sets[root].Add(i);
            else
                sets[root] = new List<int>() { i };
        }

        return sets;
    }

    /// <summary>
    /// Determines if the x and y belong to the same connected component. Time complexity is O(α(n)).
    /// </summary>
    public bool Same(int x, int y)
    {
        int rootX = Leader(x);
        int rootY = Leader(y);
        return rootX == rootY;
    }

    /// <summary>
    /// Clears the data. Time complexity is O(n).
    /// </summary>
    public void Clear()
    {
        for (int i = 0; i < _vertexCount; i++)
        {
            _parents[i] = i;
            _size[i] = 1;
        }
    }
}