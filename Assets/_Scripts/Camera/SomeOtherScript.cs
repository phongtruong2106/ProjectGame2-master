using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeOtherScript : MonoBehaviour
{
    public CameraManage cameraManager;

    private void Start()
    {
        GameObject player = Instantiate(SpawnPlayers.Instance.playerPrefab, transform.position, Quaternion.identity);
        // Chuyển đối tượng Player vào cameraObj để theo dõi
        cameraManager.SetPlayerTarget(player);
    }
}
