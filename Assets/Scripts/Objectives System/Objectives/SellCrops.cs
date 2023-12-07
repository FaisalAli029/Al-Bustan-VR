using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellCrops : Objective
{
    [ES3Serializable]
    private int goal;
    [ES3Serializable]
    private int cropsSold;
    [ES3Serializable]
    private int reward;

    public SellCrops(int cropsNeeded, int reward)
    {
        this.goal = cropsNeeded;

        this.reward = reward;
    }

    public override bool IsCompleted()
    {
        return cropsSold >= goal;
    }

    public override string GetTitle()
    {
        return "Sell a total of " + goal + " crops";
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
        return goal.ToString();
    }

    public void OnCropSell(int totelSold)
    {
        if (Objectives_Manager.currentObjective is SellCrops)
        {
            Debug.Log("SellCrop");

            cropsSold = totelSold;

            if (IsCompleted())
            {
                coinSystem.Coins += reward;

                Complete();
            }
        }
    }
}
