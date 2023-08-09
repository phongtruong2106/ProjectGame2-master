using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CheckRangeItems : MonoBehaviour
{
    public GameObject keyBoard_Obj;
    public GameObject Item_Obj;
    public bool isShowKey = false;

    protected PlayerData playerData;
    [SerializeField]
    private Items items;
    [SerializeField]
    private GameObject uiController;
    

    public int ID;
    public string Name;
    public string description;

    private void Update()
    {
        Enterbutton();
    }
    private void Start()
    {
        uiController = GameObject.Find("UIController");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            keyBoardShow();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            KeyBoardHide();
        }
    }

    private void keyBoardShow()
    {
        keyBoard_Obj.SetActive(true);
        isShowKey = true;
    }
    private void KeyBoardHide()
    {
        keyBoard_Obj.SetActive(false);
        isShowKey = false;
    }

    private void Enterbutton()
    {
        if(isShowKey)
        {
            if(Input.GetKey(KeyCode.F))
            {
                ID = items.GetID();
                Name = items.GetName();
                description = items.GetDescription();
                UIManager.instance.OpenItemSystemsPanel();
                uiController.GetComponent<UIController>().GetInforItemToDialog(Name);
                Debug.Log(ID + "," + name + "," + description);
                Destroy(Item_Obj);
                
            }
        }
    }
}
