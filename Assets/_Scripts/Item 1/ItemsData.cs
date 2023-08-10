using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "newItemData", menuName = "Data/Items Data/Base Data")]
public class ItemsData : ScriptableObject
{
    public int id_dt;
    public Sprite sprite_dt;
    public string name_dt;
    public string description_dt;
}
