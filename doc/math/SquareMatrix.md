---
title: Square Matrix
documentation_of: //library/math/SquareMatrix.csx
---

#### 説明

正方行列を扱う.

#### 注意点
- $T$ はいい感じに演算子系のインターフェースを実装してないとダメ

#### 関数
- `Power(e)`: $e$ 乗を求める
- `Transpose()`: 転置行列を返す
- `static Zero(size)`: サイズが $size$ の零行列を返す
- `static Identity(size)`: サイズが $size$ の単位行列を返す