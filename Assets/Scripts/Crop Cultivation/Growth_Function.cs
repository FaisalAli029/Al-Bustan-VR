using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth_Function : MonoBehaviour
{
    private CropData cropData;

    private bool isWatered = false;
    private bool isSunrise = false;

    private int growthCounter = 0;

    public static event Action CropGrowEvent;

    private void Awake()
    {
        cropData = GetComponent<CropCarrior>().crop;

        Debug.Log("awaken");
    }

    private void OnEnable()
    {
        Watering_Function.OnWateredEvent += OnWatered;
        TimeManager.OnSunrise += OnSunrise;

        Debug.Log("awaken");
    }

    private void OnDisable()
    {
        Watering_Function.OnWateredEvent -= OnWatered;
        TimeManager.OnSunrise -= OnSunrise;
    }

    private void OnWatered()
    {
        isWatered = true;
        CheckGrowth();

        Debug.Log("watered");
    }

    private void OnSunrise()
    {
        isSunrise = true;
        CheckGrowth();

        Debug.Log("it is sunrise");
    }

    private void CheckGrowth()
    {
        if (isWatered && isSunrise && growthCounter < cropData.growthTime)
        {
            gameObject.transform.localScale += cropData.growthScale;

            growthCounter++;

            isWatered = false;
            isSunrise = false;

            CropGrowEvent.Invoke();
        }

        Debug.Log("checked");
    }
}
