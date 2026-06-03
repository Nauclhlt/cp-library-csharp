---
title: Persistent Segment Tree(完全永続セグメント木)
documentation_of: //library/data-structure/PersistentSegmentTree.csx
---

#### 説明

1次元のセグメント木を完全永続にしたもの. 通常のセグメント木で, 一点更新の際の計算量は $O(\log n)$ だが, このとき値が更新されるノードの数も $O(\log n)$ 個であるため, 更新クエリのたびに新たに $O(\log n)$ 個のノードをくっつけて木を作ればよい. 更新されない部分については, そのまま接続するようにすればよい.

これによって, 更新クエリ数を $Q$ として, $O((N+Q)\log N)$ 空間で永続になる.

ライブラリの設計上は, 整数で時刻を管理するようになっている.

#### 注意点
- 長さを $2$ べきに揃えるような仕様はない
- 再帰での実装
- その他通常のセグメント木の注意点も参照

#### 関数
- `this[time, index]`: 時刻 $time$ での $index$ 番目の要素を取得する
- `Build(array)`: $array$ で再構築したセグメント木を返す
- `Fill(value)`: 全要素を $value$ で埋めて再構築したセグメント木を返す
- `Update(time, index, value)`: 時刻 $time$ での $index$ 番目の要素を $value$ で更新したセグメント木を返す
- `Fold(time, l, r)`: 時刻 $time$ でのセグメント木における区間 $[l, r)$ の積を取得する