#load "GraphBase.csx"

public partial class GraphBase<T>
{
    /// <summary>
    /// Calculates the distances from vertex n using Bellmann-Ford algorithm. Returns true if the graph contains at least one negative cycle, otherwise false. 
    /// Time complexity is O(VE).
    /// </summary>
    public T[] BellmannFordFrom(int n)
    {
        if (!Validate(n))
        {
            return null;
        }

        T[] map = new T[_vertexCount];
        Array.Fill(map, T.MaxValue);

        map[n] = T.Zero;

        for (int i = 0; i < _vertexCount - 1; i++)
        {
            for (int j = 0; j < _directionAwareEdges.Count; j++)
            {
                Edge<T> e = _directionAwareEdges[j];
                if (map[e.From] == T.MaxValue) continue;

                T w = map[e.From] + e.Weight;
                if (w < map[e.To])
                {
                    map[e.To] = w;
                }
            }
        }

        bool[] negative = new bool[_vertexCount];
        for (int i = 0; i < _vertexCount; i++)
        {
            for (int j = 0; j < _directionAwareEdges.Count; j++)
            {
                Edge<T> e = _directionAwareEdges[j];
                if (map[e.From] == T.MaxValue) continue;

                T w = map[e.From] + e.Weight;
                if (w < map[e.To])
                {
                    map[e.To] = w;
                    negative[e.To] = true;
                }
                if (negative[e.From])
                {
                    negative[e.To] = true;
                }
            }
        }

        for (int i = 0; i < _vertexCount; i++)
        {
            if (negative[i])
            {
                map[i] = T.MinValue;
            }
        }

        return map;
    }
}