using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HandMenu_UI : MonoBehaviour
{
    [SerializeField]
    private Button MainMenu;

    [SerializeField]
    private TextMeshProUGUI coinsText;

    [SerializeField]
    private TextMeshProUGUI timeText;

    private Coin_System coinSystem;

    private TimeManager timeManager;

    private void Awake()
    {
        coinSystem = FindObjectOfType<Coin_System>();

        timeManager = FindObjectOfType<TimeManager>();

        MainMenu.onClick.AddListener(GoToMainMwnu);
    }

    private void Update()
    {
        coinsText.SetText("Coins: " + coinSystem.Coins);

        timeText.SetText(timeManager.CurrentTime.ToShortTimeString());
    }

    private void GoToMainMwnu()
    {
        SceneManager.LoadScene(0);
    }
}
