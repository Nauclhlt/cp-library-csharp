/// <summary>
/// Double-Ended Queue implementation. Supports push/pop to the front and back, and random access.
/// </summary>
/// <typeparam name="T">Value type.</typeparam>
public sealed class Deque<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 32;

    private T[] _buffer;
    private int _capacity;

    private int _head;
    private int _length;

    public int Count => _length;
    public int Capacity => _capacity;
    
    public T this[int index]
    {
        get {
            if (index < 0 || index >= _length) throw new IndexOutOfRangeException("The specified index is out of the bounds of the deque.");
            return _buffer[_head + index];
        }
        set {
            if (index < 0 || index >= _length) throw new IndexOutOfRangeException("The specified index is out of the bounds of the deque.");
            _buffer[_head + index] = value;
        }
    }

    public Deque() : this(DefaultCapacity)
    {
    }

    public Deque(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentException("The capacity must be greater than 0.");
        }

        _capacity = capacity;
        _buffer = new T[_capacity];
        _head = _capacity / 2;
        _length = 0;
    }

    private void ResizeBuffer()
    {
        _capacity <<= 1;

        T[] newBuffer = new T[_capacity];
        int newHead = (_capacity - _length) / 2;
        Array.Copy(_buffer, _head, newBuffer, newHead, _length);

        _head = newHead;
        _buffer = newBuffer;
    }

    /// <summary>
    /// Push the value to the front. Time complexity is amortized O(1).
    /// </summary>
    public void PushFront(T value)
    {
        if (_length == 0)
        {
            _length++;
            _buffer[_head] = value;
        }
        else
        {
            if (_head == 0)
            {
                ResizeBuffer();
            }

            _head--;
            _buffer[_head] = value;
            _length++;
        }
    }

    /// <summary>
    /// Push the value to the back. Time complexity is amortized O(1).
    /// </summary>
    public void PushBack(T value)
    {
        if (_head + _length >= _capacity)
        {
            ResizeBuffer();
        }

        _buffer[_head + _length] = value;
        _length++;
    }

    /// <summary>
    /// Pop the front item. Time complexity is O(1).
    /// </summary>
    public T PopFront()
    {
        if (_length == 0)
        {
            throw new InvalidOperationException("Deque is empty.");
        }

        T front = _buffer[_head];
        _head++;
        _length--;

        return front;
    }

    /// <summary>
    /// Pop the back value. Time complexity is O(1).
    /// </summary>
    public T PopBack()
    {
        if (_length == 0)
        {
            throw new InvalidOperationException("Deque is empty.");
        }

        T back = _buffer[_head + _length - 1];
        _length--;

        return back;
    }

    /// <summary>
    /// Returns the front value. Time complexity is O(1).
    /// </summary>
    public T PeekFront()
    {
        if (_length == 0)
        {
            throw new InvalidOperationException("Deque is empty.");
        }

        return _buffer[_head];
    }

    /// <summary>
    /// Returns the back value. Time complexity is O(1).
    /// </summary>
    public T PeekBack()
    {
        if (_length == 0)
        {
            throw new InvalidOperationException("Deque is empty.");
        }

        return _buffer[_head + _length - 1];
    }

    /// <summary>
    /// If the deque is not empty, gets the front value and returns true, otherwise, returns false. Time complexity is O(1).
    /// </summary>
    public bool TryPeekFront(out T value)
    {
        if (_length == 0)
        {
            value = default;
            return false;
        }

        value = _buffer[_head];
        return true;
    }

    /// <summary>
    /// If the deque is not empty, gets the back value and returns true, otherwise, returns false. Time complexity is O(1).
    /// </summary>
    public bool TryPeekBack(out T value)
    {
        if (_length == 0)
        {
            value = default;
            return false;
        }

        value = _buffer[_head + _length - 1];
        return true;
    }

    /// <summary>
    /// Gets the view of underlying data. Time Complexity is O(1).
    /// </summary>
    public ReadOnlySpan<T> AsSpan()
    {
        return _buffer.AsSpan(_head, _length);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return (new ArraySegment<T>(_buffer, _head, _length)).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}