---
title: Graph(無向グラフ)
documentation_of: //library/graph/Graph.csx
---

#### 説明

無向グラフを扱う.

#### 注意点
- とくになし

#### 関数
- `AddEdge(a, b, weight)`: $a$ と $b$ を結ぶ重み $weight$ の辺を追加する
- `CreateComplement()`: 補グラフを作成して返す
- `IsBipartite()`: 二部グラフかどうかを判定する