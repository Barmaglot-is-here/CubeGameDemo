using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : IEnumerable<T> where T : MonoBehaviour
{
    private readonly List<T> _list;
    private readonly Func<T> _spawnAction;
    private readonly Action<T> _resetAction;

    private int _current;

    public ObjectPool(Func<T> spawnAction, Action<T> resetAction)
    {
        _list           = new();
        _spawnAction    = spawnAction;
        _resetAction    = resetAction;
    }

    public T GetNext()
    {
        T obj;

        if (_list.Count == 0 || _list[_current].gameObject.activeSelf)
        {
            obj = _spawnAction.Invoke();

            _list.Add(obj);
        }
        else
        {
            obj = _list[_current];

            _resetAction.Invoke(obj);

            _current = ++_current % _list.Count;
        }

        return obj;
    }

    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _list?.GetEnumerator();
}