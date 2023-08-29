using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRangeSavePoint : MonoBehaviour
{
    [SerializeField]
    private PositionPlayerData positionPlayerData;
    [SerializeField]
    private GameObject showKeyInput;
    public bool isShowKey = false;
    public static Vector2 Position_dt;
    public static string scenesName_dt;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    private void Update()
    {
        GetSave();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            keyBoardShow();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            KeyBoardHide();
        }
    }
    private void keyBoardShow()
    {
        showKeyInput.SetActive(true);
        isShowKey = true;
    }
    private void KeyBoardHide()
    {
        showKeyInput.SetActive(false);
        isShowKey = false;
    }


    private void GetSave()
    {
        if(isShowKey)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Position_dt = positionPlayerData.position;
                scenesName_dt = positionPlayerData.sceneName;
                Debug.Log(Position_dt + " " +  scenesName_dt);
                InputHandler.instance.AddNewPosition();
                playerStorage.initialValue = Position_dt;
                UIManager.instance.OpenNotificationPanel();
            }
        }
        
    }
}


