using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractionCheck : MonoBehaviour
{
    [SerializeField] private CharacterUIManager characterUIManager;

    [SerializeField] private NPCAction npcAction;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            npcAction.IsAction = true;
            characterUIManager.SetActiveUI(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            npcAction.IsAction = false;
            characterUIManager.SetActiveUI(false);
        }
    }
}
