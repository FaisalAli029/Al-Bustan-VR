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

    // on trigger, add the crop's price that was put in the box to the total earning
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

    // when player removes crop from the box, the price of it is removed from the total
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
