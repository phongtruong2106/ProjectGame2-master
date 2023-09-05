
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Checkitems : MonoBehaviour
{
    public int iD;
    public string nname;
    public string description;
    public Sprite sprite;
    public Image spriteAd;

    [SerializeField]
    private DataListItems dataListItems;
    [SerializeField]
    private GameObject uiController;
    

    private void Start()
    {
        iD = dataListItems.id_dt;
        nname = dataListItems.name_dt;
        description = dataListItems.description_dt;
        sprite = dataListItems.sprite_dt;
        uiController = GameObject.Find("UIController");
        ListItems.instace.listItems.Add(this);
        if (ListItems.instace.listItems.Count == ListItems.instace.number_items)
        {
            ListItems.instace.gameObject.SetActive(false);
        }
    }
    private void Awake()
    {
      
    }

    private void Update()
    {
        //iD = dataListItems.id_dt;
        //name = dataListItems.name_dt;
        //description = dataListItems.description_dt;
        //sprite = dataListItems.sprite_dt;
    }

    public void GetInForItemInCatalog()
    {
        uiController.GetComponent<UIController>().GetInforItemsDialogInCatalopgy(iD, nname, description, sprite);
    }
}
