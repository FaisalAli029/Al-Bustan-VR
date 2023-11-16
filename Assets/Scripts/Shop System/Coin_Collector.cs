using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Coin_Collector : MonoBehaviour
{
    [SerializeField]
    private int totalCoins;

    public static event Action CoinsChangedEvent;

    private List<GameObject> crops = new List<GameObject>();

    public List<GameObject> Crops { get => crops; }

    public int TotalCoins { get => totalCoins; set => totalCoins = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crop") && !crops.Contains(other.gameObject))
        {
            CropCarrior crop = other.gameObject.GetComponent<CropCarrior>();

            totalCoins += crop.crop.sellPrice;

            CoinsChangedEvent?.Invoke();

            crops.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (crops.Contains(other.gameObject))
        {
            CropCarrior crop = other.gameObject.GetComponent<CropCarrior>();

            totalCoins -= crop.crop.sellPrice;

            CoinsChangedEvent?.Invoke();

            crops.Remove(other.gameObject);
        }
    }
}
