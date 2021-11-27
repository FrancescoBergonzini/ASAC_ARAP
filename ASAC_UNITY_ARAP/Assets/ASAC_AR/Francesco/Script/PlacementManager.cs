using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementManager : MonoBehaviour
{

    [SerializeField] GameObject pointerObJ;
    [SerializeField] GameObject objectToSpawn;

    GameObject scatolaInScena;

    ARRaycastManager _rayManager;
    ARSessionOrigin _Arorigin;
    ARPlaneManager planeManager;
    Pose posePlacement;
    bool validPosePlacement;
    bool placed = false;

    private void Awake()
    {
        _rayManager = FindObjectOfType<ARRaycastManager>();
        _Arorigin = FindObjectOfType<ARSessionOrigin>();
        planeManager = FindObjectOfType<ARPlaneManager>();
    }

    private void Update()
    {
        UpdatePlacement();
        
        UpdatePlacementPose();
        if (scatolaInScena != null)
        {
            if ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                scatolaInScena.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Open");
            }
        }
        if(validPosePlacement && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }

    void UpdatePlacement()
    {
        var screenCentre = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        _rayManager.Raycast(screenCentre, hits, TrackableType.Planes);

        validPosePlacement = hits.Count > 0;

        if (validPosePlacement)
        {
            posePlacement = hits[0].pose;
            var cameraForward = Camera.current.transform.forward;

            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z);
            posePlacement.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    void UpdatePlacementPose()
    {
        if (validPosePlacement)
        {
            pointerObJ.SetActive(true);
            pointerObJ.transform.SetPositionAndRotation(posePlacement.position, posePlacement.rotation);
        }
        else
        {
            pointerObJ.SetActive(false);
        }
    }

    void PlaceObject()
    {                                                      //rotazione di pose anche
        scatolaInScena=Instantiate(objectToSpawn, posePlacement.position, posePlacement.rotation);
        DeactiveARPlane();

    }

    public void DeactiveARPlane()
    {
        //deactive
        foreach (var plane in planeManager.trackables)
        {
            //plane.gameObject.SetActive(false);
            Destroy(plane.gameObject);
        }
        planeManager.enabled = false;

        pointerObJ.SetActive(false);
        this.gameObject.SetActive(false);
    }

}
