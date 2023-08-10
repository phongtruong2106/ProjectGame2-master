using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputEntry
{
    public int ID
    {
        get { m_ID = CheckRangeItems.ID;   return m_ID; }
        set { m_ID = value; }
    }
    public int m_ID;
    public string Name
    {
        get { m_Name = CheckRangeItems.Name; return m_Name; }
        set { m_Name = value;}
    }
    public string m_Name;
    public string Description
    {
        get { m_Desxription = CheckRangeItems.description; return m_Desxription; }
        set { m_Desxription= value; }
    }
    public string m_Desxription;
    public Sprite SpritE
    {
        get { m_Sprite = CheckRangeItems.sprite; return m_Sprite; }
        set { m_Sprite = value; }
    }
    public Sprite m_Sprite;

    public InputEntry(int id, string name, string descripstion, Sprite sprite)
    {
        id = this.ID;
        name = this.Name;
        descripstion = this.Description;
        sprite = this.SpritE;

        Debug.Log(id + name + descripstion + sprite);
    }
}