using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI_Controllerller : MonoBehaviour
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

    public void NewGame()
    {
        ES3.DeleteFile();

        // TODO: implement the transition to the main game scene
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        // TODO: Transition to the main game
        SceneManager.LoadScene(1);
    }
}
