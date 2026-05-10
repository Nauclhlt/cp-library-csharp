---
title: CirnoArray
documentation_of: //library/data-structure/CirnoArray.csx
---

#### 説明

「あたいったらさいきょーね」な配列. 区間加算, 区間掛け算, 一点更新, 一点取得, 区間和取得, 区間最大値/最小値取得が簡単にできちゃう！　※中身はただの遅延セグ木.

#### 注意点
- $T$ は `INumber` を実装してね

#### 関数
- `this[index]`: $index$ 番目の要素を取得する. $O(\log n)$ なことに注意
- `Add(index, value)`: $index$ 番目の要素に $value$ を加算する
- `Add(l, r, value)`: 区間 $[l, r)$ に $value$ を加算する
- `Multiply(index, value)`: $index$ 番目の要素に $value$ を掛け算する
- `Multiply(l, r, value)`: 区間 $[l, r)$ に $value$ を掛け算する
- `Sum(l, r)`: 区間 $[l, r)$ の和を取得する
- `Max(l, r)`: 区間 $[l, r)$ の最大値を取得する
- `Min(l, r)`: 区間 $[l, r)$ の最小値を取得する