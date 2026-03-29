---
title: Segment Tree
documentation_of: //library/data-structure/SegmentTree.csx
---

##### 説明

1次元のセグメント木. セグメント木に乗せられる演算は(可換とは限らない)モノイドをなすもの. 1点更新と区間積取得を各 $O(\log n)$ で処理する.

ただし競プロにおいては構造体などに適当なフラグを持たせるなどすることで単位元は作れたりする.

##### 注意点
- 内部で利用する配列の長さを2冪に揃える実装をしている
- 1点加算などを手軽に書けるように, 更新する際の処理も受け取るようにしている
- クエリ, 1点更新共に非再帰での実装で $O(\log n)$
- 単位元はちゃんと設定しないと壊れる

##### 関数
- `this[index]`: $index$ 番目の要素を取得する
- `Build(array)`: $array$ で再構築する
- `UpdateByArray(array)`: $i$ 番目の要素 $a_i$ に対して $a_i\leftarrow update(a_i, array[i])$ となるように更新する
- `Fill(value)`: 全要素を $value$ で埋めて再構築する
- `Update(index, value)`: $index$ 番目の要素を $value$ で更新する
- `Fold(l, r)`: 区間 $[l, r)$ の積を取得する
- `AsSpan()`: 内部配列のビュー(read-only)を返す. 2冪に拡大する実装になっているため用意している.