using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputHandler: MonoBehaviour
{
    [SerializeField]
    private string filename;
    private int id_Handle;
    private string name_Handle;
    private string description_Handle;
    private Sprite sprite_Handle;

    public List<InputEntry> data_List = new List<InputEntry>();

    private void Start()
    {
        data_List = DataManage.ReadFromJson<InputEntry>(filename);
    }
    private void Update()
    {
        if(CheckRangeItems.issaveData)
        {
            AddNewItem();
            CheckRangeItems.issaveData = false;
        }
        
    }

    public void AddNewItem()
    {
        
        data_List.Add(new InputEntry(id_Handle, name_Handle, description_Handle, sprite_Handle));

        DataManage.SaveToJson<InputEntry>(data_List, filename);
    }
}
