using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public partial class QuestManager : MonoBehaviour
{
    public QuestDataSO[] Quests;
    private static QuestManager instance;
    public Player player;



    private void Start()
    {
        Quests = Resources.LoadAll<QuestDataSO>("Quests");
        

       for(int i = 0; i<Quests.Length; i++)
        {
            QuestDataSO quest = Quests[i];
            Debug.Log($"Quest {i + 1} - {quest.QuestName} (�ּ� ���� {quest.QuestRequiredLevel})");

            if(quest is MonsterQuestDataSO monsterQuestDataSO)
            {
                Debug.Log($"{(NPCID)monsterQuestDataSO.QuestNPC}�� {monsterQuestDataSO.TargetMonster} �� {monsterQuestDataSO.TargetNum} ���� ���� ");
            }
            else if(quest is EncounterQuestDataSO encounterQuestDataSO)
            {
                Debug.Log($"{(NPCID)encounterQuestDataSO.QuestNPC}�� ��ȭ�ϱ�");

            }

        }
    }
    public static QuestManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<QuestManager>();

                if(instance == null)
                {
                    GameObject obj = new GameObject("QuestManager");
                    instance = obj.AddComponent<QuestManager>(); 
                }
            }
            
            return instance;
        }
    }

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