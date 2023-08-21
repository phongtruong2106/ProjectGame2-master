using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    [SerializeField]
    private GameObject ui_inventory_panel;
    [SerializeField]
    private GameObject ui_ItemSystem_panel;
    [SerializeField]
    private GameObject ui_Dialog_boxItems_panel;
    [Space]
    [SerializeField]
    private Button btn_Open_Inventory;
    [SerializeField]
    private Button btn_Close_Inventory;
    public bool isButtonGet = false;

    private void Awake()
    {
        CreateInstance();
    }
    private void Update()
    {
       if(isButtonGet)
        {
            OpenIventoryPanel();
            isButtonGet = false;
        }
    }

    private void CreateInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void OpenIventoryPanel()
    {
       
        ui_inventory_panel.SetActive(true);
        CheckListItems.instance.GetDataToListItems();
        isButtonGet =true;
    }

    public void OpenItemSystemsPanel()
    {
        ui_ItemSystem_panel.SetActive(true);
    }

    public void OpenDialogSystemPanel()
    {
        ui_Dialog_boxItems_panel.SetActive(true);
    }

    public void CloseIventoryPanel()
    {
        ui_inventory_panel.SetActive(false);
    }
    public void CloseItemSystemsPanel()
    {
        ui_ItemSystem_panel.SetActive(false);
    }
    public void CloseDialogSystemPanel()
    {
        ui_Dialog_boxItems_panel.SetActive(false);
    }
/*
    private void OpenIventoryPanelWithkeyF()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            ui_inventory_panel.SetActive(true);
            CheckListItems.GetComponent<CheckListItems>().GetDataToListItems();

        }
    }*/
}
