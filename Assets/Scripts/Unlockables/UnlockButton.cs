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

    [SerializeField]
    private TextMeshProUGUI label;

    [SerializeField]
    private InfoDisplay display;

    private UnityEngine.UI.Button button;

    private UnlockManager unlockManager;

    private void Awake()
    {
        unlockManager = FindObjectOfType<UnlockManager>();

        display = FindObjectOfType<InfoDisplay>(true);

        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(DisplayInfoButton);

        label.SetText(crop.cropName);
    }

    // this method checks the button should be unlocked or not
    private void Update()
    {
        if (unlockManager.CheckCropUnlock(crop))
        {
            button.interactable = true;
        }

        if (unlockManager.InfoUnlockCounter.ContainsKey(crop))
        {
            counter.SetText(unlockManager.InfoUnlockCounter[crop].ToString() + " / " + unlockManager.TotalNeeded);
        }
        else
        {
            counter.SetText("0 / " + unlockManager.TotalNeeded);
        }
    }

    // display the info when button is clicked
    private void DisplayInfoButton()
    {
        display.DisplayInfo(crop.cropInfo);
    }
}
