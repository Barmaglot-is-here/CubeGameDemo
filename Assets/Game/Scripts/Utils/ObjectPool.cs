using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : IReadOnlyList<T> where T : MonoBehaviour
{
    private readonly List<T> _list;
    private readonly Func<T> _createFunc;

    private int _current;

    public Action<T> OnCreate;
    public Action<T> OnReset;

    public int Count => _list.Count;
    public T this[int index] => _list[index];

    public ObjectPool(Func<T> createFunc)
    {
        _list       = new();
        _createFunc = createFunc;
    }

    public T GetNext()
    {
        T obj;

        if (_list.Count == 0 || _list[_current].gameObject.activeSelf)
        {
            obj = _createFunc.Invoke();

            _list.Add(obj);

            OnCreate?.Invoke(obj);
        }
        else
        {
            obj = _list[_current];

            OnReset.Invoke(obj);

            _current = ++_current % _list.Count;
        }

        return obj;
    }

    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _list?.GetEnumerator();
}