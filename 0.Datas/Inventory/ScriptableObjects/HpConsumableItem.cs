using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HpConsumable", menuName = "Item/HpConsumable")]
public class HpConsumableItem : ConsumableItem
{
    //������ ���
    public override void Consume()
    {
        base.Consume();
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerHealth>().HpUp(UpValue);
    }
}
