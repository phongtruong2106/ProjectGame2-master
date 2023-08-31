using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{

    public static SpawnPlayers Instance;
    public GameObject playerPrefab;
    public CameraManage cameraManager;

    public VectorValue vectorValue;

    private void Start()
    {
        Vector2 radomPosition = vectorValue.initialValue;
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, radomPosition, Quaternion.identity);
        cameraManager.SetPlayerTarget(player);
    }
}
    