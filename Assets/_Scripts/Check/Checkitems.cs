using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkitems : MonoBehaviour
{
    public int ID;
    public string Name;
    public string Description;

    [SerializeField]
    private string filename;

    private void Start()
    {
        ReadAndCompareItems();
    }
    private void Update()
    {
        ReadAndCompareItems();
    }

    private void ReadAndCompareItems()
    {
        List<InputEntry> itemList = DataManage.ReadFromJson<InputEntry>(filename);
        foreach (InputEntry item in itemList)
        {
             Debug.Log(item.m_ID);
            if(item.m_ID == ID)
            {
                UIController.instance.ShowItem();
            }
            else
            {
                UIController.instance.HideItem();
            }
        }
    }



}
