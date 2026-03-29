#load "../../library/data-structure/Deque.csx"
#load "../../library/utility/CPIO.csx"
// verification-helper: PROBLEM https://judge.yosupo.jp/problem/deque

global using System.Runtime.CompilerServices;

int Q = io.Int();

Deque<long> deque = new();

while (Q-- > 0)
{
    int q = io.Int();

    if (q == 0)
    {
        long x = io.Long();
        deque.PushFront(x);
    }
    else if (q == 1)
    {
        long x = io.Long();
        deque.PushBack(x);
    }
    else if (q == 2)
    {
        deque.PopFront();
    }
    else if (q == 3)
    {
        deque.PopBack();
    }
    else if (q == 4)
    {
        int i = io.Int();
        io.Print(deque[i]);
    }
}

Console.Out.Flush();