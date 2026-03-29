/// <summary>
/// Standard input reader for competitive programming.
/// </summary>
public sealed class CPIO
{
    Queue<string> _readQueue = new Queue<string>();

    static CPIO()
    {
        // faster standard output
        StreamWriter writer = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
        Console.SetOut(writer);
    }

    private void LoadQueue()
    {
        if (_readQueue.Count > 0) return;
        string line = Console.ReadLine();
        string[] split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < split.Length; i++) _readQueue.Enqueue(split[i]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Guard()
    {
        if (_readQueue.Count == 0)
        {
            throw new Exception("Standard input queue was empty.");
        }
    }

    public int Int()
    {
        LoadQueue();
        Guard();
        return int.Parse(_readQueue.Dequeue());
    }

    public long Long()
    {
        LoadQueue();
        Guard();
        return long.Parse(_readQueue.Dequeue());
    }

    public string String()
    {
        LoadQueue();
        Guard();
        return _readQueue.Dequeue();
    }

    public short Short()
    {
        LoadQueue();
        Guard();
        return short.Parse(_readQueue.Dequeue());
    }

    public byte Byte()
    {
        LoadQueue();
        Guard();
        return byte.Parse(_readQueue.Dequeue());
    }

    public char Char()
    {
        LoadQueue();
        Guard();
        return char.Parse(_readQueue.Dequeue());
    }

    public double Double()
    {
        LoadQueue();
        Guard();
        return double.Parse(_readQueue.Dequeue());
    }

    public float Float()
    {
        LoadQueue();
        Guard();
        return float.Parse(_readQueue.Dequeue());
    }

    public T Read<T>()
    {
        Type type = typeof(T);
        if (type == typeof(int)) return (T)(object)Int();
        else if (type == typeof(long)) return (T)(object)Long();
        else if (type == typeof(float)) return (T)(object)Float();
        else if (type == typeof(double)) return (T)(object)Double();
        else if (type == typeof(short)) return (T)(object)Short();
        else if (type == typeof(byte)) return (T)(object)Byte();
        else if (type == typeof(char)) return (T)(object)Char();
        else if (type == typeof(string)) return (T)(object)String();
        else return default(T);
    }

    public int[] IntArray(int n)
    {
        if (n == 0) return Array.Empty<int>();

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = Int();
        }

        return arr;
    }

    public int[] ZeroIndexedPermutation(int n)
    {
        if (n == 0) return Array.Empty<int>();

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = Int() - 1;
        }

        return arr;
    }

    public long[] LongArray(int n)
    {
        if (n == 0) return Array.Empty<long>();

        long[] arr = new long[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = Long();
        }

        return arr;
    }

    public double[] DoubleArray(int n)
    {
        if (n == 0) return Array.Empty<double>();

        double[] arr = new double[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = Double();
        }

        return arr;
    }

    public string[] StringArray(int n)
    {
        if (n == 0) return Array.Empty<string>();

        string[] arr = new string[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = String();
        }

        return arr;
    }

    public T[] ReadArray<T>(int n)
    {
        if (n == 0) return Array.Empty<T>();

        T[] arr = new T[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = Read<T>();
        }

        return arr;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void YesNo(bool t)
    {
        Console.WriteLine(t ? "Yes" : "No");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Print<T>(IEnumerable<T> array, char delimiter = ' ')
    {
        Console.WriteLine(string.Join(delimiter, array));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Print(string value) => Console.WriteLine(value);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Print(int value) => Console.WriteLine(value);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Print(long value) => Console.WriteLine(value);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Print(double value, int digits = 10) => Console.WriteLine(Math.Round(value, digits).ToString());
}