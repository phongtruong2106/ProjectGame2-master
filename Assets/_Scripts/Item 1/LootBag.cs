using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    
    public void GetItemsDropp()
    {
        Vector3 position = transform.position;
        GameObject obj = Instantiate(droppedItemPrefab, position, Quaternion.identity);
        obj.SetActive(true);
    }
}
