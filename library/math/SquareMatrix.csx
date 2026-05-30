/// <summary>
/// Represents a square matrix on T.
/// </summary>
public sealed class SquareMatrix<T> : IEquatable<SquareMatrix<T>>
                                    where T :
                                    IAdditionOperators<T, T, T>,
                                    IMultiplyOperators<T, T, T>,
                                    IAdditiveIdentity<T, T>,
                                    IMultiplicativeIdentity<T, T>,
                                    IEqualityOperators<T, T, bool>
{
    private T[,] _m;
    private int _size;

    /// <summary>
    /// Get the element (r, c).
    /// </summary>
    public T this[int r, int c]
    {
        get
        {
            return _m[r, c];
        }
        set
        {
            _m[r, c] = value;
        }
    }

    public T[,] M => _m;
    public int Size => _size;

    private SquareMatrix()
    {
    }

    private SquareMatrix(int size)
    {
        if (size <= 0)
        {
            throw new InvalidOperationException();
        }

        _size = size;
        _m = new T[size, size];
    }

    /// <summary>
    /// Calculates the power to e. Time complexity is O(size^3loge).
    /// </summary>
    public SquareMatrix<T> Power(long e)
    {
        if (e == 1) return this;

        SquareMatrix<T> half = Power(e / 2);
        SquareMatrix<T> res = half * half;
        if (e % 2 == 1) res *= this;

        return res;
    }

    /// <summary>
    /// Returns the transposed matrix. Time complexity is O(size^2).
    /// </summary>
    public SquareMatrix<T> Transpose()
    {
        SquareMatrix<T> result = new(_size);

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                result[j, i] = this[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Returns a zero matrix. Time complexity is O(size^2).
    /// </summary>
    public static SquareMatrix<T> Zero(int size)
    {
        SquareMatrix<T> result = new SquareMatrix<T>(size);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                result[i, j] = T.AdditiveIdentity;
            }
        }

        return result;
    }

    /// <summary>
    /// Returns an identity matrix. Time complexity is O(size^2).
    /// </summary>
    public static SquareMatrix<T> Identity(int size)
    {
        SquareMatrix<T> result = new SquareMatrix<T>(size);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i == j) result[i, j] = T.MultiplicativeIdentity;
                else result[i, j] = T.AdditiveIdentity;
            }
        }

        return result;
    }



    public static bool operator ==(SquareMatrix<T> a, SquareMatrix<T> b) => a.Equals(b);
    public static bool operator !=(SquareMatrix<T> a, SquareMatrix<T> b) => !a.Equals(b);

    public static SquareMatrix<T> operator +(SquareMatrix<T> left, SquareMatrix<T> right)
    {
        if (left.Size != right.Size)
        {
            throw new InvalidOperationException();
        }
        SquareMatrix<T> dest = new(left.Size);
        for (int r = 0; r < left.Size; r++)
        {
            for (int c = 0; c < left.Size; c++)
            {
                dest[r, c] = left[r, c] + right[r, c];
            }
        }

        return dest;
    }

    public static SquareMatrix<T> operator *(SquareMatrix<T> left, SquareMatrix<T> right)
    {
        if (left.Size != right.Size)
        {
            throw new InvalidOperationException();
        }

        SquareMatrix<T> result = Zero(left.Size);

        for (int r = 0; r < result.Size; r++)
        {
            for (int c = 0; c < result.Size; c++)
            {
                for (int i = 0; i < result.Size; i++)
                {
                    result[r, c] += right[i, c] * left[r, i];
                }
            }
        }

        return result;
    }

    public bool Equals(SquareMatrix<T> other)
    {
        if (_size != other.Size) return false;

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (this[i, j] != other[i, j]) return false;
            }
        }

        return true;
    }

    public override bool Equals(object obj)
    {
        if (obj is SquareMatrix<T> mat)
        {
            return Equals(mat);
        }
        else
            return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        int[] maxwidths = new int[_size];
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                maxwidths[j] = int.Max(maxwidths[j], _m[i, j].ToString().Length);
            }
        }

        StringBuilder sb = new();

        for (int i = 0; i < _size; i++)
        {
            sb.Append('|');
            sb.Append(' ');
            for (int j = 0; j < _size; j++)
            {
                sb.Append(_m[i, j].ToString().PadRight(maxwidths[j], ' '));
                if (j < _size - 1) sb.Append(' ');
            }
            sb.Append(' ');
            sb.Append('|');
            if (i < _size - 1)
                sb.Append(Environment.NewLine);
        }

        return sb.ToString();
    }
}