using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefabs;
    public int size;

}
public class ObjectPool : MonoBehaviour
{
    
    private List<GameObject> pool = new List<GameObject>();
    private Dictionary<string, List<GameObject>> pools;
    public List<Pool> poolInspector;


    void Start()
    {
        pools = new Dictionary<string, List<GameObject>>();

        foreach (var pool in poolInspector)
        {
            InitializePool(pool.tag, pool.prefabs, pool.size);
        }
    }

    private void InitializePool(string tag, GameObject prefab ,  int size)
    {

        List<GameObject> pool = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);

        }
        pools.Add("Arrow", pool);



    }
    public GameObject Get(string tag)
    {
        foreach (GameObject obj in pools[tag])
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }

        }

        return null;
    }

    public void Release(string tag, GameObject obj)
    {
        if (pools.ContainsKey(tag) && pools[tag].Contains(obj))
        {
            obj.SetActive(false); // 비활성화
        }
        else
        {
            Debug.Log($"해당 태그를 가진 오브젝트 풀이 존재하지 않습니다 : {tag}.");
        }
    }
}
