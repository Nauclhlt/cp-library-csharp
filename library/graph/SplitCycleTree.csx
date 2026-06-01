#load "DirectedGraph.csx"
#load "SCC.csx"

public partial class DirectedGraph<T>
{
    /// <summary>
    /// Divides the functional graph into cycles and trees. Time complexity is O(V+E).
    /// </summary>
    public (List<List<int>> cycles, Graph<T> trees) SplitCycleTree(bool sortCycle = false)
    {
        List<List<int>> scc = this.DivideSCC();

        List<List<int>> cycles = new();
        Graph<T> tree = new(_vertexCount);

        for (int i = 0; i < scc.Count; i++)
        {
            if (scc[i].Count == 1 && _adjList[scc[i][0]][0].To != scc[i][0])
            {
                // part of the trees
                int u = scc[i][0];
                tree.AddEdge(u, _adjList[u][0].To, _adjList[u][0].Weight);
            }
            else
            {
                // cycle
                if (sortCycle)
                {
                    List<int> sorted = new(scc[i].Count);
                    sorted.Add(scc[i][0]);
                    for (int j = 1; j < scc[i].Count; j++)
                    {
                        sorted.Add(_adjList[sorted[^1]][0].To);
                    }

                    cycles.Add(sorted);
                }
                else
                {
                    cycles.Add(scc[i]);
                }
            }
        }

        return (cycles, tree);
    }
}