---
title: Deque
documentation_of: //library/data-structure/Deque.csx
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