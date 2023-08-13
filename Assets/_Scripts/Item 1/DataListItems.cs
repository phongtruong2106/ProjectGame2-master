using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItemData", menuName = "Data/Items Data/List Items/Base Data")]
public class DataListItems : ScriptableObject
{
    public int id_dt;
    public Sprite sprite_dt;
    public string name_dt;
    public string description_dt;
}
