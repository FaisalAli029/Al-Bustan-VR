using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop Info", menuName = "Crop/New Crop Info")]
public class CropInfo : ScriptableObject
{
    public Sprite cropImage;
    public string description;
}
