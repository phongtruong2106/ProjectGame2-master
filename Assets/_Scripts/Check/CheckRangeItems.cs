using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class CheckRangeItems : MonoBehaviour
{
    public static CheckRangeItems instance;
    public GameObject keyBoard_Obj;
    public GameObject Item_Obj;
    public bool isShowKey = false;
    public static bool issaveData =false;

    protected PlayerData playerData;
    [SerializeField]
    private Items items;
    [SerializeField]
    private GameObject uiController;
    [SerializeField]
    

    public static int ID;
    public static string Name;
    public static string description;
    public static Sprite sprite;

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
        else if (instance != this)
        {

        }
    }
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
                sprite = items.GetSprite();
                UIManager.instance.OpenItemSystemsPanel();

                uiController.GetComponent<UIController>().GetInforItemToDialog(Name,sprite);
                Debug.Log(ID + "," + name + "," + description);
                Destroy(Item_Obj);
                issaveData = true;
                
            }
        }
    }
}
