using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    private List<GameObject> pool;
    private int idx;
    private int poolCount;
    public ObjectPool(GameObject obj, int count)
    {
        pool = new List<GameObject>();
        poolCount = count;
        idx = 0;
        for (int i = 0; i < count; i++)
        {
            GameObject tmp = Instantiate(obj);
            tmp.SetActive(false);
            pool.Add(tmp);
        }
    }

    public GameObject GetItem()
    {
        for (int i = 0; i < poolCount; i++)
        {
            if (++idx == poolCount)
            {
                idx = 0;
            }
            if (!pool[idx].activeInHierarchy)
            {
                return pool[idx];
            }
        }
        return null;
    }

    public GameObject GetItem(int idx)
    {
        return pool[idx];
    }
}