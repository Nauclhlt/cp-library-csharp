---
data:
  _extendedDependsOn: []
  _extendedRequiredBy: []
  _extendedVerifiedWith:
  - icon: ':heavy_check_mark:'
    path: verify/data-structure/Deque.test.csx
    title: verify/data-structure/Deque.test.csx
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
  code: "/// <summary>\n/// Double-Ended Queue implementation. Supports push/pop to\
    \ the front and back, and random access.\n/// </summary>\n/// <typeparam name=\"\
    T\">Value type.</typeparam>\npublic sealed class Deque<T> : IEnumerable<T>\n{\n\
    \    private const int DefaultCapacity = 32;\n\n    private T[] _buffer;\n   \
    \ private int _capacity;\n\n    private int _head;\n    private int _length;\n\
    \n    public int Count => _length;\n    public int Capacity => _capacity;\n  \
    \  \n    public T this[int index]\n    {\n        get {\n            if (index\
    \ < 0 || index >= _length) throw new IndexOutOfRangeException(\"The specified\
    \ index is out of the bounds of the deque.\");\n            return _buffer[_head\
    \ + index];\n        }\n        set {\n            if (index < 0 || index >= _length)\
    \ throw new IndexOutOfRangeException(\"The specified index is out of the bounds\
    \ of the deque.\");\n            _buffer[_head + index] = value;\n        }\n\
    \    }\n\n    public Deque() : this(DefaultCapacity)\n    {\n    }\n\n    public\
    \ Deque(int capacity)\n    {\n        if (capacity < 0)\n        {\n         \
    \   throw new ArgumentException(\"The capacity must be greater than 0.\");\n \
    \       }\n\n        _capacity = capacity;\n        _buffer = new T[_capacity];\n\
    \        _head = _capacity / 2;\n        _length = 0;\n    }\n\n    private void\
    \ ResizeBuffer()\n    {\n        _capacity <<= 1;\n\n        T[] newBuffer = new\
    \ T[_capacity];\n        int newHead = (_capacity - _length) / 2;\n        Array.Copy(_buffer,\
    \ _head, newBuffer, newHead, _length);\n\n        _head = newHead;\n        _buffer\
    \ = newBuffer;\n    }\n\n    /// <summary>\n    /// Push the value to the front.\
    \ Time complexity is amortized O(1).\n    /// </summary>\n    public void PushFront(T\
    \ value)\n    {\n        if (_head == 0)\n        {\n            ResizeBuffer();\n\
    \        }\n\n        _head--;\n        _buffer[_head] = value;\n        _length++;\n\
    \    }\n\n    /// <summary>\n    /// Push the value to the back. Time complexity\
    \ is amortized O(1).\n    /// </summary>\n    public void PushBack(T value)\n\
    \    {\n        if (_head + _length >= _capacity)\n        {\n            ResizeBuffer();\n\
    \        }\n\n        _buffer[_head + _length] = value;\n        _length++;\n\
    \    }\n\n    /// <summary>\n    /// Pop the front item. Time complexity is O(1).\n\
    \    /// </summary>\n    public T PopFront()\n    {\n        if (_length == 0)\n\
    \        {\n            throw new InvalidOperationException(\"Deque is empty.\"\
    );\n        }\n\n        T front = _buffer[_head];\n        _head++;\n       \
    \ _length--;\n\n        return front;\n    }\n\n    /// <summary>\n    /// Pop\
    \ the back value. Time complexity is O(1).\n    /// </summary>\n    public T PopBack()\n\
    \    {\n        if (_length == 0)\n        {\n            throw new InvalidOperationException(\"\
    Deque is empty.\");\n        }\n\n        T back = _buffer[_head + _length - 1];\n\
    \        _length--;\n\n        return back;\n    }\n\n    /// <summary>\n    ///\
    \ Returns the front value. Time complexity is O(1).\n    /// </summary>\n    public\
    \ T PeekFront()\n    {\n        if (_length == 0)\n        {\n            throw\
    \ new InvalidOperationException(\"Deque is empty.\");\n        }\n\n        return\
    \ _buffer[_head];\n    }\n\n    /// <summary>\n    /// Returns the back value.\
    \ Time complexity is O(1).\n    /// </summary>\n    public T PeekBack()\n    {\n\
    \        if (_length == 0)\n        {\n            throw new InvalidOperationException(\"\
    Deque is empty.\");\n        }\n\n        return _buffer[_head + _length - 1];\n\
    \    }\n\n    /// <summary>\n    /// If the deque is not empty, gets the front\
    \ value and returns true, otherwise, returns false. Time complexity is O(1).\n\
    \    /// </summary>\n    public bool TryPeekFront(out T value)\n    {\n      \
    \  if (_length == 0)\n        {\n            value = default;\n            return\
    \ false;\n        }\n\n        value = _buffer[_head];\n        return true;\n\
    \    }\n\n    /// <summary>\n    /// If the deque is not empty, gets the back\
    \ value and returns true, otherwise, returns false. Time complexity is O(1).\n\
    \    /// </summary>\n    public bool TryPeekBack(out T value)\n    {\n       \
    \ if (_length == 0)\n        {\n            value = default;\n            return\
    \ false;\n        }\n\n        value = _buffer[_head + _length - 1];\n       \
    \ return true;\n    }\n\n    /// <summary>\n    /// Gets the view of underlying\
    \ data. Time Complexity is O(1).\n    /// </summary>\n    public ReadOnlySpan<T>\
    \ AsSpan()\n    {\n        return _buffer.AsSpan(_head, _length);\n    }\n\n \
    \   public IEnumerator<T> GetEnumerator()\n    {\n        return (new ArraySegment<T>(_buffer,\
    \ _head, _length)).GetEnumerator();\n    }\n\n    IEnumerator IEnumerable.GetEnumerator()\n\
    \    {\n        return GetEnumerator();\n    }\n}"
  dependsOn: []
  isVerificationFile: false
  path: library/data-structure/Deque.csx
  requiredBy: []
  timestamp: '2026-03-30 02:29:29+09:00'
  verificationStatus: LIBRARY_ALL_AC
  verifiedWith:
  - verify/data-structure/Deque.test.csx
documentation_of: library/data-structure/Deque.csx
layout: document
title: Deque
---

#### 説明

Deque(Double-Ended Queue)というデータ構造. 発音は"デック"らしい.

リストと同様の発想で列を管理し, 先頭/末尾への追加/取り出しおよびランダムアクセスが高速にできる.

#### 注意点
- 実装の簡潔さを優先して, バッファは配列内の連続部分列を利用するようになっている. このため, メモリの効率や内部配列の再確保は効率の良い実装に比べて少し多くなる. (ほとんどの場合で特に大きな問題にはならない)
- あらかじめ挿入され得る要素数が分かっているなら, コンストラクタで $capacity$ を指定すると速い

#### 関数
- `this[index]`: $index$ 番目の要素を取得する
- `PushFront(value)`: $value$ を先頭に追加する
- `PushBack(value)`: $value$ を末尾に追加する
- `PopFront()`: 先頭の要素を取得し, 取り除く
- `PopBack()`: 末尾の要素を取得し, 取り除く
- `PeekFront()`: 先頭の要素を取得する
- `PeekBack()`: 末尾の要素を取得する
- `TryPeekFront(out value)`: 先頭の要素が存在するなら取得し, `true`を返す. 存在しなければ`false`を返す.
- `TryPeekBack(out value)`: 末尾の要素が存在するなら取得し, `true`を返す. 存在しなければ`false`を返す.
- `AsSpan()`: 内部配列のうち, 呼ばれた時点で利用している範囲のビューを返す. 変更後は正しい範囲でなくなるため, 再取得が必要.