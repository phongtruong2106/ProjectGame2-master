using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class CheckRangeCutScenes : MonoBehaviour
{

    public static CheckRangeCutScenes instance;
    public GameObject cutScenesTimelineObj;
    public PlayerData playerData;
    public EnemyBoss1 enemyBoss1;
    public BossBattel bossBattel;
    public GameObject Npc_obj;

    [Header("INK JSON")]
    [SerializeField]
    private TextAsset inkJSON;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AfterCutScenes();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Check Range CutScenes");
            PlayCutScenes();
            PlayCutScenesDialog();
            StopAction();
            Invoke(nameof(LaterUpdate),4f);
            Invoke(nameof(StopCutscene),4f);
        }
    }
    private void StopCutscene()
    {
        playerData.movementVelocity = 5f;
        Destroy(gameObject);
        
    }

    private void AfterCutScenes()
    {

        enemyBoss1.enabled = false;
        bossBattel.enabled = false;
    }

    private void LaterUpdate()
    {
        enemyBoss1.enabled = true;
        bossBattel.enabled = true;
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
        if(inkJSON != null)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
        
    }

    public void StopAction()
    {
        playerData.movementVelocity = 0f;
    }
    public void StartAction()
    {
        cutScenesTimelineObj.SetActive(false);
        PlayerInputHandel.GetInstance().isjump = true;
        PlayerInputHandel.GetInstance().isAttack = true;
        PlayerInputHandel.GetInstance().isDash = true;
        if(Npc_obj != null)
        {
            Destroy(Npc_obj);
        }
        
    }
}