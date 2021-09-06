using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonFunctionsScript : MonoBehaviour
{
    GameManagerScript GM;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void purchaseIncreaseTimeStick()
    {
        if (GM.spendingSticks >= GM.timeIncreaseCost)
        {
            GM.spendingSticks -= GM.timeIncreaseCost;
            GM.timeIncreasePurchaseAmount++;
            text.text = "Times Purchased: " + GM.timeIncreasePurchaseAmount;
            GM.updateSticksAndStones();
        }
    }

    public void moveFaster()
    {
        if (GM.spendingStones >= GM.speedIncreaseCost)
        {
            GM.spendingStones -= GM.speedIncreaseCost;
            GM.moveFasterPurchaseTimes++;
            text.text = "Times Purchased: " + GM.moveFasterPurchaseTimes;
            GM.updateSticksAndStones();
        }
    }

    public void unlockStones()
    {
        if(GM.spendingSticks >= GM.unlockStonesCost && !GM.stonesUnlocked)
        {
            GM.spendingSticks -= GM.unlockStonesCost;
            GM.stonesUnlocked = true;
            text.text = "Times Purchased: 1";
            GM.updateSticksAndStones();
        }
    }

    public void winGame()
    {
        if(GM.spendingStones >= GM.winGameCost)
        {
            text.text = "Times Purchased: " + GM.winGamePurchased;
            GM.updateSticksAndStones();
        }
    }

    public void pickupMoreSticks()
    {
        if (GM.spendingStones >= GM.pickupMoreStickCost)
        {
            GM.spendingStones -= GM.pickupMoreStickCost;
            GM.stickPickupIncreasePurchaseAmount++;
            text.text = "Times Purchased: " + GM.stickPickupIncreasePurchaseAmount;
            GM.updateSticksAndStones();
        }
    }

    public void pickupMoreStones()
    {
        if (GM.spendingSticks >= GM.pickupMoreStoneCost)
        {
            GM.spendingSticks -= GM.pickupMoreStoneCost;
            GM.stonePickupIncreasePurchaseAmount++;
            text.text = "Times Purchased: " + GM.stonePickupIncreasePurchaseAmount;
            GM.updateSticksAndStones();
        }
    }


    public void relaunchGame()
    {
        GM.collecting = true;
        GM.shopping = false;
        GM.timeNow = 0.0f;
        GM.stickText.text = "Sticks Collected: 0";
        GM.stoneText.text = "Stones Collected: 0";
        GM.sticks = 0;
        GM.stones = 0;
    }
}