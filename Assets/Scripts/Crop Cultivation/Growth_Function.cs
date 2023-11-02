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

    private CropData cropData;

    private bool isWatered = false;
    private bool isSunrise = false;

    private int growthCounter = 0;

    private Watering_Function wateringFunction;

    public static event Action ResetPlotEvent;

    private Grabbable grabbable;

    private void Awake()
    {
        cropData = GetComponent<CropCarrior>().crop;

        grabbable = GetComponent<Grabbable>();

        wateringFunction = GetComponentInParent<Watering_Function>();

        Debug.Log("awaken");
    }

    private void OnEnable()
    {
        wateringFunction.OnWateredEvent += OnWatered;

        TimeManager.OnSunrise += OnSunrise;

        Debug.Log("awaken");
    }

    private void OnDisable()
    {
        wateringFunction.OnWateredEvent -= OnWatered;

        TimeManager.OnSunrise -= OnSunrise;
    }

    private void OnWatered()
    {
        isWatered = true;

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

            ResetPlotEvent.Invoke();
        }
        else if (growthCounter == cropData.growthTime)
        {
            GameObject grabbleCrop = Instantiate(cropData.grabbleCrop, gameObject.transform.position, gameObject.transform.rotation);

            grabbleCrop.transform.localScale = gameObject.transform.localScale;

            transform.parent.parent.AddComponent<Unplotting_Function>().unplottedLand = this.unplottedLand;

            Destroy(gameObject);
        }

        Debug.Log("checked");
    }
}