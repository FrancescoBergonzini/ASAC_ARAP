using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Pulsanti")]
    [SerializeField] GameObject _carosello;
    [SerializeField] GameObject _backTocarosello;
    [SerializeField] GameObject _reset;
    [SerializeField] GameObject _indicator;

    //
    [SerializeField] PlacementManager _placeScatolaManager;
    [SerializeField] ARPlaneManager planeManager;


    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PremoCarosello()
    {
        //spendo il carosello
        _carosello.SetActive(false);
        _backTocarosello.SetActive(true);

        //attivo parte in AR
        ActiveARPlane();

    }

    //NON FUNZIONA
    public void PremoBackToCarosello()
    {
        //spengo parte in Ar
        _placeScatolaManager.DeactiveARPlane();

        //torno al corosello
        _backTocarosello.SetActive(false);
        _carosello.SetActive(true);
        _indicator.SetActive(false);
    }


    public void ActiveARPlane()
    {
        _indicator.SetActive(true);
        planeManager.enabled = true;
        _placeScatolaManager.gameObject.SetActive(true);
    }
}
