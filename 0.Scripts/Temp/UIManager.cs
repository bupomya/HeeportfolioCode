using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text keyCount;

    private void Update()
    {
        keyCount.text =  " X " + StageManager.StageCount.ToString();
    }
}
