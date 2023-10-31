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
        _OriginalMat = GetComponentInChildren<Renderer>().material;
    }

    private void OnEnable()
    {
        Growth_Function.CropGrowEvent += ResetMaterial;
    }

    private void OnDisable()
    {
        Growth_Function.CropGrowEvent -= ResetMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
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
