using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Seed", menuName = "Crop/New Seed")]
public class CropSeedData : ScriptableObject
{
    public string seedName;
    public int price;

    public GameObject cropToPlant;
}
