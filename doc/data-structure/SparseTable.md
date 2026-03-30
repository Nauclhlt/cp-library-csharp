---
title: Sparse Table
documentation_of: //library/data-structure/SparseTable.csx
---

#### 説明

$X$ 上の演算 $f: X^2\rightarrow X$ が冪等性を満たすとは $x\in X$ に対して $f(x, x) = x$ を満たすことをいう.

$\max, \min, \gcd, \mathrm{AND, OR}$ などがこれを満たす演算の例. Sparse Tableが扱えるのはさらに結合律を満たすもの.

Sparse Tableは静的な列に対してこのような演算の区間積を $\Theta (n\log n)$ の前計算により各 $O(1)$ で処理する. 具体的には, 各 $i$ に対して $i$ を左端とする長さが2冪の区間の積を前計算しておけば, 任意の区間がそのような区間高々 $2$ つの和集合として表せるため, 冪等性からその和が求まるという仕組み.

#### 注意点
- 前計算がそこそこ重い代わりにクエリが軽いので, 変更の必要がなければセグメント木よりも速い場合がある

#### 関数
- `Fold(l, r)`: 区間 $[l, r)$ の積を求める