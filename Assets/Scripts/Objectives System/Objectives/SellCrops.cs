using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellCrops : Objective
{
    private int cropsNeeded;
    private int cropsSold;
    private int reward;

    public SellCrops(int cropsNeeded, int reward)
    {
        this.cropsNeeded = cropsNeeded;

        this.reward = reward;
    }

    public override bool IsCompleted()
    {
        return cropsSold >= cropsNeeded;
    }

    public override string GetTitle()
    {
        return "Sell a total of " + cropsNeeded;
    }

    public override string GetReward()
    {
        return reward.ToString();
    }

    public override string GetProgress()
    {
        return cropsSold.ToString();
    }

    public override string GetGoal()
    {
        return cropsNeeded.ToString();
    }

    public void OnCropSell(int totelSold)
    {
        if (Objectives_Manager.currentObjective is SellCrops)
        {
            cropsSold = totelSold;

            if (IsCompleted())
            {
                coinSystem.Coins += reward;

                Complete();
            }
        }
    }
}
