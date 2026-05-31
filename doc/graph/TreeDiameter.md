---
title: Tree Diameter(木の直径)
documentation_of: //library/graph/TreeDiameter.csx
---

#### 説明

木上の単純パスに含まれる辺の数の最大値をその木の直径という.

これは以下のアルゴリズムによって, 頂点数を $V$ として $O(V)$ 時間で求まる.

- 適当な頂点から最遠の頂点 $v$ をひとつ求める
- $v$ から最遠の頂点 $u$ をひとつ求める
- $u$ と $v$ を結ぶ単純パスに含まれる辺の数が直径である. すなわち, $u$ と $v$ は直径の両端の頂点である

#### 注意点
- とくになし

#### 関数
- `GetDiameter()`: 木の直径を求める
- `GetDiameterPair(out diameter)`: 木の直径の両端の頂点ペアをひとつ求める. そのさい $diameter$ に直径の値も格納される