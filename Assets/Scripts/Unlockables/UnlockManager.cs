using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    private Dictionary<CropData, int> infoUnlockCounter;

    public Dictionary<CropData, int> InfoUnlockCounter { get { return infoUnlockCounter; } }

    private void Awake()
    {
        infoUnlockCounter = new Dictionary<CropData, int>();
    }
}
