using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPCAction : NPCAction
{
    [SerializeField] private DialogManager dialogueManager;

    [SerializeField] private int dialogStageIndex;

    [SerializeField] private int dialogIndex;

    public override void Action()
    {
        dialogueManager.LoadDialog(dialogStageIndex, dialogIndex);
    }

    public override void InAction()
    {
        dialogueManager.UnLoadDialog();
    }
}
