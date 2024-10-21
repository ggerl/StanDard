using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public partial class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager instance;

    // [�������� 2] ���� ������Ƽ ����
    public static QuestManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<QuestManager>();

                if(instance == null)
                {
                    GameObject obj = new  GameObject("QuestManager");
                    instance = obj.AddComponent<QuestManager>(); 
                }
            }
            
            return instance;
        }
    }

    // [�������� 3] �ν��Ͻ� �˻� ����
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
    }
}