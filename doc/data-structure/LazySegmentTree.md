---
title: Lazy Segment Tree
documentation_of: //library/data-structure/LazySegmentTree.csx
---

#### 説明

1次元の遅延評価セグメント木. モノイドの演算に加えてモノイドによる区間作用も対数時間で処理する.

#### 注意点
- 内部で利用する配列の長さを2冪に揃える実装をしている
- 中身は再帰の実装になっている
- 単位元はちゃんと設定しないと壊れる

#### 関数
- `this[index]`: $index$ 番目の要素を取得する. $O(\log n)$ なことに注意
- `Build(array)`: $array$ で再構築する
- `Fill(value)`: 全要素を $value$ で埋めて再構築する
- `Update(l, r, m)`: 区間 $[l, r)$ に対して $m$ を作用させる
- `Fold(l, r)`: 区間 $[l, r)$ の積を取得する
- `Access(index)`: `this[index]` と同じ
- `AsSpan()`: 内部配列のビュー(read-only)を返す. 2冪に拡大する実装になっているため用意している.