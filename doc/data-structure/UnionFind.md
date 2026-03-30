---
title: Union-Find
documentation_of: //library/data-structure/UnionFind.csx
---

#### 説明

Union-Findというデータ構造. またの名を素集合データ構造(disjoint-set-union, DSU).

無向グラフへの辺の追加, $2$ 頂点が同じ連結成分に属しているかの判定などが高速にできる. 具体的には $\alpha$ を逆アッカーマン関数として $O(\alpha(n))$ でできる操作がほとんど.

#### 注意点
- 経路圧縮+union-by-sizeで実装している

#### 関数
- `Leader(x)`: $x$ が属する連結成分の代表元を返す
- `Size(x)`: $x$ が属する連結成分の大きさを返す
- `Unite(x, y)`: $x, y$ が属する連結成分同士を併合する. ($x$ と $y$ の間に辺を張る)
- `Find(x)`: $x$ とが属する連結成分に含まれる頂点のリストを返す
- `FindAll()`: 代表元と, それが属する連結成分の組をすべて返す
- `Same(x, y)`: $x$ と $y$ が同じ連結成分に属しているかを判定する
- `Clear()`: 内容をクリアする. (辺をすべて削除する)