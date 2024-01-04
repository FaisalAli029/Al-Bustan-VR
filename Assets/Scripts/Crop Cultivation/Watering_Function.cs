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

    private void Awake()
    {
        // store the original material for later use
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
        // change plot material to simulate watering
        if (other.gameObject.CompareTag("WateringCan"))
        {
            gameObject.GetComponentInChildren<Renderer>().material = _WateredPlot;

            OnWateredEvent?.Invoke();
        }
    }

    // reset material back to normal
    private void ResetMaterial()
    {
        gameObject.GetComponentInChildren<Renderer>().material = _OriginalMat;
    }
}
