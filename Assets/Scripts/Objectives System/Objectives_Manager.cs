using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Objectives_Manager : MonoBehaviour
{
    [SerializeField]
    private Queue<Objective> objectives;

    [SerializeField]
    private Objective currentObjective;

    [SerializeField]
    private TextMeshProUGUI progress;

    [SerializeField]
    private TextMeshProUGUI reward;

    private void Awake()
    {
        objectives = new Queue<Objective>();
    }
}
