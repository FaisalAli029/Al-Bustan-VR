using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Watering_Function : MonoBehaviour
{
    public static event Action OnWateredEvent;

    [SerializeField]
    private Material _WateredPlot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WateringCan"))
        {
            gameObject.GetComponentInChildren<Renderer>().material = _WateredPlot;

            OnWateredEvent?.Invoke();
        }
    }
}
