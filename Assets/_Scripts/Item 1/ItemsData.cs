using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newItemData", menuName = "Data/Items Data/Base Data")]
public class ItemsData : ScriptableObject
{
    public int id_dt;
    //public Sprite Sprite_data;
    public string name_dt;
    public string description_dt;

/*    public ItemsData(int id_dt, string name_dt, string description_dt)
    {
        this.id_dt = id_dt;
        this.name_dt = name_dt;
        this.description_dt = description_dt;
    }*/
}
