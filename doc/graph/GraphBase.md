---
title: Graph Base
documentation_of: //library/graph/GraphBase.csx
---

#### 説明

有向, 無向グラフの基底クラス. 共通のデータなどを持つ.

ダイクストラ法, ベルマンフォード法, ワーシャルフロイド法など有向, 無向にかかわらず実装が共通なものはこのクラスに対して定義される.

#### 注意点
- とくになし

#### 関数
- `abstract AddEdge(a, b, weight)`: 辺 $(a, b, w)$ を追加する