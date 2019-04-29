using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool{
    private List<GameObject> pool;
    ObjectPool(GameObject obj, int count){
        pool = new List<GameObject>();
        for(int i=0; i<count; i++){
            GameObject tmp = Instantiate(obj);
            tmp.SetActive(false);
            pool.Add(tmp);
        }
    }
    private GameObject GetItem(int idx){
        return pool[idx];
    }
}