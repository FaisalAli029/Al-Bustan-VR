using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin_System : MonoBehaviour
{
    [SerializeField]
    private int coins;

    public int Coins
    {
        get => coins;
        set => coins = Mathf.Clamp(value, 0, coins);
    }

    private void OnValidate() => Coins = coins;
}
