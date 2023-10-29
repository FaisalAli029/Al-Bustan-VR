using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Unity.XR.CoreUtils;
using UnityEngine;

public class PlantingFunction : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> spawnPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Seeds"))
        {
            CropSeedCarrior carrior = other.gameObject.GetComponent<CropSeedCarrior>();

            if (carrior != null && carrior.cropSeedData != null && carrior.cropSeedData.cropToPlant != null)
            {
                foreach (GameObject spawn in spawnPoints)
                {
                    GameObject crop = Instantiate(carrior.cropSeedData.cropToPlant, spawn.transform.position, spawn.transform.rotation);
                    crop.transform.localScale = carrior.cropSeedData.initCropScale;
                }
            }

            Destroy(other.gameObject);
        }
    }
}
