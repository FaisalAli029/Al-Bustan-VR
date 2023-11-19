using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objective
{
    public abstract bool IsAchived();
    public abstract void Complete();
    public abstract void DrawObjectiveUI();
}
