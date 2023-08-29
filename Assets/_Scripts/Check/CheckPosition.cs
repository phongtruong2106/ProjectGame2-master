using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPosition : MonoBehaviour
{
    public static CheckPosition instance;
    [SerializeField]
    private string filename;

    public Vector2 position_d;
    public string nameScenes;
    public VectorValue startingPosition;



    public List<InputPositionEntry> position_list = new List<InputPositionEntry>();

    private void Awake()
    {
        CreateInstace();
    }

    private void Start()
    {
        position_list = DataManage.ReadFromJson<InputPositionEntry>(filename);
    }

    public void CreateInstace()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void LoadGame()
    {
        foreach(InputPositionEntry inputPosion in position_list)
        {
            nameScenes = inputPosion.m_nameScenes;
            SceneManager.LoadScene(nameScenes);
        }
    }
}
