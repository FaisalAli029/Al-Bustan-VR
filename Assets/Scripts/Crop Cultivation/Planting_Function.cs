using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Unity.XR.CoreUtils;
using UnityEngine;

public class PlantingFunction : MonoBehaviour
{
    // list of the spawn points where the crops will be planted
    [SerializeField]
    private List<GameObject> spawnPoints;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Seeds"))
        {
            // gettes the component that has the scriptable object related to the seed
            CropSeedCarrior carrior = collision.gameObject.GetComponent<CropSeedCarrior>();

            if (carrior != null && carrior.cropSeedData != null && carrior.cropSeedData.cropToPlant != null)
            {
                foreach (GameObject spawn in spawnPoints)
                {
                    // spawn the crops on each spawn point inside the parent of this game object
                    GameObject crop = Instantiate(carrior.cropSeedData.cropToPlant, spawn.transform.position, spawn.transform.rotation, transform);

                    crop.transform.localScale = carrior.cropSeedData.initCropScale;
                }
            }

            // destroy the seed after finishing planting
            Destroy(collision.gameObject);
        }
    }
}
