using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckListItems : MonoBehaviour
{
    [SerializeField]
    private string filename;
    public static CheckListItems Instance;
    public ListItems itemsList;
    public bool isButtonGet = false;

    [SerializeField]
    private GameObject ui_controller;

    private void Start()
    {
        ui_controller = GameObject.Find("UIController");
    }
    private void Update()
    {
        if(isButtonGet)
        {
            GetDataToListItems();
            isButtonGet = false;
        }
    }
    public void GetDataToListItems()
    {
        foreach (Checkitems items in itemsList.listItems)
        {
            items.gameObject.SetActive(false);
        }
        List<InputEntry> itemList = DataManage.ReadFromJson<InputEntry>(filename);
        foreach (InputEntry item in itemList)
        {
            foreach(Checkitems items in itemsList.listItems)
            {

                if (item.m_ID == items.iD)
                {
                    Debug.Log(items.iD);
                    items.gameObject.SetActive(true);
                    break; // Once a match is found, no need to continue looping
                }

            }
        }
        isButtonGet = true;
    }
}
