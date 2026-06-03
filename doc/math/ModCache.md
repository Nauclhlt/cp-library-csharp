---
title: Mod Cache (余り関連の前計算)
documentation_of: //library/math/ModCache.csx
---

#### 説明

$p$ を素数とする. $n=1, 2, \cdots, N$ に対して $\mathbb{F}_p$ 上で以下のものが $O(N)$ で前計算できる
- $n!$
- $(n!)^{-1}$
- $n^{-1}$

これに伴って, $1\leq n, r\leq N$ なる $n, r$ について以下のものが前計算の後, 各 $O(1)$ で取得できるようになる.

- $\displaystyle \binom{n}{r}={}_n\mathrm{C}_r$
- ${}_n\mathrm{P}_r$

#### 注意点
- $\displaystyle \binom{n}{r}$ について, $r$ が十分小さい場合は愚直計算で求めることができる. この場合 $n$ は巨大でもよい

#### 関数
- `Combination(n, r)`: 二項係数 $\displaystyle \binom{n}{r}$ を返す
- `Permutation(n, r)`: 順列の総数 ${}_n\mathrm{P}_r$ を返す
- `Factorial(n)`: $n!$ を返す
- `InverseFactorial(n)`: $(n!)^{-1}$ を返す
- `Inverse(n)`: $n^{-1}$ を返す