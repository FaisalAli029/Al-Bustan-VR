using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private string saveKey;

    // Start is called before the first frame update
    void Awake()
    {
        if (!ES3.KeyExists("menuAudio"))
        {
            ES3.Save<float>("menuAudio", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        audioSource.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = ES3.Load<float>(saveKey);

        // Optionally, set the initial volume of the associated AudioSource
        if (audioSource != null)
        {
            audioSource.volume = volumeSlider.value;
        }
    }

    private void Save()
    {
        ES3.Save<float>(saveKey, volumeSlider.value);
    }
}
