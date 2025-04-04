using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    //스테이지 개수
    [SerializeField] private int stageClearCount;

    //열쇠 습득시 ++
    public static int StageCount = 0;

    [SerializeField] GameObject BossDoor;

    public void CheckBossRoomCount()
    {
        if(StageCount >= stageClearCount)
        {
            Debug.Log("보스방 열림");
            BossDoor.SetActive(false);
        }
    }

    private void Update()
    {
        if(BossDoor.activeSelf)
            CheckBossRoomCount();
    }
}
