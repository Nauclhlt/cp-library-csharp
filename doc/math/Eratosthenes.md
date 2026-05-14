---
title: Sieve of Eratosthenes
documentation_of: //library/math/Eratosthenes.csx
---

#### 説明

エラトステネスの篩のアルゴリズムを用いると, $n$ 以下の各正整数 $k$ に対して, $k$ が素数かどうかの情報だけでなく, $k$ を割り切る最小の素数, $\mu (k)$ も $O(n\log\log n)$ で求まる. (これ以外にも色々求めることができるが実装はしていない)

上述の前計算によって, 素因数分解が試し割り法による $O(\sqrt{n})$ より良い $O(\log n)$ の計算量で計算できたり, 約数を列挙できたりする. また, メビウス関数の値はメビウスの反転公式で活躍したりする.

#### 注意点
- 前計算でうまくやりたいときに使う. 数回なら素直に試し割りの方が速い.

#### 関数
- `PrimeFactorize(n)`: $n$ の素因数分解を求める
- `GetDivisors(n)`: $n$ の約数を列挙する
- `Mobius(n)`: $\mu (n)$ を求める. ここで $\mu$ はメビウス関数
- `MobiusTransform(n, f)`: $g$ を $f$ のメビウス変換, すなわち $\displaystyle f(N)=\sum_{d|N} g(d)$ を満たす関数とするとき, $g(n)$ を求める
- `MinFactor(n)`: $n$ を割り切る最小の素数を返す
- `IsPrime(n)`: $n$ が素数かどうかを返す