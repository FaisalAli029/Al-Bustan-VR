using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objective
{
    public event Action OnCompleted;

    public abstract bool IsCompleted();

    public abstract string GetProgress();

    public abstract string GetReward();

    public abstract string GetTitle();

    public abstract string GetGoal();

    protected void Complete()
    {
        OnCompleted?.Invoke();
    }
}
