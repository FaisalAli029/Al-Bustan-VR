using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingFunction : MonoBehaviour
{
    private static void OnTriggerEnter(Collider other)
    {
        CropSeedData CropToGrow = other.gameObject.GetComponent<CropSeedData>();


    }
}
