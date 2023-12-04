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

    private void Awake()
    {
        infoUnlockCounter = new Dictionary<CropData, int>();
    }

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
