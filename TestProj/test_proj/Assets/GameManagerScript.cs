using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject stickPreFab, stonePreFab, player;
    public Vector2 SpawnBoundsX, SpawnBoundsZ;

    //global upgrades
    int timeIncreasePurchaseAmount = 0; 
    //stick upgrades
    int stickPickupIncreasePurchaseAmount = 0;
    //stone upgrades
    bool stonesUnlocked = false;
    int stonePickupIncreasePurchaseAmount = 0;



    float timeNow = 0f, timeMaxDefault = 60f, timeIncreaseUpgrade = 10f;
    int sticks = 0, spendingSticks = 0,
        stones = 0, spendingStones = 0;
    public TextMeshProUGUI stickText, stoneText, time;
    // Start is called before the first frame update
    void Start()
    {
        newSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeNow += Time.deltaTime;
        if(timeNow > timeMaxDefault)// + (timeIncreaseUpgrade * timeIncreasePurchaseAmount) )
        {
            player.GetComponent<PlayerControlsScript>().playGame = false;
            player.GetComponent<PlayerControlsScript>().shopping = true;
            time.text = "Time Left: 0.00s";
            spendingSticks += sticks;
            spendingStones += stones;
        }
        else
        {
            time.text = "Time Left: " + (timeMaxDefault - timeNow).ToString("F2");
        }
    }

    public void newSpawn()
    {
        if (stonesUnlocked)
        {
            float rng = Random.value;
            if(rng >= 0.5f)
                Instantiate(stickPreFab, new Vector3(Random.Range(SpawnBoundsX.x, SpawnBoundsX.y), 0f, Random.Range(SpawnBoundsZ.x, SpawnBoundsZ.y)), Quaternion.Euler(90, 0, Random.Range(0, 360)));
            else
                Instantiate(stonePreFab, new Vector3(Random.Range(SpawnBoundsX.x, SpawnBoundsX.y), 0f, Random.Range(SpawnBoundsZ.x, SpawnBoundsZ.y)), Quaternion.Euler(90, 0, Random.Range(0, 360)));

        }
        else
        {
            Instantiate(stickPreFab, new Vector3(Random.Range(SpawnBoundsX.x, SpawnBoundsX.y), 0f, Random.Range(SpawnBoundsZ.x, SpawnBoundsZ.y)), Quaternion.Euler(90, 0, Random.Range(0, 360)));
        }
    }

    public void collectedStick()
    {
        sticks += (1 + (stickPickupIncreasePurchaseAmount));
        stickText.text = "Sticks Collected: " + sticks;
    }
    public void collectedStone()
    {
        stones += (1 + (stonePickupIncreasePurchaseAmount));
        stoneText.text = "Stones Collected: " + stones;
    }
    
}
