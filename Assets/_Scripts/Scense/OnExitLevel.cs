using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnExitLevel : MonoBehaviour
{
    [SerializeField] private Transform player; //drag player reference onto here
    private Vector3 targetPosition;

    [SerializeField]
    private string nameScenes;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded; //You add your method to the delegate
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }
    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
      
    }
}
