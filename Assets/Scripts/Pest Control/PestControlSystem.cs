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

    private void StartTimer()
    {
        if (selectedPlot != null)
        {
            currentBarUI = Instantiate(barUI, selectedPlot.transform);

            bar = GameObject.Find("Bar");

            id = LeanTween.scaleX(bar, 1, timerDuration).setOnComplete(DestroyPlot).id;
        }
    }

    private void SelectRandomPlot()
    {
        if (plottedLands.Count != 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, plottedLands.Count);

            selectedPlot = plottedLands[randomIndex];
        }
    }

    private void getPlots()
    {
        plottedLands = GameObject.FindGameObjectsWithTag("Growing").ToList();
    }

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

    public void StopTimer()
    {
        if (id != null)
        {
            LeanTween.cancel(id.Value);

            id = null;

            Destroy(currentBarUI);
        }
    }

    private void DestroyPlot()
    {
        Instantiate(unplottedLand, selectedPlot.transform.position, selectedPlot.transform.rotation);

        Destroy(selectedPlot);
    }
}
