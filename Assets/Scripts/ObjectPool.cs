using System.Collections.Generic;
using UnityEngine;
public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    private Dictionary<string, List<GameObject>> pools;
    public int poolSize = 300;


    void Start()
    {
        pools = new Dictionary<string, List<GameObject>>();

        for (int i = 0; i < poolSize; i++)
        {
            pool.Add(Instantiate(prefab));

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
