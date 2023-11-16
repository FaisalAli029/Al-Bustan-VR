using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Buy_Shop : MonoBehaviour
{
    [SerializeField]
    private CropSeedData seed;

    [SerializeField]
    private GameObject seedSpawn;

    [SerializeField]
    private Coin_System coinSystem;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();

        text.SetText(seed.seedName + " " + seed.price + "$");

        coinSystem = FindObjectOfType<Coin_System>();
    }

    // TODO: Add the method to spawn the seed if the player has enough coins
    public void SpawnSeed()
    {
        if (CheckCoins())
        {
            Instantiate(seed.Seed, seedSpawn.transform.position, seedSpawn.transform.rotation);

            if (coinSystem != null) { coinSystem.Coins -= seed.price; }

            // TODO: add a audiable que for successfull purchase
        }
        else
        {
            // TODO: add a audiable que for unsuccessfull purchase
        }
    }

    private bool CheckCoins()
    {
        if (coinSystem != null)
        {
            if (coinSystem.Coins > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
