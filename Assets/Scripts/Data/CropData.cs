using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "Crop/New Crop")] 
public class CropData : ScriptableObject
{
    public string cropName;
    public Vector3 growthScale;
    public int growthTime;
    public int yield;
    public int sellPrice;
}
