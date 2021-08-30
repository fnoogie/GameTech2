using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject collectablePreFab;
    public Vector2 SpawnBoundsX, SpawnBoundsZ;

    int score = 0;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        newSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newSpawn()
    {
        Instantiate(collectablePreFab, new Vector3(Random.Range(SpawnBoundsX.x, SpawnBoundsX.y), 0f, Random.Range(SpawnBoundsZ.x, SpawnBoundsZ.y)), Quaternion.Euler(90,0,Random.Range(0,360)));
    }

    public void collected()
    {
        score++;
        text.text = "Total Collected: " + score;
    }
}
