using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject stickPreFab, stonePreFab, player, shopUI;
    
    public Vector2 SpawnBoundsX, SpawnBoundsZ;
    [HideInInspector]
    public bool collecting = true, shopping = false;

    //global upgrades
    [HideInInspector]
    public int timeIncreasePurchaseAmount = 0, timeIncreaseCost = 5, winGameCost = 250, winGamePurchased = 0, speedIncreaseCost = 10, moveFasterPurchaseTimes = 0;
    [HideInInspector]
    public float baseMoveSpeed = 2f, moveSpeedIncrease = 0.5f, moveSpeed;
    //stick upgrades
    [HideInInspector]
    public int stickPickupIncreasePurchaseAmount = 0, pickupMoreStickCost = 25;
    //stone upgrades
    [HideInInspector]
    public bool stonesUnlocked = false;
    [HideInInspector]
    public int stonePickupIncreasePurchaseAmount = 0, unlockStonesCost = 10, pickupMoreStoneCost = 25;


    [HideInInspector]
    public float timeNow = 0f, timeMaxDefault = 20f, timeIncreaseUpgrade = 10f;
    [HideInInspector]
    public int 
        sticks = 0, spendingSticks = 50,
        stones = 0, spendingStones = 50;
    public TextMeshProUGUI stickText, stoneText, time;
    // Start is called before the first frame update
    void Start()
    {
        newSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (collecting)
        {
            timeNow += Time.deltaTime;
            moveSpeed = baseMoveSpeed + (moveSpeedIncrease * moveFasterPurchaseTimes);
        }

        if (timeNow > timeMaxDefault + (timeIncreaseUpgrade * timeIncreasePurchaseAmount))
        {
            if (!shopping)
            {
                collecting = false;
                shopping = true;
                time.text = "Time Left: 0.00s";
                spendingSticks += sticks;
                spendingStones += stones;
                updateSticksAndStones();
            }
        }
        else
        {
            time.text = "Time Left: " + ((timeMaxDefault + (timeIncreaseUpgrade * timeIncreasePurchaseAmount)) - timeNow).ToString("F2");
        }
        shopUI.SetActive(shopping);
    }

    public void newSpawn()
    {
        if (stonesUnlocked)
        {
            float rng = Random.value;
            if (rng >= 0.5f)
                Instantiate(stickPreFab, new Vector3(Random.Range(SpawnBoundsX.x, SpawnBoundsX.y), 0f, Random.Range(SpawnBoundsZ.x, SpawnBoundsZ.y)), Quaternion.Euler(90, 0, Random.Range(0, 360)));
            else
            {
                GameObject obj = Instantiate(stonePreFab, new Vector3(Random.Range(SpawnBoundsX.x, SpawnBoundsX.y), 0f, Random.Range(SpawnBoundsZ.x, SpawnBoundsZ.y)), Quaternion.Euler(90, 0, Random.Range(0, 360)));
                float scale = Random.Range(0.1f, 0.7f);
                obj.transform.localScale = new Vector3(scale, scale, scale);
                obj.GetComponent<SphereCollider>().radius = scale;
            }

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

    public void updateSticksAndStones()
    {
        stickText.text = "Spending Sticks: " + spendingSticks;
        stoneText.text = "Spending Stones: " + spendingStones;
    }
}
