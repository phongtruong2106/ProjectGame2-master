using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputPositionEntry
{ 
    public Vector2 Position
    {
        get { m_position = CheckRangeSavePoint.Position_dt; return m_position; }
        set { m_position = value; }
    }
    public Vector2 m_position;

    public string NameScenes
    {
        get { m_nameScenes = CheckRangeSavePoint.scenesName_dt; return m_nameScenes; }
        set { m_nameScenes = value;}
    }
    public string m_nameScenes;

    public InputPositionEntry(Vector2 position, string nameScenes)
    {
        position = this.Position;
        nameScenes = this.NameScenes;

        Debug.Log(nameScenes + position);
    }
}
