using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoDisplay : MonoBehaviour
{
    [SerializeField]
    private Image cropImage;

    [SerializeField]
    private TextMeshProUGUI cropDesc;

    [SerializeField]
    private UnityEngine.UI.Button close;

    public void DisplayInfo(CropInfo info)
    {
        if (gameObject.activeSelf != true)
        {
            gameObject.SetActive(true);
        }

        cropImage.sprite = info.cropImage;
        cropDesc.SetText(info.description);
    }
}
