using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementManager : MonoBehaviour
{

    [SerializeField] GameObject pointerObJ;
    [SerializeField] GameObject objectToSpawn;

    ARRaycastManager _rayManager;
    ARSessionOrigin _Arorigin;
    Pose posePlacement;
    bool validPosePlacement;

    private void Awake()
    {
        _rayManager = FindObjectOfType<ARRaycastManager>();
        _Arorigin = FindObjectOfType<ARSessionOrigin>();
    }

    private void Update()
    {
        UpdatePlacement();
        UpdatePlacementPose();
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

}
