using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestExterminate : MonoBehaviour
{
    [SerializeField]
    private PestControlSystem pestcontrol;

    // Start is called before the first frame update
    void Start()
    {
        pestcontrol = FindObjectOfType<PestControlSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PestExec"))
        {
            pestcontrol.StopTimer();
        }
    }
}
