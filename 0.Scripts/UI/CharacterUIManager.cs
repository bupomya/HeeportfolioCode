using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIManager : MonoBehaviour
{
    [SerializeField] protected GameObject uiPrefab;

    protected GameObject uiGameObject;

    [SerializeField] protected string uiCanvasRootName;

    protected Transform uiCanvasRoot;

    protected CharacterUI characterUI;

    private void Start()
    {
        uiCanvasRoot = GameObject.Find(uiCanvasRootName).transform;

        uiGameObject = Instantiate(uiPrefab, uiCanvasRoot);

        characterUI = uiGameObject.GetComponent<CharacterUI>();

        SetActiveUI(false);
    }

    protected virtual void LateUpdate()
    {
        characterUI?.UpdateUIPosition(transform.position);
    }

    public void SetActiveUI(bool isActive)
    {
        characterUI.gameObject.SetActive(isActive);
    }
}
