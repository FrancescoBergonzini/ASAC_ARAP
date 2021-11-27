using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class IntroCanvasController : MonoBehaviour
{
    //
    ARTrackedImageManager _trackedManager;
    //
    [SerializeField] Animator scanAnimat;
    //
    [SerializeField] Text debugtext;

    private void Awake()
    {
        _trackedManager = FindObjectOfType<ARTrackedImageManager>();
    }

    #region subscrive event
    private void OnEnable()
    {
        //rileva l'evento di intercettamento dell'immagine
        _trackedManager.trackedImagesChanged += ChangePrefabOnImage;
    }


    private void OnDisable()
    {
        _trackedManager.trackedImagesChanged -= ChangePrefabOnImage;
    }

    #endregion

    private void ChangePrefabOnImage(ARTrackedImagesChangedEventArgs images)
    {
        foreach (ARTrackedImage image in images.added)
        {
            //attiva solo quando sei in mod scan
            if (image.referenceImage.name == "QR_Code")
            {
                //attiva animazione scan
                scanAnimat.SetTrigger("Scan");
                debugtext.text = "Animazione in corso";
            }
        }

    }
}
