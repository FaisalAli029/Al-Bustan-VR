using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    [SerializeField]
    private int totalNeeded;

    private Dictionary<CropData, int> infoUnlockCounter;

    public Dictionary<CropData, int> InfoUnlockCounter { get { return infoUnlockCounter; } }

    public int TotalNeeded { get { return totalNeeded; } }

    // retrives unlockable's progress from local stroage if exists
    private void Awake()
    {
        if (ES3.FileExists() && ES3.KeyExists("Unlockables"))
        {
            infoUnlockCounter = ES3.Load<Dictionary<CropData, int>>("Unlockables");
        }
        else
        {
            infoUnlockCounter = new Dictionary<CropData, int>();
        }
    }

    // this method increments the progress of unlockables based on crops given
    public void IncrementUnlocks(CropData crop)
    {
        if (infoUnlockCounter.ContainsKey(crop))
        {
            infoUnlockCounter[crop]++;
        }
        else
        {
            infoUnlockCounter.Add(crop, 1);
        }
    }

    // checks if the unlockable is unlocked
    public bool CheckCropUnlock(CropData crop)
    {
        if (infoUnlockCounter.ContainsKey(crop))
        {
            if (infoUnlockCounter[crop] >= totalNeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
