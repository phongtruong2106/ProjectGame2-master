using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [Space]
    [Header("UI Dialog Box")]
    [SerializeField]
    private Image avatar_items;
    [SerializeField]
    private Text name_items;
    [SerializeField]
    private Text descripstion_items;
    [SerializeField]
    private Text id_items;

    [Header("UI ItemSystem Panel")]
    public Image avatarItem;
    [SerializeField]
    public Text nameItem;

    [Space]
    [Header("UI Catalog element")]
    [SerializeField]
    private GameObject[] image_Avatar;

    
    private void Start()
    {
        image_Avatar = GameObject.FindGameObjectsWithTag("Items");
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

    public void GetInforItemsDialogInCatalopgy(int id, string name, string description, Sprite avatar)
    {
        id_items.text = id.ToString();
        name_items.text = name;
        descripstion_items.text = description;
        avatar_items.sprite = avatar;
    }

    public void HideItemImage()
    {
        foreach (GameObject item in image_Avatar)
        {
             item.SetActive(false);
             break;
        }
          
    }
}
