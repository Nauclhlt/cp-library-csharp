---
title: Euler Tour(オイラーツアー)
documentation_of: //library/graph/EulerTour.csx
---

#### 説明

木に対してオイラーツアーをすると, 以下のものが計算できる.

- $2$ 頂点 $u, v$ のLCA(最小共通祖先)を求める ($O(1)$)
- 頂点 $v$ を根とする部分木内の重みの和を求める ($O(1)$)
- $2$ 頂点 $u, v$ 間のパスの重みの和を求める ($O(1)$)

根からDFSの訪問順に, 頂点番号, 深さ, 重みなどを列として記録する. 構築する際の計算量は頂点数を $V$ として $O(V\log V)$.

#### 注意点
- 更新クエリなども処理したいときは HL分解 を使う

#### 関数
- `ConstructEulerTour(root, vertexWeights)`: $\mathrm{root}$ を根, $\mathrm{vertexWeights}$ を頂点重みとしてオイラーツアーを構築する

#### 関数(EulerTour)
- `Lca(a, b)`: $a$ と $b$ の最小共通祖先を返す
- `SubtreeVertexWeightSum(root)`: $root$ を根とする部分木の頂点重みの総和を求める
- `SubtreeEdgeWeightSum(root)`: $root$ を根とする部分木の辺重みの総和を求める
- `RootPathVertexWeightSum(v)`: 根から $v$ までのパスに含まれる頂点の重みの総和を求める
- `RootPathEdgeWeightSum(v)`: 根から $v$ までのパスに含まれる辺の重みの総和を求める
- `PathVertexWeightSum(u, v)`: $u$ と $v$ を結ぶパスに含まれる頂点の重みの総和を求める
- `PathEdgeWeightSum(u, v)`: $u$ と $v$ を結ぶパスに含まれる辺の重みの総和を求める