---
title: Sparse Table 2D
documentation_of: //library/data-structure/SparseTable.csx
---

#### 説明

Sparse Tableを $2$ 次元に拡張してもクエリあたり $O(1)$ で積が求められる.

イメージとしては, 高さ方向(あるいは幅方向)に対して通常のSparse Tableのように $2$ 冪長区間を考え, それぞれに対して幅方向のSparse Tableを持てばよい.

前計算は高さを $H$, 幅を $W$ として, $O(HW\log H\log W)$ 時間となる.

#### 注意点
- 単位元は与えられた区間が空だったときに便宜的に返す用なので, 別に設定しなくても動く

#### 関数
- `Fold(x1, y1, x2, y2)`: $(x1, y1)$ を左上, $(x2, y2)$ を右下(exclusive)とする矩形領域の積を求める