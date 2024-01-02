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
    private Image cropLabel;

    [SerializeField]
    private TextMeshProUGUI cropDesc;

    public void DisplayInfo(CropInfo info)
    {
        if (gameObject.activeSelf != true)
        {
            gameObject.SetActive(true);
        }

        cropImage.sprite = info.cropImage;
        cropLabel.sprite = info.cropLabel;
        cropDesc.SetText(info.description);
    }
}
