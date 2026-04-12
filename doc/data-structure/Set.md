---
title: Set
documentation_of: //library/data-structure/Set.csx
---

#### 説明

平衡二分探索木を用いたset. Treapで実装しているので各操作の**平均**時間計算量が $O(\log n)$ になる. AVL木などと違って最悪計算量は $O(n)$ なんだって.

平衡二分探索木で各ノードに自身を根とする部分木のサイズを持たせることで, 二分探索でインデックスを扱えるようになる. 特に, $k$ 番目に小さい値の取得といった操作が $O(\log n)$ で実現できる.

#### 注意点
- デフォルトでmultiset(重複許容)になっている. 重複を許さない場合は.NETの `SortedSet` を使うか, `Contains` を使ってガードする
- 重複がなく, また基本的な操作のみ使う場合は `SortedSet`, あるいは `HashSet` を使う方が良い

#### 関数
- `Add(value)`: $value$ を追加する
- `Remove(value)`: $value$ があれば削除する
- `Max{get;}`: 最大値を取得する
- `Min{get;}`: 最小値を取得する
- `Contains(value)`: $value$ が含まれているかどうかを返す
- `GetByIndex(index)`: 要素をすべて昇順に並べたときに $index$ 番目になる値を返す
- `RemoveByIndex(index)`: 要素をすべて昇順に並べたときに $index$ 番目になる値を削除する
- `IndexOf(value)`: 要素をすべて昇順に並べたときに $value$ が何番目かを返す. 存在しなければ `-1` を返す
- `LowerBoundValue(value, fallback)`: 含まれている要素の中で $value$ 以上で最小のものを返す. 存在しなければ $fallback$ を返す
- `LowerBound(value)` 含まれている要素の中で $value$ 以上で最小のものが, 小さいほうから何番目の値かを返す
- `OrderAscending()`: 含まれている要素をすべて昇順に並べたリストを返す
- `OrderDescending()`: 含まれている要素をすべて降順に並べたリストを返す