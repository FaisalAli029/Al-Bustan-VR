using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Watering_Function : MonoBehaviour
{
    public event Action OnWateredEvent;

    [SerializeField]
    private Material _WateredPlot;

    private Material _OriginalMat;

    // TODO: Implemet a particale system that simulates the water coming out the watering can

    private void Awake()
    {
        _OriginalMat = GetComponentInChildren<Renderer>().material;
    }

    private void OnEnable()
    {
        Growth_Function.ResetPlotEvent += ResetMaterial;
    }

    private void OnDisable()
    {
        Growth_Function.ResetPlotEvent -= ResetMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO: make it so there is a delay to the trigger to simulate watering

        if (other.gameObject.CompareTag("WateringCan"))
        {
            gameObject.GetComponentInChildren<Renderer>().material = _WateredPlot;

            OnWateredEvent?.Invoke();
        }
    }

    private void ResetMaterial()
    {
        gameObject.GetComponentInChildren<Renderer>().material = _OriginalMat;
    }
}
