using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.List;

public class List<T> : IEnumerable<T>
{
    private int _size = 0;
    private int _capacity;
    private T[] _items;
    public int Count
    {
        get
        {
            return _size;
        }
    }
    public List()
    {
        _items = new T[0];
        _capacity = 0;
        _size = 0;
    }
    public List(int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(0, int.MaxValue, "Capacity can not be negative.");
        _capacity = capacity;
        _items = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException(nameof(index));
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException(nameof(index));
            _items[index] = value;
        }
    }
    public bool IsEmpty()
    {
        return _size == 0;
    }
    public void Add(T item)
    {
        if (_size + 1 >= _capacity)
        {
            EnsureCapacity();
        }
        _items[_size++] = item;
    }
    public void Clear()
    {
        for (int i = 0; i < _size; i++)
        {
            _items[i] = default;
        }

        _size = 0;
    }
    public T RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
            throw new ArgumentOutOfRangeException(nameof(index));
        var value = _items[index];
        var newItems = new T[_capacity];
        for (int i = 0, j = 0; i < _items.Length; j++, i++)
        {
            if (index == i)
            {
                j--;
            }
            else
            {
                newItems[j] = _items[i];
            }
        }
        _size--;
        _items = newItems;
        return value;
    }
    public bool Remove(object item)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (item.Equals(_items[i]))
            {
                RemoveAt(i);
                return true;
            }
        }
        return false;
    }
    public int IndexOf(object item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (item.Equals(_items[i]))
            {
                RemoveAt(i);
                return i;
            }
        }
        return -1;
    }
    public bool Contains(object item)
    {
        return IndexOf(item) != -1;
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _size; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
    private void EnsureCapacity()
    {
        if (_capacity == 0)
        {
            _capacity = 1;
        }
        else
        {
            _capacity *= 2;
        }

        var newArr = new T[_capacity];
        Array.Copy(_items, newArr, _size);
        _items = newArr;
    }

    public override string ToString()
    {
        if (_size == 0) return "[]";
        var sb = new StringBuilder();
        sb.Append("[");
        for (int i = 0; i < _size - 1; i++)
        {
            sb.Append($"{_items[i]}, ");
        }
        return sb.Append($"{_items[_size - 1]}]").ToString();
    }
}
