using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DentedPixel;
using System;

public class PestControlSystem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> plottedLands;

    [SerializeField]
    private GameObject selectedPlot;

    [SerializeField]
    private float timerDuration;

    [SerializeField]
    private GameObject barUI;

    [SerializeField]
    private GameObject bar;

    [SerializeField]
    private GameObject unplottedLand;

    [SerializeField]
    private AudioClip startSound;

    [SerializeField]
    private AudioClip witheredSound;

    private TimeManager timeManager;

    private bool eventFired;

    private int? id;

    private GameObject currentBarUI;

    private void Awake()
    {
        timeManager = FindObjectOfType<TimeManager>();

        eventFired = false;
    }

    private void Update()
    {
        CheckPestStart();
    }

    // starts and spawn the timer bar for the event
    private void StartTimer()
    {
        if (selectedPlot != null)
        {
            AudioSource.PlayClipAtPoint(startSound, this.gameObject.transform.position);

            currentBarUI = Instantiate(barUI, selectedPlot.transform);

            bar = GameObject.Find("Bar");

            id = LeanTween.scaleX(bar, 1, timerDuration).setOnComplete(DestroyPlot).id;
        }
    }

    // select a random plot from the list
    private void SelectRandomPlot()
    {
        if (plottedLands.Count != 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, plottedLands.Count);

            selectedPlot = plottedLands[randomIndex];
        }
    }

    // retives all eligable plots from the scene
    private void getPlots()
    {
        plottedLands = GameObject.FindGameObjectsWithTag("Growing").ToList();
    }

    // ensures that the event is fired based on the time that was set
    private void CheckPestStart()
    {
        if (timeManager.CurrentTime.TimeOfDay <= timeManager.PestSpawnTime.Add(TimeSpan.FromMinutes(1)) && timeManager.CurrentTime.TimeOfDay >= timeManager.PestSpawnTime)
        {
            if (!eventFired)
            {
                getPlots();
                SelectRandomPlot();
                StartTimer();

                eventFired = true;
            }
        }
        else
        {
            eventFired = false;
        }
    }

    // stop the timer if the player exterminates the pests
    public void StopTimer()
    {
        if (id != null)
        {
            LeanTween.cancel(id.Value);

            id = null;

            Destroy(currentBarUI);
        }
    }

    // destroys the crops when the timer reachs the end
    private void DestroyPlot()
    {
        AudioSource.PlayClipAtPoint(witheredSound, this.gameObject.transform.position);

        Instantiate(unplottedLand, selectedPlot.transform.position, selectedPlot.transform.rotation);

        Destroy(selectedPlot);
    }
}
