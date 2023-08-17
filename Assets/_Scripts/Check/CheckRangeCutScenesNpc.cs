using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRangeCutScenesNpc : MonoBehaviour
{
    public static CheckRangeCutScenesNpc instance;
    public GameObject cutScenesTimelineObj;
    public PlayerData playerData;
    public GameObject Npc_obj;

    [Header("INK JSON")]
    [SerializeField]
    private TextAsset inkJSON;

    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Check Range CutScenes");
            PlayCutScenes();
            PlayCutScenesDialog();
            StopAction();
            Invoke(nameof(StopCutscene), 4f);
        }
    }
    private void StopCutscene()
    {
        playerData.movementVelocity = 5f;
        Destroy(gameObject);

    }


    private void PlayCutScenes()
    {
        cutScenesTimelineObj.SetActive(true);
        playerData.movementVelocity = 0f;
    }
    public void StopCutScenes()
    {
        cutScenesTimelineObj.SetActive(false);
    }

    private void PlayCutScenesDialog()
    {
        if (inkJSON != null)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }

    }

    public void StopAction()
    {
        playerData.movementVelocity = 0f;
        PlayerInputHandel.GetInstance().isjump = false;
        PlayerInputHandel.GetInstance().isAttack = false;
        PlayerInputHandel.GetInstance().isDash = false;
    }
    public void StartAction()
    {
        if(cutScenesTimelineObj == null)
        {
            if(cutScenesTimelineObj != null)
            {
                 cutScenesTimelineObj.SetActive(false);
            }
            
            playerData.movementVelocity = 4f;
            PlayerInputHandel.GetInstance().isjump = true;
            PlayerInputHandel.GetInstance().isAttack = true;
            PlayerInputHandel.GetInstance().isDash = true;
            if(Npc_obj != null)
            {
                 Destroy(Npc_obj);
            }
        }
        

    }
}
