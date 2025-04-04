using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    public GameObject stageKey;

    [SerializeField] private List<GameObject> monstersInArea = new List<GameObject>();

    public List<GameObject> MonstersInArea { get => monstersInArea; set => monstersInArea = value; }

    //���� �߰�
    public void AddMonster(GameObject monster)
    {
        if (!MonstersInArea.Contains(monster))
        {
            MonstersInArea.Add(monster);
        }
    }

    public void OnMonsterDied(GameObject monster)
    {

        if (MonstersInArea.Contains(monster))
        {
            MonstersInArea.Remove(monster);
            Debug.Log("���� ����Ʈ���� ����");
        }

        CheckMonstersInArea();
    }

    private void CheckMonstersInArea()
    {
        if(MonstersInArea.Count <= 0)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (stageKey != null )
        {
            stageKey.SetActive(true);
        }
    }
}
