using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    GameObject spawner;

    [SerializeField] private float rotateSpeed = 200f;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        spawner = GameObject.Find("Collectible Spawner");
        //Usually I hate to use GameObject.Find(), but in this case, Collectible is instantiated in run time and There are relatively small amount of onjects in Hierarchy so it is feasible for now.
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);                   //Rotates the stars along Y-axis
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))                                         //Player Collision Check
        {
            audioSource.Play();
            Debug.Log("Collision");
            if (spawner == null)
            {
                spawner = GameObject.Find("Collectible Spawner");               //Again, I hate to do this normally. 
            }
            spawner.GetComponent<Spawner>().score++;                            //Increment the score
            Destroy(this.gameObject, 0.1f);                                     //Collectible is destroyed on collision
        }
    }
}
