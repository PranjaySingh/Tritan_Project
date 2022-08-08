using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public GameObject gameOverUI;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameOverUI.SetActive(true);
            Destroy(other.gameObject, 2.0f);
        }
    }
}
