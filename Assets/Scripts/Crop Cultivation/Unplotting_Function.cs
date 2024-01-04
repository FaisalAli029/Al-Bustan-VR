using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unplotting_Function : MonoBehaviour
{
    [SerializeField]
    public GameObject unplottedLand;

    private bool isTriggered = false;

    // when triggered, reset the plot back to a "Unplotted" state
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crop") && !isTriggered)
        {
            ResetPolt();

            // ensures that the trigger is only executed once
            isTriggered = true;
        }
    }

    public void ResetPolt()
    {
        Instantiate(unplottedLand, gameObject.transform.position, gameObject.transform.rotation);

        Destroy(gameObject);
    }
}
