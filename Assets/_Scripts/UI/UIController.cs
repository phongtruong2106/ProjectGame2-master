using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;   
    [Header("UI ItemSystem Panel")]
    public Image avatarItem;
    [SerializeField]
    public Text nameItem;

    [Space]
    [Header("UI Catalog element")]
    [SerializeField]
    private GameObject Items_Avt;
    [SerializeField]
    private Image Items_null;
    [SerializeField]
    private Button btn_items;


    private void Start()
    {
        
    }
    public void CreateInstace()
    {
        if(instance == null)    
        {
            instance = this;
        }
        else if(instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void GetInforItemToDialog(string nameText, Sprite sp)
    {
        nameItem.text = nameText;
        avatarItem.sprite = sp;
    } 

    public void HideItem()
    {
       /* Items_Avt.enabled = true;*/
        Items_null.enabled = false;
        btn_items.enabled= false;
    }

    public void ShowItem()
    {
        /*Items_Avt.enabled = false;*/
        Items_null.enabled=true;
        btn_items.enabled=true;
    }
}
