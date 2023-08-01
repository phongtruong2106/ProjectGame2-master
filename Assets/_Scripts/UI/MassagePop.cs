using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassagePop : MonoBehaviour
{
    [SerializeField] private GameObject MessageBox;

    private void Start()
    {
        MessageBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            MessageBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            MessageBox.SetActive(false);
        }
    }
}
