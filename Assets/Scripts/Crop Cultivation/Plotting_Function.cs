using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlottingFunction : MonoBehaviour
{
    [SerializeField]
    private GameObject plottedLand;
    [SerializeField]
    private AudioClip Plotting;
    [SerializeField]
    private AudioClip PlottingDone;

    private int hitCount = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rake"))
        {
            hitCount++;

            AudioSource.PlayClipAtPoint(Plotting, this.gameObject.transform.position);

            // when the counter hits 3, instantiate the ploted land then destroy the unploted land
            if (hitCount >= 3)
            {
                AudioSource.PlayClipAtPoint(PlottingDone, this.gameObject.transform.position);

                Instantiate(plottedLand, plottedLand.transform.position = gameObject.transform.position, plottedLand.transform.rotation = gameObject.transform.rotation);

                plottedLand.transform.localScale = gameObject.transform.localScale;

                Destroy(gameObject);
            }
        }
    }
}
