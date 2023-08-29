using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputHandler: MonoBehaviour
{
    public static InputHandler instance;
    
    [SerializeField]
    private string filename;
    private int id_Handle;
    private string name_Handle;
    private string description_Handle;
    private Sprite sprite_Handle;

    [SerializeField]
    private string filenameSavePosition;

    [SerializeField]
    private Vector2 position;
    private string nameScenes;

    public List<InputEntry> data_List = new List<InputEntry>();

    public List<InputPositionEntry> position_List = new List<InputPositionEntry>();

    private void Start()
    {
        data_List = DataManage.ReadFromJson<InputEntry>(filename);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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


    public void AddNewPosition()
    {
        position_List.Add(new InputPositionEntry(position, nameScenes));
        DataManage.SaveToJson<InputPositionEntry>(position_List, filenameSavePosition);


    }
}
