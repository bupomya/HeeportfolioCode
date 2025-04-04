using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void OnCancelDelegate();
    public static OnCancelDelegate onCancelDelegate;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onCancelDelegate();
        }
    }
}
