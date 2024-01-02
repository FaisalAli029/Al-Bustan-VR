using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioSources;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SwitchAudioBasedOnScene();
    }

    void SwitchAudioBasedOnScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current Scene Index: " + currentSceneIndex);

        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].enabled = (i == currentSceneIndex);
            Debug.Log("AudioSource " + i + ": " + audioSources[i].enabled);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
