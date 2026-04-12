---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/data-structure/Set.test.csx
    title: verify/data-structure/Set.test.csx
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
  code: "/// <summary>\n/// Set. (implemented using treap)\n/// </summary>\npublic\
    \ sealed class Set<T> where T : IComparable<T>\n{\n    private sealed class Node\n\
    \    {\n        public T Key;\n        public double Priority;\n        public\
    \ Node Left;\n        public Node Right;\n        public int Size;\n\n       \
    \ public Node(T key, double priority)\n        {\n            Key = key;\n   \
    \         Priority = priority;\n            Left = null;\n            Right =\
    \ null;\n            Size = 1;\n        }\n\n        [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \        public int LeftSize() => Left is not null ? Left.Size : 0;\n        [MethodImpl(MethodImplOptions.AggressiveInlining)]\n\
    \        public int RightSize() => Right is not null ? Right.Size : 0;\n    }\n\
    \n    private Node _rootNode = null;\n    private Random _random;\n\n    public\
    \ int Count => _rootNode is not null ? _rootNode.Size : 0;\n\n    /// <summary>\n\
    \    /// Initializes set. Time complexity is O(1).\n    /// </summary>\n    public\
    \ Set()\n    {\n        _rootNode = null;\n        _random = new();\n    }\n\n\
    \    /// <summary>\n    /// Adds the specified value. Time complexity is average\
    \ O(logn).\n    /// </summary>\n    public void Add(T value)\n    {\n        _rootNode\
    \ = AddRecursive(_rootNode, new Node(value, _random.NextDouble()));\n    }\n\n\
    \    /// <summary>\n    /// Adds the specified value. Time complexity is average\
    \ O(logn).\n    /// </summary>\n    public void Remove(T value)\n    {\n     \
    \   _rootNode = RemoveRecursive(_rootNode, value);\n    }\n\n    private Node\
    \ RemoveRecursive(Node current, T key)\n    {\n        if (current is null)\n\
    \        {\n            return null;\n        }\n\n        int comp = key.CompareTo(current.Key);\n\
    \        if (comp == -1)\n        {\n            current.Left = RemoveRecursive(current.Left,\
    \ key);\n        }\n        else if (comp == 1)\n        {\n            current.Right\
    \ = RemoveRecursive(current.Right, key);\n        }\n        else\n        {\n\
    \            if (current.Left is null) return current.Right;\n            if (current.Right\
    \ is null) return current.Left;\n\n            if (current.Left.Priority > current.Right.Priority)\n\
    \            {\n                current = RotateRight(current);\n            \
    \    current.Right = RemoveRecursive(current.Right, key);\n            }\n   \
    \         else\n            {\n                current = RotateLeft(current);\n\
    \                current.Left = RemoveRecursive(current.Left, key);\n        \
    \    }\n        }\n\n        Update(current);\n\n        return current;\n   \
    \ }\n\n    private Node AddRecursive(Node current, Node node)\n    {\n       \
    \ if (current is null)\n        {\n            return node;\n        }\n\n   \
    \     if (node.Key.CompareTo(current.Key) == -1)\n        {\n            current.Left\
    \ = AddRecursive(current.Left, node);\n\n            if (current.Left.Priority\
    \ > current.Priority)\n            {\n                current = RotateRight(current);\n\
    \            }\n        }\n        else\n        {\n            current.Right\
    \ = AddRecursive(current.Right, node);\n\n            if (current.Right.Priority\
    \ > current.Priority)\n            {\n                current = RotateLeft(current);\n\
    \            }\n        }\n\n        Update(current);\n\n        return current;\n\
    \    }\n\n    private Node GetMaxNode(Node node)\n    {\n        Node cur = node;\n\
    \        while (cur.Right is not null) cur = cur.Right;\n\n        return cur;\n\
    \    }\n\n    private Node GetMinNode(Node node)\n    {\n        Node cur = node;\n\
    \        while (cur.Left is not null) cur = cur.Left;\n\n        return cur;\n\
    \    }\n\n    private Node RotateLeft(Node node)\n    {\n        Node right =\
    \ node.Right;\n        node.Right = right.Left;\n        right.Left = node;\n\n\
    \        Update(right.Left);\n        Update(right.Right);\n        Update(right);\n\
    \n        return right;\n    }\n\n    private Node RotateRight(Node node)\n  \
    \  {\n        Node left = node.Left;\n        node.Left = left.Right;\n      \
    \  left.Right = node;\n\n        Update(left.Left);\n        Update(left.Right);\n\
    \        Update(left);\n\n\n        return left;\n    }\n\n    [MethodImpl(256)]\n\
    \    private void Update(Node node)\n    {\n        if (node is null) return;\n\
    \n        int left = node.LeftSize();\n        int right = node.RightSize();\n\
    \n        node.Size = left + right + 1;\n    }\n\n    public void PrintTree()\n\
    \    {\n        int calls = 0;\n        void PrintNode(Node node, int depth)\n\
    \        {\n            if (node is null) return;\n            calls++;\n    \
    \        PrintNode(node.Right, depth + 1);\n            Console.WriteLine(new\
    \ string('\\t', depth) + node.Key + $\"({node.Size})\");\n            PrintNode(node.Left,\
    \ depth + 1);\n        }\n\n        PrintNode(_rootNode, 0);\n    }\n\n    ///\
    \ <summary>\n    /// Returns the maximum value contained in the set. Time complexity\
    \ is average O(logn).\n    /// </summary>\n    public T Max\n    {\n        get\n\
    \        {\n            if (_rootNode is null)\n            {\n              \
    \  throw new InvalidOperationException(\"No item in the set.\");\n           \
    \ }\n            else\n            {\n                return GetMaxNode(_rootNode).Key;\n\
    \            }\n        }\n    }\n\n    /// <summary>\n    /// Returns the minimum\
    \ value contained in the set. Time complexity is average O(logn).\n    /// </summary>\n\
    \    public T Min\n    {\n        get\n        {\n            if (_rootNode is\
    \ null)\n            {\n                throw new InvalidOperationException(\"\
    No item in the set.\");\n            }\n            else\n            {\n    \
    \            return GetMinNode(_rootNode).Key;\n            }\n        }\n   \
    \ }\n\n    /// <summary>\n    /// Determines if the value is contained in the\
    \ set. Time complexity is average O(logn).\n    /// </summary>\n    public bool\
    \ Contains(T value)\n    {\n        Node current = _rootNode;\n\n        while\
    \ (current is not null)\n        {\n            if (current.Key.CompareTo(value)\
    \ == 0) return true;\n\n            if (value.CompareTo(current.Key) == -1) current\
    \ = current.Left;\n            else current = current.Right;\n        }\n\n  \
    \      return false;\n    }\n\n    /// <summary>\n    /// Returns the index-th\
    \ element. Time complexity is average O(logn).\n    /// </summary>\n    public\
    \ T GetByIndex(int index)\n    {\n        if (_rootNode is null)\n        {\n\
    \            throw new IndexOutOfRangeException();\n        }\n        if (index\
    \ < 0 || index >= Count)\n        {\n            throw new IndexOutOfRangeException();\n\
    \        }\n\n        Node current = _rootNode;\n        int left = 0;\n     \
    \   while (current is not null)\n        {\n            int center = left + current.LeftSize();\n\
    \            if (center == index)\n            {\n                return current.Key;\n\
    \            }\n            else if (center < index)\n            {\n        \
    \        left += current.LeftSize() + 1;\n                current = current.Right;\n\
    \            }\n            else\n            {\n                current = current.Left;\n\
    \            }\n        }\n\n        return default;\n    }\n\n    /// <summary>\n\
    \    /// Remove the index-th element. Time complexity is average O(logn).\n  \
    \  /// </summary>\n    public void RemoveByIndex(int index)\n    {\n        if\
    \ (_rootNode is null) return;\n        if (index < 0 || index >= Count)\n    \
    \    {\n            throw new IndexOutOfRangeException();\n        }\n\n     \
    \   _rootNode = RemoveByIndexRecursive(_rootNode, index);\n    }\n\n    private\
    \ Node RemoveByIndexRecursive(Node current, int index)\n    {\n        if (current\
    \ is null)\n        {\n            return null;\n        }\n\n        int left\
    \ = current.LeftSize();\n\n        if (index < left)\n        {\n            current.Left\
    \ = RemoveByIndexRecursive(current.Left, index);\n        }\n        else if (index\
    \ > left)\n        {\n            current.Right = RemoveByIndexRecursive(current.Right,\
    \ index - left - 1);\n        }\n        else\n        {\n            if (current.Left\
    \ is null) return current.Right;\n            if (current.Right is null) return\
    \ current.Left;\n\n            if (current.Left.Priority > current.Right.Priority)\n\
    \            {\n                current = RotateRight(current);\n            \
    \    current.Right = RemoveByIndexRecursive(current.Right, index - current.LeftSize()\
    \ - 1);\n            }\n            else\n            {\n                current\
    \ = RotateLeft(current);\n                current.Left = RemoveByIndexRecursive(current.Left,\
    \ index);\n            }\n        }\n\n        Update(current);\n\n        return\
    \ current;\n    }\n\n    /// <summary>\n    /// If the specified value is contained\
    \ in the set, returns the index, otherwise, returns -1. Time complexity is average\
    \ O(logn).\n    /// </summary>\n    public int IndexOf(T value)\n    {\n     \
    \   int index = _rootNode.LeftSize();\n        Node current = _rootNode;\n\n \
    \       while (true)\n        {\n            int c = value.CompareTo(current.Key);\n\
    \            if (c == -1)\n            {\n                if (current.Left is\
    \ null) return -1;\n                else\n                {\n                \
    \    current = current.Left;\n                    index -= current.RightSize()\
    \ + 1;\n                }\n            }\n            else if (c == 0) return\
    \ index;\n            else\n            {\n                if (current.Right is\
    \ null) return -1;\n                else\n                {\n                \
    \    current = current.Right;\n                    index += current.LeftSize()\
    \ + 1;\n                }\n            }\n        }\n    }\n\n    /// <summary>\n\
    \    /// Returns the minimum value x contained in the set such that x >= value.\
    \ If such x is not found in the set, returns fallback. Time complexity is average\
    \ O(logn).\n    /// </summary>\n    public T LowerBoundValue(T value, T fallback)\n\
    \    {\n        if (_rootNode is null) return fallback;\n\n        int res = _rootNode.Size;\n\
    \        Node current = _rootNode;\n        T lowerbound = default;\n        int\
    \ index = _rootNode.LeftSize();\n\n        while (true)\n        {\n         \
    \   int cmp = value.CompareTo(current.Key);\n            if (cmp <= 0)\n     \
    \       {\n                res = int.Min(res, index);\n                lowerbound\
    \ = current.Key;\n                if (current.Left is null) break;\n         \
    \       index -= current.Left.RightSize() + 1;\n                current = current.Left;\n\
    \            }\n            else\n            {\n                if (current.Right\
    \ is null) break;\n                index += current.Right.LeftSize() + 1;\n  \
    \              current = current.Right;\n            }\n        }\n\n        return\
    \ res < Count ? lowerbound : fallback;\n    }\n\n    /// <summary>\n    /// Returns\
    \ i such that x-th element is greater than or equals to value for all x >= i.\
    \ Time complexity is average O(logn).\n    /// </summary>\n    public int LowerBound(T\
    \ value)\n    {\n        if (_rootNode is null) return 0;\n\n        int res =\
    \ _rootNode.Size;\n        Node current = _rootNode;\n        int index = _rootNode.LeftSize();\n\
    \n        while (true)\n        {\n            int cmp = value.CompareTo(current.Key);\n\
    \            if (cmp <= 0)\n            {\n                res = int.Min(res,\
    \ index);\n                if (current.Left is null) break;\n                index\
    \ -= current.Left.RightSize() + 1;\n                current = current.Left;\n\
    \            }\n            else\n            {\n                if (current.Right\
    \ is null) break;\n                index += current.Right.LeftSize() + 1;\n  \
    \              current = current.Right;\n            }\n        }\n\n        return\
    \ res;\n    }\n\n    /// <summary>\n    /// Gets the list of all elements contained\
    \ in the set in ascending order. Time complexity is O(n).\n    /// </summary>\n\
    \    public List<T> OrderAscending()\n    {\n        if (_rootNode is null) return\
    \ new List<T>();\n\n        List<T> res = new(_rootNode.Size);\n\n        void\
    \ extract(Node node)\n        {\n            if (node is null) return;\n     \
    \       extract(node.Left);\n            res.Add(node.Key);\n            extract(node.Right);\n\
    \        }\n\n        extract(_rootNode);\n\n        return res;\n    }\n\n  \
    \  /// <summary>\n    /// Gets the list of all elements contained in the set in\
    \ descending order. Time complexity is O(n).\n    /// </summary>\n    public List<T>\
    \ OrderDescending()\n    {\n        if (_rootNode is null) return new List<T>();\n\
    \n        List<T> res = new(_rootNode.Size);\n\n        void extract(Node node)\n\
    \        {\n            if (node is null) return;\n            extract(node.Right);\n\
    \            res.Add(node.Key);\n            extract(node.Left);\n        }\n\n\
    \        extract(_rootNode);\n\n        return res;\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/data-structure/Set.csx
  requiredBy: []
  timestamp: '2026-04-12 11:42:44+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/data-structure/Set.test.csx
documentation_of: library/data-structure/Set.csx
layout: document
title: Set
---

#### 説明

平衡二分探索木を用いたset. Treapで実装しているので各操作の**平均**時間計算量が $O(\log n)$ になる. AVL木などと違って最悪計算量は $O(n)$ なんだって.

平衡二分探索木で各ノードに自身を根とする部分木のサイズを持たせることで, 二分探索でインデックスを扱えるようになる. 特に, $k$ 番目に小さい値の取得といった操作が $O(\log n)$ で実現できる.

#### 注意点
- デフォルトでmultiset(重複許容)になっている. 重複を許さない場合は.NETの `SortedSet` を使うか, `Contains` を使ってガードする
- 重複がなく, また基本的な操作のみ使う場合は `SortedSet`, あるいは `HashSet` を使う方が良い

#### 関数
- `Add(value)`: $value$ を追加する
- `Remove(value)`: $value$ があれば削除する
- `Max{get;}`: 最大値を取得する
- `Min{get;}`: 最小値を取得する
- `Contains(value)`: $value$ が含まれているかどうかを返す
- `GetByIndex(index)`: 要素をすべて昇順に並べたときに $index$ 番目になる値を返す
- `RemoveByIndex(index)`: 要素をすべて昇順に並べたときに $index$ 番目になる値を削除する
- `IndexOf(value)`: 要素をすべて昇順に並べたときに $value$ が何番目かを返す. 存在しなければ `-1` を返す
- `LowerBoundValue(value, fallback)`: 含まれている要素の中で $value$ 以上で最小のものを返す. 存在しなければ $fallback$ を返す
- `LowerBound(value)` 含まれている要素の中で $value$ 以上で最小のものが, 小さいほうから何番目の値かを返す
- `OrderAscending()`: 含まれている要素をすべて昇順に並べたリストを返す
- `OrderDescending()`: 含まれている要素をすべて降順に並べたリストを返す