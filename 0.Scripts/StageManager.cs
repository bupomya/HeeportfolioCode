using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    //�������� ����
    [SerializeField] private int stageClearCount;

    //���� ����� ++
    public static int StageCount = 0;

    [SerializeField] GameObject BossDoor;

    public void CheckBossRoomCount()
    {
        if(StageCount >= stageClearCount)
        {
            Debug.Log("������ ����");
            BossDoor.SetActive(false);
        }
    }

    private void Update()
    {
        if(BossDoor.activeSelf)
            CheckBossRoomCount();
    }
}
