using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRangeCutScenes : MonoBehaviour
{
    public GameObject cutScenesTimelineObj;
    [SerializeField]
    private PlayerData playerData;

    public EnemyBoss1 enemyBoss1;
    public BossBattel bossBattel;
    private void Start()
    {
        cutScenesTimelineObj.SetActive(false);
        AfterCutScenes();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Check Range CutScenes");
            playerData.movementVelocity = 0f;
            cutScenesTimelineObj.SetActive(true);
            Invoke(nameof(LaterUpdate), 3f);
            Invoke(nameof(StopCutscene), 4f);
        }
    }
    private void StopCutscene()
    {
        playerData.movementVelocity = 4f;
        //cutScenesTimelineObj.SetActive(false);
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
}
