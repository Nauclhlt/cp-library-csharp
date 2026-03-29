---
title: CPIO
documentation_of: //library/utility/CPIO.csx
---

#### 説明

競プロ用I/Oユーティリティクラス. staticコンストラクタで自動flushを無効にしている.

スペース区切り/改行区切りにかかわらず各関数で順に読んでくれる.

#### 注意点
- flushが必要な際は適宜`Console.Out.Flush()`すること

#### 関数
- `Int()`: int型で値を受け取る
- `Long()`: long型で値を受け取る
- `String()`: 文字列として値を受け取る
- `Short()`: short型で値を受け取る
- `Byte()`: byte型で値を受け取る
- `Char()`: 文字として値を受け取る
- `Double()`: double型で値を受け取る
- `Float()`: float型で値を受け取る
- `Read<T>()`: $T$ 型で値を受け取る
- `IntArray(n)`: 長さ $n$ のint型配列を受け取る
- `ZeroIndexedPermutation(n)`: 長さ $n$ 順列(配列)の入力を受け取る際, 全要素を $-1$ したものを返す
- `LongArray(n)`: 長さ $n$ のlong型配列を受け取る
- `DoubleArray(n)`: 長さ $n$ のdouble型配列を受け取る
- `StringArray(n)`: 長さ $n$ の文字列配列を受け取る
- `ReadArray<T>(n)`: 長さ $n$ の $T$ 型配列を受け取る
- `YesNo(t)`: $t$ の真偽に応じて `Yes` または `No` を出力する
- `Print<T>(array, delimiter)`: $T$ 型の列挙可能型 $array$ の要素を $delimiter$ 区切りで出力する
- `Print(value)`: $value$ を出力する
- `Print(value, digits)`: double型の $value$ を小数点以下 $digits$ まで(それ以下があればroundして)出力する