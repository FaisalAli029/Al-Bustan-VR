using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDestroyed : MonoBehaviour 
{
	public string guid = System.Guid.NewGuid().ToString();
    static bool isApplicationQuitting = false;

	private bool isDestroyed = false;

	void Start () 
	{
		if (ES3.KeyExists(guid) && !isDestroyed)
		{
			Destroy(this.gameObject);

			guid = System.Guid.NewGuid().ToString();

			isDestroyed = true;
		}
	}

	void OnDestroy()
	{
        if (gameObject.scene.isLoaded && !isApplicationQuitting)
            ES3.Save<bool>(guid, true);
	}

    void OnApplicationQuit()
    {
        isApplicationQuitting = true;
    }
}
