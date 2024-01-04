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

    [SerializeField]
    private AudioClip successSound;

    [SerializeField]
    private AudioClip failureSound;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();

        text.SetText(seed.seedName + " " + seed.price + "$");

        coinSystem = FindObjectOfType<Coin_System>();
    }

    // spawn a seed when the button is clicked and the player has enough coins
    public void SpawnSeed()
    {
        if (CheckCoins())
        {
            Debug.Log("Activated");

            Instantiate(seed.Seed, seedSpawn.transform.position, seedSpawn.transform.rotation);

            if (coinSystem != null) { coinSystem.Coins -= seed.price; }

            AudioSource.PlayClipAtPoint(successSound, this.gameObject.transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(failureSound, this.gameObject.transform.position);
        }
    }

    // checks if the player has enough coins
    private bool CheckCoins()
    {
        if (coinSystem != null)
        {
            if (coinSystem.Coins >= seed.price)
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
