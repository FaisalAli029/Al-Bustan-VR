using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unplotting_Function : MonoBehaviour
{
    [SerializeField]
    public GameObject unplottedLand;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crop") && !isTriggered)
        {
            ResetPolt();

            isTriggered = true;
        }
    }

    public void ResetPolt()
    {
        Instantiate(unplottedLand, gameObject.transform.position, gameObject.transform.rotation);

        Destroy(gameObject);
    }
}
