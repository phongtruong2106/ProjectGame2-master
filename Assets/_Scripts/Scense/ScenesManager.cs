using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public string sceneName;
    public bool isNextScene = true;

    [SerializeField]
    public SceneInfor sceneInfor;

    private void OnTriggerEnter2D(Collider2D player)
    {
        sceneInfor.isNextScene = isNextScene;
        SceneManager.LoadScene(sceneName);
    }

}
