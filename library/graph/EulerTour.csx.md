---
data:
  _extendedDependsOn:
  - icon: ':heavy_check_mark:'
    path: library/graph/Graph.csx
    title: "Graph(\u7121\u5411\u30B0\u30E9\u30D5)"
  - icon: ':heavy_check_mark:'
    path: library/graph/GraphBase.csx
    title: Graph Base
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/graph/EulerTour.test.csx
    title: verify/graph/EulerTour.test.csx
  _isVerificationFailed: false
  _pathExtension: csx
  _verificationStatusIcon: ':heavy_check_mark:'
  attributes: {}
  bundledCode: "Traceback (most recent call last):\n  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/documentation/build.py\"\
    , line 71, in _render_source_code_stat\n    bundled_code = language.bundle(stat.path,\
    \ basedir=basedir, options={'include_paths': [basedir]}).decode()\n          \
    \         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n\
    \  File \"/home/runner/.local/lib/python3.12/site-packages/onlinejudge_verify/languages/csharpscript.py\"\
    , line 113, in bundle\n    raise NotImplementedError\nNotImplementedError\n"
  code: "#load \"Graph.csx\"\n\npublic partial class Graph<T>\n{\n    /// <summary>\n\
    \    /// Constructs the euler tour sequences from the tree. Time complexity is\
    \ O(nlogn).\n    /// </summary>\n    public EulerTour<V> ConstructEulerTour<V>(int\
    \ root = 0, V[] vertexWeights = null) where V : INumber<V>\n    {\n        if\
    \ (_vertexCount - 1 != _edges.Count)\n        {\n            throw new InvalidOperationException(\"\
    Not a tree graph.\");\n        }\n\n        if (vertexWeights is not null && vertexWeights.Length\
    \ != _vertexCount)\n        {\n            throw new InvalidOperationException(\"\
    Invalid vertex weights.\");\n        }\n\n        if (vertexWeights is null)\n\
    \        {\n            vertexWeights = new V[_vertexCount];\n            Array.Fill(vertexWeights,\
    \ V.Zero);\n        }\n\n        List<int> visit = new();\n        List<T> edge\
    \ = new();\n        List<T> edgeMinus = new();\n        List<V> vertex = new();\n\
    \        List<V> vertexMinus = new();\n        List<int> depths = new();\n   \
    \     int[] timeIn = new int[_vertexCount];\n        int[] timeOut = new int[_vertexCount];\n\
    \n        void dfs(int v, int prev, T weight, int depth)\n        {\n        \
    \    visit.Add(v);\n            vertex.Add(vertexWeights[v]);\n            edge.Add(weight);\n\
    \            vertexMinus.Add(vertexWeights[v]);\n            edgeMinus.Add(weight);\n\
    \            depths.Add(depth);\n            timeIn[v] = visit.Count - 1;\n\n\
    \            for (int i = 0; i < _adjList[v].Count; i++)\n            {\n    \
    \            if (_adjList[v][i].To == prev) continue;\n\n                int next\
    \ = _adjList[v][i].To;\n                dfs(next, v, _adjList[v][i].Weight, depth\
    \ + 1);\n\n                visit.Add(v);\n                vertex.Add(V.Zero);\n\
    \                edge.Add(T.Zero);\n                vertexMinus.Add(-vertexWeights[next]);\n\
    \                edgeMinus.Add(-_adjList[v][i].Weight);\n                depths.Add(depth);\n\
    \            }\n\n            timeOut[v] = visit.Count - 1;\n        }\n\n   \
    \     dfs(root, -1, T.Zero, 0);\n\n        return new(visit.ToArray(), vertex.ToArray(),\
    \ vertexMinus.ToArray(), edge.ToArray(), edgeMinus.ToArray(), depths.ToArray(),\
    \ timeIn, timeOut, vertexWeights);\n    }\n\n    public sealed class EulerTour<V>\
    \ where V : INumber<V>\n    {\n        /// <summary>\n        /// Sparse table,\
    \ which can compute interval products of associative and idempotent operations.\n\
    \        /// </summary>\n        public sealed class ArgminRMQ\n        {\n  \
    \          private int[][] _table;\n            private int[][] _argmin;\n   \
    \         private int[] _lookup;\n            private int _length;\n\n       \
    \     /// <summary>\n            /// Build the sparse table by the array. Time\
    \ complexity is O(nlogn).\n            /// </summary>\n            public ArgminRMQ(int[]\
    \ array)\n            {\n                _length = array.Length;\n           \
    \     int exp = 0;\n                while (1 << (exp + 1) <= array.Length) exp++;\n\
    \                _table = new int[exp + 1][];\n                _argmin = new int[exp\
    \ + 1][];\n                for (int i = 0; i <= exp; i++)\n                {\n\
    \                    _table[i] = new int[_length];\n                    _argmin[i]\
    \ = new int[_length];\n                }\n\n                for (int i = 0; i\
    \ <= exp; i++)\n                {\n                    int width = 1 << i;\n \
    \                   for (int j = 0; j <= _length - width; j++)\n             \
    \       {\n                        if (width == 1)\n                        {\n\
    \                            _table[i][j] = array[j];\n                      \
    \      _argmin[i][j] = j;\n                        }\n                       \
    \ else\n                        {\n                            _table[i][j] =\
    \ int.Min(_table[i - 1][j], _table[i - 1][j + (1 << (i - 1))]);\n            \
    \                if (_table[i - 1][j] == _table[i][j]) _argmin[i][j] = _argmin[i\
    \ - 1][j];\n                            else _argmin[i][j] = _argmin[i - 1][j\
    \ + (1 << (i - 1))];\n                        }\n                    }\n     \
    \           }\n\n                _lookup = new int[_length + 1];\n           \
    \     for (int i = 2; i <= _length; i++)\n                {\n                \
    \    _lookup[i] = _lookup[i / 2] + 1;\n                }\n            }\n\n  \
    \          /// <summary>\n            /// Gets the product of the interval [l,\
    \ r). Time complexity is O(1).\n            /// </summary>\n            public\
    \ int Fold(int l, int r, out int argmin)\n            {\n                if (l\
    \ >= r)\n                {\n                    argmin = -1;\n               \
    \     return int.MaxValue;\n                }\n                int len = r - l;\n\
    \                int x = _lookup[len];\n                int min = int.Min(_table[x][l],\
    \ _table[x][r - (1 << x)]);\n                if (_table[x][l] == min) argmin =\
    \ _argmin[x][l];\n                else argmin = _argmin[x][r - (1 << x)];\n  \
    \              return min;\n            }\n        }\n\n        private int[]\
    \ _visit;\n        private V[] _vertex;\n        private V[] _vertexMinus;\n \
    \       private V[] _vertexWeights;\n        private T[] _edge;\n        private\
    \ T[] _edgeMinus;\n        private int[] _depth;\n        private int[] _in;\n\
    \        private int[] _out;\n\n        private ArgminRMQ _depthRMQ;\n       \
    \ private V[] _vertexPS;\n        private V[] _vertexMinusPS;\n        private\
    \ T[] _edgePS;\n        private T[] _edgeMinusPS;\n\n        public EulerTour(int[]\
    \ visit, V[] vertex, V[] vertexMinus, T[] edge, T[] edgeMinus, int[] depth, int[]\
    \ @in, int[] @out, V[] vertexWeights)\n        {\n            _visit = visit;\n\
    \            _vertex = vertex;\n            _vertexMinus = vertexMinus;\n    \
    \        _vertexWeights = vertexWeights;\n            _edge = edge;\n        \
    \    _edgeMinus = edgeMinus;\n            _depth = depth;\n            _in = @in;\n\
    \            _out = @out;\n\n            _depthRMQ = new(_depth);\n          \
    \  _vertexPS = new V[_vertex.Length + 1];\n            _vertexMinusPS = new V[_vertex.Length\
    \ + 1];\n            _edgePS = new T[_edge.Length + 1];\n            _edgeMinusPS\
    \ = new T[_edge.Length + 1];\n\n            _vertexPS[0] = V.Zero;\n         \
    \   _vertexMinusPS[0] = V.Zero;\n            _edgePS[0] = T.Zero;\n          \
    \  _edgeMinusPS[0] = T.Zero;\n            for (int i = 1; i <= _vertex.Length;\
    \ i++)\n            {\n                _vertexPS[i] = _vertexPS[i - 1] + _vertex[i\
    \ - 1];\n                _vertexMinusPS[i] = _vertexMinusPS[i - 1] + _vertexMinus[i\
    \ - 1];\n            }\n\n            for (int i = 1; i <= _edge.Length; i++)\n\
    \            {\n                _edgePS[i] = _edgePS[i - 1] + _edge[i - 1];\n\
    \                _edgeMinusPS[i] = _edgeMinusPS[i - 1] + _edgeMinus[i - 1];\n\
    \            }\n        }\n\n        /// <summary>\n        /// Gets the LCA of\
    \ a and b. Time complexity is O(1).\n        /// </summary>\n        public int\
    \ Lca(int a, int b)\n        {\n            if (a == b) return a;\n\n        \
    \    int l = int.Min(_in[a], _in[b]);\n            int r = int.Max(_out[a], _out[b])\
    \ + 1;\n\n            _depthRMQ.Fold(l, r, out int index);\n            return\
    \ _visit[index];\n        }\n\n        /// <summary>\n        /// Gets the sum\
    \ of weights of vertices in the subtree.\n        /// </summary>\n        public\
    \ V SubtreeVertexWeightSum(int root)\n        {\n            int l = _in[root];\n\
    \            int r = _out[root] + 1;\n\n            return _vertexPS[r] - _vertexPS[l];\n\
    \        }\n\n        /// <summary>\n        /// Gets the sum of weights of edges\
    \ in the subtree.\n        /// </summary>\n        public T SubtreeEdgeWeightSum(int\
    \ root)\n        {\n            int l = _in[root] + 1;\n            int r = _out[root]\
    \ + 1;\n\n            return _edgePS[r] - _edgePS[l];\n        }\n\n        ///\
    \ <summary>\n        /// Gets the sum of weights of vertices contained in the\
    \ path from the root to the vertex v.\n        /// </summary>\n        public\
    \ V RootPathVertexWeightSum(int v)\n        {\n            return _vertexMinusPS[_in[v]\
    \ + 1];\n        }\n\n        /// <summary>\n        /// Gets the sum of weights\
    \ of edges contained in the path from the root to the vertex v.\n        /// </summary>\n\
    \        public T RootPathEdgeWeightSum(int v)\n        {\n            return\
    \ _edgeMinusPS[_in[v] + 1] - _edgeMinusPS[1];\n        }\n\n        /// <summary>\n\
    \        /// Gets the sum of weights of vetices contained in the path between\
    \ u and v.\n        /// </summary>\n        public V PathVertexWeightSum(int u,\
    \ int v)\n        {\n            int lca = Lca(u, v);\n\n            return RootPathVertexWeightSum(u)\
    \ + RootPathVertexWeightSum(v) - RootPathVertexWeightSum(lca) - RootPathVertexWeightSum(lca)\
    \ + _vertexWeights[lca];\n        }\n\n        /// <summary>\n        /// Gets\
    \ the sum of weights of edges contained in the path between u and v.\n       \
    \ /// </summary>\n        public T PathEdgeWeightSum(int u, int v)\n        {\n\
    \            int lca = Lca(u, v);\n\n            return RootPathEdgeWeightSum(u)\
    \ + RootPathEdgeWeightSum(v) - RootPathEdgeWeightSum(lca) - RootPathEdgeWeightSum(lca);\n\
    \        }\n    }\n}"
  dependsOn:
  - library/graph/GraphBase.csx
  - library/graph/Graph.csx
  isVerificationFile: false
  path: library/graph/EulerTour.csx
  requiredBy: []
  timestamp: '2026-05-31 11:56:47+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/graph/EulerTour.test.csx
documentation_of: library/graph/EulerTour.csx
layout: document
title: "Euler Tour(\u30AA\u30A4\u30E9\u30FC\u30C4\u30A2\u30FC)"
---

#### 説明

木に対してオイラーツアーをすると, 以下のものが計算できる.

- $2$ 頂点 $u, v$ のLCA(最小共通祖先)を求める ($O(1)$)
- 頂点 $v$ を根とする部分木内の重みの和を求める ($O(1)$)
- $2$ 頂点 $u, v$ 間のパスの重みの和を求める ($O(1)$)

根からDFSの訪問順に, 頂点番号, 深さ, 重みなどを列として記録する. 構築する際の計算量は頂点数を $V$ として $O(V\log V)$.

#### 注意点
- 更新クエリなども処理したいときは HL分解 を使う

#### 関数
- `ConstructEulerTour(root, vertexWeights)`: $\mathrm{root}$ を根, $\mathrm{vertexWeights}$ を頂点重みとしてオイラーツアーを構築する

#### 関数(EulerTour)
- `Lca(a, b)`: $a$ と $b$ の最小共通祖先を返す
- `SubtreeVertexWeightSum(root)`: $root$ を根とする部分木の頂点重みの総和を求める
- `SubtreeEdgeWeightSum(root)`: $root$ を根とする部分木の辺重みの総和を求める
- `RootPathVertexWeightSum(v)`: 根から $v$ までのパスに含まれる頂点の重みの総和を求める
- `RootPathEdgeWeightSum(v)`: 根から $v$ までのパスに含まれる辺の重みの総和を求める
- `PathVertexWeightSum(u, v)`: $u$ と $v$ を結ぶパスに含まれる頂点の重みの総和を求める
- `PathEdgeWeightSum(u, v)`: $u$ と $v$ を結ぶパスに含まれる辺の重みの総和を求める