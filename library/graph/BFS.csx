#load "GraphBase.csx"
#load "Graph.csx"

public partial class Graph<T>
{
    /// <summary>
    /// Runs BFS. For trees, this returns the distances from the specified vertex. Time complexity is O(V+E).
    /// </summary>
    public T[] BfsFrom(int n)
    {
        if (!Validate(n)) return null;

        bool[] seen = new bool[_vertexCount];

        T[] map = new T[_vertexCount];
        map[n] = T.Zero;

        Queue<(int, T)> queue = new();

        queue.Enqueue((n, T.Zero));

        while (queue.Count > 0)
        {
            (int p, T w) = queue.Dequeue();

            if (seen[p]) continue;

            seen[p] = true;
            map[p] = w;

            List<Edge<T>> children = _adjList[p];
            for (int i = 0; i < children.Count; i++)
            {
                queue.Enqueue((children[i].To, w + children[i].Weight));
            }
        }

        return map;
    }
}