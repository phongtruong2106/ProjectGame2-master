using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ListItems : MonoBehaviour
{
    public int number_items = 6;
    public List<Checkitems> listItems = new List<Checkitems>();
    public static ListItems instace;
    private void Awake()
    {
        instace = this;
    }

}
