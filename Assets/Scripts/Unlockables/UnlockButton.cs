using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockButton : MonoBehaviour
{
    [SerializeField]
    private CropData crop;

    [SerializeField]
    private TextMeshProUGUI counter;

    private UnityEngine.UI.Button button;

    private UnlockManager unlockManager;

    private void Awake()
    {
        unlockManager = FindObjectOfType<UnlockManager>();

        button = GetComponent<UnityEngine.UI.Button>();
    }

    private void Update()
    {
        if (unlockManager.CheckCropUnlock(crop))
        {
            button.interactable = true;

            counter.SetText(unlockManager.InfoUnlockCounter[crop].ToString() + "/" + unlockManager.TotalNeeded);
        }
    }
}
