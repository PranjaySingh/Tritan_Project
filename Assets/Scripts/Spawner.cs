using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject collectible;
    public Transform plane;
    public TMP_Text scoreText;

    float xSize;
    float zSize;

    bool isSpawning;
    public int score;

    private void Awake()
    {
        score = 0;
    }

    private void Start()
    {
        xSize = plane.localScale.x;
        zSize = plane.localScale.z;

        isSpawning = false;
    }

    void Update()
    {
        if (!isSpawning)
        {
            Invoke("SpawnCollectible", 3.0f);
            isSpawning = true;
        }

        scoreText.text = score.ToString();
    }

    void SpawnCollectible()
    {
        Vector3 newRandomPosition = new Vector3(Random.Range(-xSize * 4, xSize * 4),
                                                transform.position.y,
                                                Random.Range(-zSize * 4 , zSize * 4));

        Instantiate(collectible, newRandomPosition, gameObject.transform.rotation);

        isSpawning = false;
    }
}
