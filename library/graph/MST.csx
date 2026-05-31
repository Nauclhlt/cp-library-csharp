#load "Graph.csx"
#load "../data-structure/UnionFind.csx"

public partial class Graph<T>
{
    /// <summary>
    /// Gets the sum of weights of the edges in the maximum spanning tree of the graph.
    /// Time complexity is O(ElogE).
    /// </summary>
    public T MaxSpanningTreeWeight()
    {
        UnionFind unionFind = new(_vertexCount);

        T ans = T.Zero;
        foreach (var edge in _edges.OrderByDescending(x => x.Weight))
        {
            if (!unionFind.Same(edge.From, edge.To))
            {
                unionFind.Unite(edge.From, edge.To);
                ans += edge.Weight;
            }
        }

        return ans;
    }

    /// <summary>
    /// Gets the sum of weights of the edges in the minimum spanning tree of the graph.
    /// Time complexity is O(ElogE).
    /// </summary>
    public T MinSpanningTreeWeight()
    {
        UnionFind unionFind = new(_vertexCount);

        T ans = T.Zero;
        foreach (var edge in _edges.OrderBy(x => x.Weight))
        {
            if (!unionFind.Same(edge.From, edge.To))
            {
                unionFind.Unite(edge.From, edge.To);
                ans += edge.Weight;
            }
        }

        return ans;
    }
}