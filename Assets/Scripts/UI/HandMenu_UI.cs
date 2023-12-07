using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HandMenu_UI : MonoBehaviour
{
    [SerializeField]
    private Button mainMenu;

    [SerializeField]
    private Button save;

    [SerializeField]
    private TextMeshProUGUI coinsText;

    [SerializeField]
    private TextMeshProUGUI timeText;

    private SaveLoadSystem saveLoadSystem;

    private Coin_System coinSystem;

    private TimeManager timeManager;

    private void Awake()
    {
        coinSystem = FindObjectOfType<Coin_System>();

        timeManager = FindObjectOfType<TimeManager>();

        saveLoadSystem = FindObjectOfType<SaveLoadSystem>();

        mainMenu.onClick.AddListener(GoToMainMwnu);

        save.onClick.AddListener(SaveGame);
    }

    private void Update()
    {
        coinsText.SetText("Coins: " + coinSystem.Coins);

        timeText.SetText(timeManager.CurrentTime.ToShortTimeString());
    }

    private void GoToMainMwnu()
    {
        saveLoadSystem.Save();

        ES3AutoSaveMgr.Current.Save();

        SceneManager.LoadScene(0);
    }

    private void SaveGame() => saveLoadSystem.Save();
}
