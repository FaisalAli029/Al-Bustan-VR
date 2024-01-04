using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestExterminate : MonoBehaviour
{
    [SerializeField]
    private PestControlSystem pestcontrol;

    [SerializeField]
    private AudioClip successSound;

    // Start is called before the first frame update
    void Start()
    {
        pestcontrol = FindObjectOfType<PestControlSystem>();
    }

    // when triggered, stops the timer and destroys the timer bar
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PestExec"))
        {
            AudioSource.PlayClipAtPoint(successSound, this.gameObject.transform.position);

            pestcontrol.StopTimer();
        }
    }
}
