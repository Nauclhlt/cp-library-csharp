#load "DirectedGraph.csx"

public partial class DirectedGraph<T>
{
    /// <summary>
    /// Calculates the topological sort of the vertices contained in the graph. Returns true if the graph is DAG and sort is successfully completed, otherwise false.
    /// Time complexity is O(V+E).
    /// </summary>
    public bool TryTopologicalSort(out List<int> sorted)
    {
        sorted = new List<int>(_vertexCount);

        int[] deg = new int[_vertexCount];
        for (int i = 0; i < _directionAwareEdges.Count; i++)
        {
            deg[_directionAwareEdges[i].To]++;
        }

        Stack<int> stack = new();
        for (int i = 0; i < _vertexCount; i++)
        {
            if (deg[i] == 0) stack.Push(i);
        }

        while (stack.Count > 0)
        {
            int next = stack.Pop();
            sorted.Add(next);

            List<Edge<T>> p = _adjList[next];
            for (int i = 0; i < p.Count; i++)
            {
                deg[p[i].To]--;
                if (deg[p[i].To] < 0) return false;

                if (deg[p[i].To] == 0)
                {
                    stack.Push(p[i].To);
                }
            }
        }

        return sorted.Count == _vertexCount;
    }

    /// <summary>
    /// Calculates the topological sort of the vertices contained in the graph. Returns true if the graph is DAG, sort is successfully completed, and also the graph has only one topological sort, otherwise false.
    /// Time complexity is O(V+E).
    /// </summary>
    public bool TryUniqueTopologicalSort(out List<int> sorted)
    {
        sorted = new List<int>(_vertexCount);

        int[] deg = new int[_vertexCount];
        for (int i = 0; i < _directionAwareEdges.Count; i++)
        {
            deg[_directionAwareEdges[i].To]++;
        }

        Queue<int> queue = new();
        for (int i = 0; i < _vertexCount; i++)
        {
            if (deg[i] == 0) queue.Enqueue(i);
        }

        while (queue.Count > 0)
        {
            if (queue.Count > 1) return false;

            int next = queue.Dequeue();
            sorted.Add(next);

            List<Edge<T>> p = _adjList[next];
            for (int i = 0; i < p.Count; i++)
            {
                deg[p[i].To]--;
                if (deg[p[i].To] < 0) return false;

                if (deg[p[i].To] == 0)
                {
                    queue.Enqueue(p[i].To);
                }
            }
        }

        return sorted.Count == _vertexCount;
    }
}