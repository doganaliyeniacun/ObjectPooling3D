using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPool : MonoBehaviour
{    
    public GameObject prefab;    
    public float prefabLengt;
    public int poolSize = 6;

    private List<GameObject> pool;
        
    private void Start()
    {        
        pool = new List<GameObject>();
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.transform.position = new Vector3(0, 0, prefabLengt * i);
            pool.Add(obj);
        }
    }
    
    public void AddToQueue()
    {
        GameObject firstObject = pool[0];
        GameObject lastObject = pool[pool.Count - 1];

        pool.Remove(firstObject);

        firstObject.transform.position = new Vector3(0,0,lastObject.transform.position.z + prefabLengt);

        pool.Add(firstObject);
    }

}
