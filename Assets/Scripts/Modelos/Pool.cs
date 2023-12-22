using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pool<T>
{
    //delegado que devuelve un tipo T. Aca voy a guardar el metodo cde como se crea el objeto
    private Func<T> _factoryMethod;

    //delegado que toma por parametro tipo T. aca voy a guardar como se prende la bala una vez que la llame.
    Action<T> _turnOnCallback;

    //delegado que toma por parametro tipo T. aca voy a guardar como se apaga la bala una vez que vuevle al pool.
    Action<T> _turnOffCallback;

    // mi Cajon donde voy a guardar los objetos disponibles.
    List<T> _currentStock;

    public Pool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallBack, int initialAmount)
    {
        _currentStock = new List<T>();

        _factoryMethod = factoryMethod;

        _turnOnCallback = turnOnCallback;

        _turnOffCallback = turnOffCallBack;

        for (int i = 0; i < initialAmount; i++)
        {
            T newObj = _factoryMethod();

            _turnOffCallback(newObj);

            _currentStock.Add(newObj);
        }
    }

    public T GetObject()
    {
        T result;

        if (_currentStock.Count == 0)
        {
            result = _factoryMethod();
        }
        else
        {
            result= _currentStock[0];
            _currentStock.RemoveAt(0);
        }

        _turnOnCallback(result);

        return result;
    }

    public void ReturnObject(T obj)
    {
        _turnOffCallback(obj);

        _currentStock.Add(obj);
    }
}
