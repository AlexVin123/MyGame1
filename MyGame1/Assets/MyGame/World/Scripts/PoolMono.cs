using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T Prefab { get; private set; }

    public bool autoExpand { get; set; }

    public Transform Conteiner { get; private set; }

    private List<T> _pool;

    public PoolMono(T prefab, int count)
    {
        Prefab = prefab;
        Conteiner = null;
        CreatePool(count);
    }

    public PoolMono(T prefab, int count, Transform conteiner)
    {
        Prefab = prefab;
        Conteiner = conteiner;
        CreatePool(count);
    }

    public void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(Prefab, Conteiner, true);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T result)
    {
        foreach (var element in _pool)
        {
            if(element.gameObject.activeInHierarchy == false)
            {
                result = element;
                return true;
            }
        }

        result = null;
        return false;
    }

    public T GetFreeElement(Vector2 position)
    {
        if (HasFreeElement(out T result))
        {
            result.transform.position = position;
            result.gameObject.SetActive(true);
            return result;
        }

        if (autoExpand)
            return CreateObject(true);

        throw new System.ArgumentNullException();
    }

    public T[] GetAllElements()
    {
        return _pool.ToArray();
    }

}
