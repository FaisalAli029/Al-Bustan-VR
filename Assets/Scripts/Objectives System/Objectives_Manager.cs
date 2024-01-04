using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

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

    [SerializeField]
    private AudioClip completed;

    public Queue<Objective> Objectives { get { return objectives; } }

    /* at script awakening, checks if any objectives are stored in storage.
     * if so, the data is retreived and stored in the queue.
     * if not, then default values are instead added.
     */
    private void Awake()
    {
        if (ES3.FileExists() && ES3.KeyExists("Objectives") && ES3.KeyExists("Objective"))
        {
            objectives = ES3.Load<Queue<Objective>>("Objectives");

            currentObjective = ES3.Load<Objective>("Objective");
        }
        else
        {
            objectives = new Queue<Objective>();

            currentObjective = null;
        }

        TimeManager.OnSunrise += AddObjectives;

        // Debug.Log(currentObjective);
    }

    private void OnDestroy()
    {
        TimeManager.OnSunrise -= AddObjectives;
    }

    // randomly gnerate objectives when event is invoked
    private void AddObjectives()
    {
        int[] goalRanges = new int[] {5, 10};
        int goalSelectedIndex = Random.Range(0, goalRanges.Length);
        int goalSelected = goalRanges[goalSelectedIndex];

        int reward = goalSelected * 2;

        objectives.Enqueue(new SellCrops(goalSelected, reward));

        // Debug.Log(objectives.Count);
    }

    private void Update()
    {
        // if no objective is active, one is retrived from the queue
        if (currentObjective == null && objectives.Count > 0)
        {
            currentObjective = objectives.Dequeue();
            currentObjective.OnCompleted += () => AudioSource.PlayClipAtPoint(completed, this.gameObject.transform.position);
            currentObjective.OnCompleted += () => currentObjective = null;
        }
        // updated the UI based on the current objective status
        if (currentObjective != null)
        {
            title.SetText(currentObjective.GetTitle());
            reward.SetText("$" + currentObjective.GetReward());
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
