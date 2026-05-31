#load "Graph.csx"

public partial class Graph<T>
{
    /// <summary>
    /// Constructs the euler tour sequences from the tree. Time complexity is O(nlogn).
    /// </summary>
    public EulerTour<V> ConstructEulerTour<V>(int root = 0, V[] vertexWeights = null) where V : INumber<V>
    {
        if (_vertexCount - 1 != _edges.Count)
        {
            throw new InvalidOperationException("Not a tree graph.");
        }

        if (vertexWeights is not null && vertexWeights.Length != _vertexCount)
        {
            throw new InvalidOperationException("Invalid vertex weights.");
        }

        if (vertexWeights is null)
        {
            vertexWeights = new V[_vertexCount];
            Array.Fill(vertexWeights, V.Zero);
        }

        List<int> visit = new();
        List<T> edge = new();
        List<T> edgeMinus = new();
        List<V> vertex = new();
        List<V> vertexMinus = new();
        List<int> depths = new();
        int[] timeIn = new int[_vertexCount];
        int[] timeOut = new int[_vertexCount];

        void dfs(int v, int prev, T weight, int depth)
        {
            visit.Add(v);
            vertex.Add(vertexWeights[v]);
            edge.Add(weight);
            vertexMinus.Add(vertexWeights[v]);
            edgeMinus.Add(weight);
            depths.Add(depth);
            timeIn[v] = visit.Count - 1;

            for (int i = 0; i < _adjList[v].Count; i++)
            {
                if (_adjList[v][i].To == prev) continue;

                int next = _adjList[v][i].To;
                dfs(next, v, _adjList[v][i].Weight, depth + 1);

                visit.Add(v);
                vertex.Add(V.Zero);
                edge.Add(T.Zero);
                vertexMinus.Add(-vertexWeights[next]);
                edgeMinus.Add(-_adjList[v][i].Weight);
                depths.Add(depth);
            }

            timeOut[v] = visit.Count - 1;
        }

        dfs(root, -1, T.Zero, 0);

        return new(visit.ToArray(), vertex.ToArray(), vertexMinus.ToArray(), edge.ToArray(), edgeMinus.ToArray(), depths.ToArray(), timeIn, timeOut, vertexWeights);
    }

    public sealed class EulerTour<V> where V : INumber<V>
    {
        /// <summary>
        /// Sparse table, which can compute interval products of associative and idempotent operations.
        /// </summary>
        public sealed class ArgminRMQ
        {
            private int[][] _table;
            private int[][] _argmin;
            private int[] _lookup;
            private int _length;

            /// <summary>
            /// Build the sparse table by the array. Time complexity is O(nlogn).
            /// </summary>
            public ArgminRMQ(int[] array)
            {
                _length = array.Length;
                int exp = 0;
                while (1 << (exp + 1) <= array.Length) exp++;
                _table = new int[exp + 1][];
                _argmin = new int[exp + 1][];
                for (int i = 0; i <= exp; i++)
                {
                    _table[i] = new int[_length];
                    _argmin[i] = new int[_length];
                }

                for (int i = 0; i <= exp; i++)
                {
                    int width = 1 << i;
                    for (int j = 0; j <= _length - width; j++)
                    {
                        if (width == 1)
                        {
                            _table[i][j] = array[j];
                            _argmin[i][j] = j;
                        }
                        else
                        {
                            _table[i][j] = int.Min(_table[i - 1][j], _table[i - 1][j + (1 << (i - 1))]);
                            if (_table[i - 1][j] == _table[i][j]) _argmin[i][j] = _argmin[i - 1][j];
                            else _argmin[i][j] = _argmin[i - 1][j + (1 << (i - 1))];
                        }
                    }
                }

                _lookup = new int[_length + 1];
                for (int i = 2; i <= _length; i++)
                {
                    _lookup[i] = _lookup[i / 2] + 1;
                }
            }

            /// <summary>
            /// Gets the product of the interval [l, r). Time complexity is O(1).
            /// </summary>
            public int Fold(int l, int r, out int argmin)
            {
                if (l >= r)
                {
                    argmin = -1;
                    return int.MaxValue;
                }
                int len = r - l;
                int x = _lookup[len];
                int min = int.Min(_table[x][l], _table[x][r - (1 << x)]);
                if (_table[x][l] == min) argmin = _argmin[x][l];
                else argmin = _argmin[x][r - (1 << x)];
                return min;
            }
        }

        private int[] _visit;
        private V[] _vertex;
        private V[] _vertexMinus;
        private V[] _vertexWeights;
        private T[] _edge;
        private T[] _edgeMinus;
        private int[] _depth;
        private int[] _in;
        private int[] _out;

        private ArgminRMQ _depthRMQ;
        private V[] _vertexPS;
        private V[] _vertexMinusPS;
        private T[] _edgePS;
        private T[] _edgeMinusPS;

        public EulerTour(int[] visit, V[] vertex, V[] vertexMinus, T[] edge, T[] edgeMinus, int[] depth, int[] @in, int[] @out, V[] vertexWeights)
        {
            _visit = visit;
            _vertex = vertex;
            _vertexMinus = vertexMinus;
            _vertexWeights = vertexWeights;
            _edge = edge;
            _edgeMinus = edgeMinus;
            _depth = depth;
            _in = @in;
            _out = @out;

            _depthRMQ = new(_depth);
            _vertexPS = new V[_vertex.Length + 1];
            _vertexMinusPS = new V[_vertex.Length + 1];
            _edgePS = new T[_edge.Length + 1];
            _edgeMinusPS = new T[_edge.Length + 1];

            _vertexPS[0] = V.Zero;
            _vertexMinusPS[0] = V.Zero;
            _edgePS[0] = T.Zero;
            _edgeMinusPS[0] = T.Zero;
            for (int i = 1; i <= _vertex.Length; i++)
            {
                _vertexPS[i] = _vertexPS[i - 1] + _vertex[i - 1];
                _vertexMinusPS[i] = _vertexMinusPS[i - 1] + _vertexMinus[i - 1];
            }

            for (int i = 1; i <= _edge.Length; i++)
            {
                _edgePS[i] = _edgePS[i - 1] + _edge[i - 1];
                _edgeMinusPS[i] = _edgeMinusPS[i - 1] + _edgeMinus[i - 1];
            }
        }

        /// <summary>
        /// Gets the LCA of a and b. Time complexity is O(1).
        /// </summary>
        public int Lca(int a, int b)
        {
            if (a == b) return a;

            int l = int.Min(_in[a], _in[b]);
            int r = int.Max(_out[a], _out[b]) + 1;

            _depthRMQ.Fold(l, r, out int index);
            return _visit[index];
        }

        /// <summary>
        /// Gets the sum of weights of vertices in the subtree.
        /// </summary>
        public V SubtreeVertexWeightSum(int root)
        {
            int l = _in[root];
            int r = _out[root] + 1;

            return _vertexPS[r] - _vertexPS[l];
        }

        /// <summary>
        /// Gets the sum of weights of edges in the subtree.
        /// </summary>
        public T SubtreeEdgeWeightSum(int root)
        {
            int l = _in[root] + 1;
            int r = _out[root] + 1;

            return _edgePS[r] - _edgePS[l];
        }

        /// <summary>
        /// Gets the sum of weights of vertices contained in the path from the root to the vertex v.
        /// </summary>
        public V RootPathVertexWeightSum(int v)
        {
            return _vertexMinusPS[_in[v] + 1];
        }

        /// <summary>
        /// Gets the sum of weights of edges contained in the path from the root to the vertex v.
        /// </summary>
        public T RootPathEdgeWeightSum(int v)
        {
            return _edgeMinusPS[_in[v] + 1] - _edgeMinusPS[1];
        }

        /// <summary>
        /// Gets the sum of weights of vetices contained in the path between u and v.
        /// </summary>
        public V PathVertexWeightSum(int u, int v)
        {
            int lca = Lca(u, v);

            return RootPathVertexWeightSum(u) + RootPathVertexWeightSum(v) - RootPathVertexWeightSum(lca) - RootPathVertexWeightSum(lca) + _vertexWeights[lca];
        }

        /// <summary>
        /// Gets the sum of weights of edges contained in the path between u and v.
        /// </summary>
        public T PathEdgeWeightSum(int u, int v)
        {
            int lca = Lca(u, v);

            return RootPathEdgeWeightSum(u) + RootPathEdgeWeightSum(v) - RootPathEdgeWeightSum(lca) - RootPathEdgeWeightSum(lca);
        }
    }
}