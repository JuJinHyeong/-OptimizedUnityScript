using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private GameObject obj;
    ObjectPool pool;
    private void Awake()
    {
        print("This is Test");
        obj = new GameObject();
        pool = new ObjectPool(obj, 20);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tmp = pool.GetItem();
            tmp.SetActive(true);
            StartCoroutine(ActiveFalse(tmp));
        }
    }

    private IEnumerator ActiveFalse(GameObject obj)
    {
        yield return CachedYieldInstruction.WaitForSeconds(1.0f);
        obj.SetActive(false);
    }

}
