using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin_System : MonoBehaviour
{
    [SerializeField]
    private int coins;

    [SerializeField]
    private const int MAX_COINS = 999;

    [SerializeField]
    private const int START_COINS = 0;

    public int Coins
    {
        get => coins;
        set
        {
            coins = Mathf.Clamp(value, 0, MAX_COINS);
        }
    }

    // if avalible, restores coins from local storage
    private void Awake()
    {
        if (ES3.FileExists() && ES3.KeyExists("Coins"))
        {
            Coins = ES3.Load<int>("Coins");
        }
        else
        {
            Coins = START_COINS;
        }
    }

    private void OnValidate() => Coins = coins;
}
