using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] protected Vector3 offset;

    public virtual void UpdateUIPosition(Vector3 characterUIPosition)
    {
        transform.position = Camera.main.WorldToScreenPoint(characterUIPosition + offset);
    }
}
