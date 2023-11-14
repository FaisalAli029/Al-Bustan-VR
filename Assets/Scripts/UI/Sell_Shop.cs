using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sell_Shop : MonoBehaviour
{
    [SerializeField]
    private CropSeedData seed;

    [SerializeField]
    private GameObject seedSpawn;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();

        text.SetText(seed.seedName + " " + seed.price + "$");
    }

    // TODO: Add the method to spawn the seed if the player has enough coins

    // TODO: Add a method to check if the player has enough coins
}
