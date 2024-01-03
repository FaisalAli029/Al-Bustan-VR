using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sell_Shop : MonoBehaviour
{
    [SerializeField]
    private Coin_Collector collector;

    [SerializeField]
    private Coin_System coinSystem;

    [SerializeField]
    private UnlockManager unlockManager;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private AudioClip successSound;

    [SerializeField]
    private AudioClip failureSound;

    private void Awake()
    {
        coinSystem = FindObjectOfType<Coin_System>();

        unlockManager = FindObjectOfType<UnlockManager>();
    }

    private void OnEnable()
    {
        Coin_Collector.CoinsChangedEvent += UpdateCoinCounter;
    }

    private void OnDisable()
    {
        Coin_Collector.CoinsChangedEvent -= UpdateCoinCounter;
    }

    public void SellCrops()
    {
        if (collector.TotalCoins > 0)
        {
            coinSystem.Coins += collector.TotalCoins;

            collector.TotalCoins = 0;

            UpdateCoinCounter();

            foreach (GameObject crop in collector.Crops)
            {
                CropCarrior carrior = crop.GetComponent<CropCarrior>();

                unlockManager.IncrementUnlocks(carrior.crop);

                Destroy(crop);
            }

            if (Objectives_Manager.currentObjective != null)
            {
                SellCrops objective = (SellCrops)Objectives_Manager.currentObjective;
                objective.OnCropSell(collector.Crops.Count);
            }

            collector.Crops.Clear();

            AudioSource.PlayClipAtPoint(successSound, this.gameObject.transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(failureSound, this.gameObject.transform.position);
        }
    }

    private void UpdateCoinCounter()
    {
        text.SetText(collector.TotalCoins.ToString());
    }
}
