using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Seed", menuName = "Crop/New Seed")]
public class CropSeedData : ScriptableObject
{
    public string seedName;
    public int price;
    public Vector3 initCropScale;

    public GameObject cropToPlant;
    public GameObject Seed;
}
