#load "GraphBase.csx"

public partial class GraphBase<T>
{
    /// <summary>
    /// Calculates the distances from vertex n using Dijkstra algorithm. Do not use this for graphs with one or more negative cycles.
    /// Time complexity is O((E+V)logV).
    /// </summary>
    public T[] DijkstraFrom(int n)
    {
        if (!Validate(n)) return null;

        bool[] seen = new bool[_vertexCount];
        T[] map = new T[_vertexCount];
        Array.Fill(map, T.MaxValue);

        map[n] = T.Zero;

        PriorityQueue<int, T> pq = new();

        pq.Enqueue(n, T.Zero);

        while (pq.Count > 0)
        {
            int p = pq.Dequeue();

            if (seen[p]) continue;

            seen[p] = true;

            List<Edge<T>> children = _adjList[p];
            for (int i = 0; i < children.Count; i++)
            {
                T w = map[p] + children[i].Weight;
                if (w < map[children[i].To])
                {
                    map[children[i].To] = w;
                    pq.Enqueue(children[i].To, map[children[i].To]);
                }
            }
        }

        return map;
    }

    /// <summary>
    /// Calculates the distances from vertex n using Dijkstra algorithm. Do not use this for graphs with one or more negative cycles.
    /// Time complexity is O((E+V)logV).
    /// </summary>
    public T[] ImplicitDijkstraFrom(int n)
    {
        if (!Validate(n)) 
            return null;

        T[] map = new T[_vertexCount];
        Array.Fill(map, T.MaxValue);

        map[n] = T.Zero;

        PriorityQueue<(int, T), T> pq = new();
        pq.Enqueue((n, T.Zero), T.Zero);

        while (pq.Count > 0)
        {
            (int p, T d) = pq.Dequeue();

            if (map[p] < d) continue;

            List<Edge<T>> children = _adjList[p];
            for (int i = 0; i < children.Count; i++)
            {
                T w = map[p] + children[i].Weight;
                if (w < map[children[i].To])
                {
                    map[children[i].To] = w;
                    pq.Enqueue((children[i].To, map[children[i].To]), map[children[i].To]);
                }
            }
        }

        return map;
    }
}