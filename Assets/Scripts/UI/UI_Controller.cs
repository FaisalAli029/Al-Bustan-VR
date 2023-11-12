using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private GameObject optionsMenu;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionsToMain()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void MainToOptions()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
