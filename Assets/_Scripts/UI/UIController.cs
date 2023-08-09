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

    public void GetInforItemToDialog(string nameText)
    {
        nameItem.text = nameText;
    }
}
