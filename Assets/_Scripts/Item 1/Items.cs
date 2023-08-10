using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]
    private ItemsData items_Data;

    private int ID;
    private string Name;
    private string Description;
    private Sprite sprite;

    public int GetID()
    {
       ID = items_Data.id_dt; return ID;
    }

    public Sprite GetSprite()
    {
        sprite = items_Data.sprite_dt; return sprite;
    }

    public string GetName() 
    {
        Name = items_Data.name_dt; return Name;
    }

    public string GetDescription()
    {
        Description = items_Data.description_dt; return Description;
    }
}
