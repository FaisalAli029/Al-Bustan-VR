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
    public static Objective currentObjective;

    [SerializeField]
    private TextMeshProUGUI progress;

    [SerializeField]
    private TextMeshProUGUI reward;

    [SerializeField]
    private TextMeshProUGUI title;

    private void Awake()
    {
        objectives = new Queue<Objective>();
        TimeManager.OnSunrise += AddObjectives;
    }

    private void OnDestroy()
    {
        TimeManager.OnSunrise -= AddObjectives;
    }

    private void AddObjectives()
    {
        int[] goalRanges = new int[] {25, 50};
        int goalSelectedIndex = Random.Range(0, goalRanges.Length);
        int goalSelected = goalRanges[goalSelectedIndex];

        int reward = goalSelected * 2;

        objectives.Enqueue(new SellCrops(goalSelected, reward));

        Debug.Log(objectives.Count);
    }

    private void Update()
    {
        if (currentObjective == null && objectives.Count > 0)
        {
            currentObjective = objectives.Dequeue();
            title.SetText(currentObjective.GetTitle());
            reward.SetText("$" + currentObjective.GetReward());
            currentObjective.OnCompleted += () => currentObjective = null;
        }

        if (currentObjective != null)
        {
            progress.SetText(currentObjective.GetProgress() + " / " + currentObjective.GetGoal());
        }
        else
        {
            title.SetText("No Active Objectives");
            progress.SetText("");
            reward.SetText("");
        }
    }
}
