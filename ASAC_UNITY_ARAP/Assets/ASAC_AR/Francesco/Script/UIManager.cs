using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    [Header("Pulsanti")]
    [SerializeField] GameObject _caroselloDocumenti;
    [SerializeField] GameObject _backTocarosello;
    [SerializeField] GameObject _reset;
    [SerializeField] GameObject _indicator;

    //
    [SerializeField] PlacementManager _placeScatolaManager;
    [SerializeField] ARPlaneManager planeManager;

    [SerializeField] Text testoSalvataggio;
    [SerializeField] Transform backgroundTesto;

    float ammount;
    public void ResetScene()
    {
        
        if (_caroselloDocumenti.activeSelf)
        {
            _caroselloDocumenti.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }

    public void PremoCarosello()
    {
        //spendo il carosello
        _caroselloDocumenti.SetActive(false);
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
        _caroselloDocumenti.SetActive(true);
        _indicator.SetActive(false);
    }


    public void ActiveARPlane()
    {
        _indicator.SetActive(true);
        planeManager.enabled = true;
        _placeScatolaManager.gameObject.SetActive(true);
    }


    public void SalvaDocumento(GameObject bottone)
    {
        if (bottone.GetComponent<Image>().color == Color.green)
        {
            testoSalvataggio.text = "Documento non salvato";
            bottone.GetComponent<Image>().color = Color.white;
        }
        else
        {
            testoSalvataggio.text = "Documento salvato";
            bottone.GetComponent<Image>().color = Color.green;
        }
        ammount = bottone.GetComponent<Image>().color == Color.green ? 1.1f : 0.9f;
        backgroundTesto.LeanMove(new Vector3(testoSalvataggio.transform.position.x, (Screen.height * 90 / 100)), 1).setEaseOutQuart().setOnComplete(TestoBackPosition);
    }

    private void TestoBackPosition()
    {
        LeanTween.scale(backgroundTesto.gameObject, Vector3.one * ammount, 1).setEasePunch();
        backgroundTesto.LeanMove(new Vector3(testoSalvataggio.transform.position.x, (Screen.height * 110 / 100)), 1).setEaseInOutQuart().delay = 0.5f;
    }
}
