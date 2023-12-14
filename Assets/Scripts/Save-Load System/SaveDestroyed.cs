using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDestroyedSeed : MonoBehaviour
{
    public string guid;

    private static bool isApplicationQuiting = false;

    private void Start()
    {
        // Generate a new GUID if not assigned
        if (string.IsNullOrEmpty(guid))
            guid = System.Guid.NewGuid().ToString();

        if (ES3.KeyExists(guid))
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        if (!Application.isPlaying) return;

        if (gameObject.scene.isLoaded && !isApplicationQuiting)
            ES3.Save(guid, true);
    }

    private void OnApplicationQuit()
    {
        isApplicationQuiting = true;
    }
}

