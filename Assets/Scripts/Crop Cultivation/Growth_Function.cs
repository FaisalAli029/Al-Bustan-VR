using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using Unity.VisualScripting;

public class Growth_Function : MonoBehaviour
{
    [SerializeField]
    private GameObject unplottedLand;

    // get the script from local plot
    [ES3Serializable, SerializeField]
    private Watering_Function wateringFunction;

    private CropData cropData;

    private bool isWatered = false;
    private bool isSunrise = false;

    private int growthCounter = 0;

    public static event Action ResetPlotEvent;

    private void Awake()
    {
        cropData = GetComponent<CropCarrior>().crop;
    }

    private void Start()
    {
        wateringFunction = GetComponentInParent<Watering_Function>();

        // ensure that the script is not empty before subscribing to it
        if (wateringFunction != null)
            wateringFunction.OnWateredEvent += OnWatered;
    }

    private void OnEnable()
    {
        TimeManager.OnSunrise += OnSunrise;
    }

    private void OnDisable()
    {
        if (wateringFunction != null)
            wateringFunction.OnWateredEvent -= OnWatered;

        TimeManager.OnSunrise -= OnSunrise;
    }

    // watered when event is invoked
    private void OnWatered()
    {
        isWatered = true;
    }

    // changes to true and triggers the check of crop's growth
    private void OnSunrise()
    {
        isSunrise = true;
        CheckGrowth();
    }

    /*
     * this method first checks if all conditions are meat for growth
     * if so the scale of the crop incremented.
     * when the crop reaches maturity, a grabble version of the crops are created.
     * the plot return to a "Unplotted" state.
     */
    private void CheckGrowth()
    {
        if (isWatered && isSunrise && growthCounter < cropData.growthTime)
        {
            gameObject.transform.localScale += cropData.growthScale;

            growthCounter++;

            isWatered = false;
            isSunrise = false;

            ResetPlotEvent.Invoke();
        }
        else if (growthCounter == cropData.growthTime)
        {
            GameObject grabbleCrop = Instantiate(cropData.grabbleCrop, gameObject.transform.position, gameObject.transform.rotation);

            grabbleCrop.transform.localScale = gameObject.transform.localScale;

            if (transform.parent.parent.GetComponent<Unplotting_Function>() == null)
                transform.parent.parent.AddComponent<Unplotting_Function>().unplottedLand = this.unplottedLand;

            Destroy(gameObject);
        }
    }
}
