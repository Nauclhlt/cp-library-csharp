#load "DirectedGraph.csx"

public partial class DirectedGraph<T>
{
    /// <summary>
    /// Divides the vertices into strongly connected components. Time complexity is O(V+E).
    /// </summary>
    public List<List<int>> DivideSCC()
    {
        bool[] seen = new bool[_vertexCount];
        List<int> postorder = new(_vertexCount);

        void dfs1(int n)
        {
            seen[n] = true;

            var ch = _adjList[n];
            for (int i = 0; i < ch.Count; i++)
            {
                if (!seen[ch[i].To])
                    dfs1(ch[i].To);
            }

            postorder.Add(n);
        }

        for (int i = 0; i < _vertexCount; i++)
        {
            if (!seen[i])
            {
                dfs1(i);
            }
        }

        Array.Clear(seen);

        List<List<int>> res = new();
        Stack<int> stack = new();

        for (int i = postorder.Count - 1; i >= 0; i--)
        {
            int p = postorder[i];
            if (seen[p]) continue;

            List<int> list = new();

            stack.Push(p);

            while (stack.Count > 0)
            {
                int n = stack.Pop();

                if (seen[n]) continue;

                seen[n] = true;
                list.Add(n);

                var ch = _reverseAdjList[n];
                for (int j = 0; j < ch.Count; j++)
                {
                    stack.Push(ch[j].To);
                }
            }

            res.Add(list);
        }

        return res;
    }
}