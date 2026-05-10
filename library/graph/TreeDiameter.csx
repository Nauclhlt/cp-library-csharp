#load "GraphBase.csx"
#load "Graph.csx"
#load "BFS.csx"

public partial class Graph<T>
{
    /// <summary>
    /// Calculates the diameter of the tree, the maximum length of simple paths contained in the tree. Time complexity is O(V).
    /// </summary>
    public T GetDiameter()
    {
        if (_vertexCount - 1 != _edges.Count)
        {
            throw new InvalidOperationException("Not a tree graph.");
        }

        T[] dist = this.BfsFrom(0);

        T max = T.Zero;
        int v = 0;
        for (int i = 0; i < _vertexCount; i++)
        {
            if (dist[i] > max)
            {
                max = dist[i];
                v = i;
            }
        }

        dist = this.BfsFrom(v);

        return dist.Max();
    }
}