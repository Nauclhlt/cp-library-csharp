---
title: Fenwick Tree
documentation_of: //library/data-structure/FenwickTree.csx
---

#### 説明

フェニック木. BIT(Binary Indexed Tree)と呼ばれることもある.

一点加算・区間和クエリを各 $O(\log n)$ で処理できる. まあ, セグメント木よりちょっと定数倍が良い感じ. 本来可換群が乗るけど, `INumber`で実装しているので自由度が低い.

#### 注意点
- 内部的には1-indexedだが特に気にしなくて良い
- セグメント木と違って一点取得は $O(\log n)$

#### 関数
- `this[index]`: $index$ 番目の要素を取得する
- `Build(array)`: $array$ で再構築する. **セグメント木と違って** $O(n\log n)$ **の実装になっている**
- `Update(index, value)`: $index$ 番目の要素を $value$ で更新する
- `Add(index, value)`: $index$ 番目の要素に $value$ を足す
- `Sum(l, r)`: 区間 $[l, r)$ の和を取得する
- `PrefixSum(length)`: 長さ $length$ の接頭辞の和を取得する
- `AsSpan()`: 内部配列のビュー(read-only)を返す