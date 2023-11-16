using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin_Collector : MonoBehaviour
{
    [SerializeField]
    private int totalCoins;

    [SerializeField]
    private CropCarrior crop;

    public int TotalCoins { get; }

    private void OnTriggerEnter(Collider other)
    {
        crop = other.GetComponent<CropCarrior>();

        totalCoins += crop.crop.sellPrice;
    }

    private void OnTriggerExit(Collider other)
    {
        totalCoins -= crop.crop.sellPrice;
    }
}
