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

    //scanok
    bool scanView;
    [SerializeField] GameObject scannerobj, buttonCarosello, buttonScan;

    ARTrackedImage salvaimage;

    private void Awake()
    {
        _trackedManager = FindObjectOfType<ARTrackedImageManager>();
    }
    private void Start()
    {
        var initialScan = new Vector3(Screen.width *150/100, Screen.height * 50 / 100);
        var initialCarosello = new Vector3(Screen.width * (-50) / 100, Screen.height * 15 / 100);
        buttonScan.transform.position = initialScan;
        buttonCarosello.transform.position = initialCarosello;
        var destinationScan = new Vector3(Screen.width / 2, buttonScan.transform.position.y);
        var destinationCarosello = new Vector3(Screen.width / 2, buttonCarosello.transform.position.y);
        LeanTween.move(buttonScan, destinationScan, 2).setEaseOutQuart().setEaseOutBack().delay=0.5f;
        LeanTween.move(buttonCarosello, destinationCarosello, 2).setEaseOutQuart().setEaseOutBack().delay=0.5f;
    }

    #region subscrive event
    private void OnEnable()
    {
        //rileva l'evento di intercettamento dell'immagine
        _trackedManager.trackedImagesChanged += ChangePrefabOnImage;
    }

    private void Update()
    {
        if (scanView && scannerobj.activeSelf == true)
        {
            //attiva animazione scan
            scanAnimat.SetTrigger("Scan");
        }
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
                scanView = true;

                images.updated.Clear();
                images.added.Clear();
                images.removed.Clear();

                //_trackedManager.enabled = false;
                //Destroy(_trackedManager.gameObject);
                
            }
        }

    }

   


}
