using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckListItems : MonoBehaviour
{
    public static CheckListItems instance;
    [SerializeField]
    private string filename;
    
    public ListItems itemsList;
    public bool isButtonGet = false;

    [SerializeField]
    private GameObject ui_manager;
    public List<InputEntry> data_List = new List<InputEntry>();

    private void Awake()
    {
        CreateInstace();
    }

    public void CreateInstace()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    private void Start()
    {
        data_List = DataManage.ReadFromJson<InputEntry>(filename);
        ui_manager = GameObject.Find("UIManager");
    }
    private void Update()
    {
        /*if(isButtonGet)
        {
            GetDataToListItems();
            isButtonGet =false;
        }*/
    }
    public void GetDataToListItems()
    { 
        
        foreach (Checkitems itemss in itemsList.listItems)
        {
            itemss.gameObject.SetActive(false);
        }
       
        foreach (InputEntry item in data_List)
        { 
            foreach(Checkitems items in itemsList.listItems)
            {
                
                if (item.m_ID == items.iD)
                {
                    Debug.Log(items.iD);
                    items.gameObject.SetActive(true);
                    break;
                }

            }
        }
        isButtonGet = true;
    }
}
