using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner Instance;
    public GameObject[] playerPrefabs;
    public VectorValue vectorValue;
    public CameraManage cameraManager;

    private void Start()
    {
        Vector2 radomPosition = vectorValue.initialValue;
        GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        GameObject player = PhotonNetwork.Instantiate(playerToSpawn.name, radomPosition, Quaternion.identity);
        cameraManager.SetPlayerTarget(player);
    }
}
