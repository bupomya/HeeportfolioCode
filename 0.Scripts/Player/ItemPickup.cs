using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private GameObject pickUpEffectPrefab;

    [SerializeField] private InventorySystem inventorySystem;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Item"))
        {
            bool invenAdded = inventorySystem.AddItem(collider.GetComponent<ItemChest>().ItemInfo);

            if(invenAdded)
            {
                Instantiate(pickUpEffectPrefab, collider.transform.position, Quaternion.identity);

                Destroy(collider.gameObject);
            }
        }
    }
}
