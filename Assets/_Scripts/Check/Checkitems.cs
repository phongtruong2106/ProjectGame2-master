using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Checkitems : MonoBehaviour
{
    public int iD;
    public string name;
    public string description;
    public Sprite sprite;

    [SerializeField]
    private DataListItems dataListItems;
    [SerializeField]
    private GameObject uiController;

    private void Start()
    {
        uiController = GameObject.Find("UIController");
    }

    private void Update()
    {
        iD = dataListItems.id_dt;
        name = dataListItems.name_dt;
        description = dataListItems.description_dt;
        sprite = dataListItems.sprite_dt;
    }

    public void GetInForItemInCatalog()
    {
        uiController.GetComponent<UIController>().GetInforItemsDialogInCatalopgy(iD, name, description, sprite);
    }
}
