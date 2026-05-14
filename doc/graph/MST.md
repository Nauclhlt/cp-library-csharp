---
title: Minimum/Maximum Spanning Tree(クラスカル法)
documentation_of: //library/graph/MST.csx
---

#### 説明

クラスカル(Kruskal)法を用いて, 最大/最小全域木に含まれる辺の重みの総和を求める.

辺を重みの順にソートして連結成分数が減るなら採用するという貪欲法で, グラフの頂点数, 辺数を $V, E$ として $O(V\alpha(V)+E\log E)$ で求まる.

#### 注意点
- とくになし

#### 関数
- `MaxSpanningTreeWeight()`: 最大全域木に含まれる辺の重みの総和を求める
- `MinSpanningTreeWeight()`: 最小全域木に含まれる辺の重みの総和を求める