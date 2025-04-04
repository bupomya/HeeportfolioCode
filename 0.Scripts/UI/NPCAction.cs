using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCAction : MonoBehaviour
{
    [SerializeField] private bool isAction;

    public bool IsAction { get => isAction; set => isAction = value; }

    protected virtual void Update()
    {
        if (isAction)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Action();
            }
        }
        else
        {
            InAction();
        }
    }

    public abstract void Action();
    public abstract void InAction();
}
