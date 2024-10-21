using System.Collections.Generic;
using UnityEngine;
public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            pool.Add(Instantiate(prefab));
            
        }
    }

    public GameObject Get()
    {
        foreach(GameObject obj in pool)
        {
            obj.SetActive(true);
            return obj;
        }
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }
}
