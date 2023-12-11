using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDestroyed : MonoBehaviour
{
    [ES3Serializable]
    public string guid;

    static bool isApplicationQuitting = false;
    static List<string> guids = new List<string>();

    private void Awake()
    {
        guid = System.Guid.NewGuid().ToString();
        guids.Add(guid);
    }

    private void Start()
    {
        if (ES3.KeyExists(guid))
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded && !isApplicationQuitting)
            ES3.Save(guid, true);
    }

    private void OnApplicationQuit()
    {
        isApplicationQuitting = true;
    }
}

