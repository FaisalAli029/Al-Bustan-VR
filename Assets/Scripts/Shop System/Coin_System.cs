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

    public int Coins
    {
        get => coins;
        set
        {
            coins = Mathf.Clamp(value, 0, MAX_COINS);
        }
    }

    private void OnValidate() => Coins = coins;
}
