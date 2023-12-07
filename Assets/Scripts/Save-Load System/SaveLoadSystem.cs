using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    [SerializeField]
    private Coin_System coin;

    [SerializeField]
    private Objectives_Manager objectives;

    [SerializeField]
    private UnlockManager unlocker;

    [SerializeField]
    private TimeManager time;

    public void Save()
    {
        ES3.Save("Coins", coin.Coins);
        ES3.Save("Objectives", objectives.Objectives);
        ES3.Save("Objective", Objectives_Manager.currentObjective);
        ES3.Save("Unlockables", unlocker.InfoUnlockCounter);
        ES3.Save("currentTime", time.CurrentTime);
    }
}
