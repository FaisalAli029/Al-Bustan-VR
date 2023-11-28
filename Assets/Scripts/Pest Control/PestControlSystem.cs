using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PestControlSystem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> plottedLands;

    [SerializeField]
    private GameObject selectedPlot;

    private TimeManager timeManager;

    private void Awake()
    {
        timeManager = FindObjectOfType<TimeManager>();
    }

    public void getPlots()
    {
        plottedLands = GameObject.FindGameObjectsWithTag("Growing").ToList();
    }
}
