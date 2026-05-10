#load "GraphBase.csx"

public partial class GraphBase<T>
{
    /// <summary>
    /// Calculates the distances between any two vertices contained in the graph. Time complexity is O(E+V^3).
    /// </summary>
    public T[,] WarshallFloyd()
    {
        if (_vertexCount > 800)
        {
            throw new InvalidOperationException("Too large graph.");
        }

        T[,] map = new T[_vertexCount, _vertexCount];

        for (int i = 0; i < _vertexCount; i++)
        {
            for (int j = 0; j < _vertexCount; j++)
            {
                map[i, j] = T.MaxValue;
            }
        }

        for (int i = 0; i < _vertexCount; i++)
        {
            map[i, i] = T.Zero;
        }

        for (int i = 0; i < _directionAwareEdges.Count; i++)
        {
            Edge<T> e = _directionAwareEdges[i];
            map[e.From, e.To] = T.Min(e.Weight, map[e.From, e.To]);
        }

        for (int k = 0; k < _vertexCount; k++)
        {
            for (int i = 0; i < _vertexCount; i++)
            {
                for (int j = 0; j < _vertexCount; j++)
                {
                    if (map[i, k] != T.MaxValue && map[k, j] != T.MaxValue)
                    {
                        if (map[i, k] + map[k, j] < map[i, j])
                        {
                            map[i, j] = map[i, k] + map[k, j];
                        }
                    }
                }
            }
        }

        return map;
    }
}