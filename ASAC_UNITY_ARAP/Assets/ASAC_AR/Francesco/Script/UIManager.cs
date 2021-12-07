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
    [SerializeField] GameObject _carosello;
    [SerializeField] GameObject _backTocarosello;
    [SerializeField] GameObject _reset;
    [SerializeField] GameObject _indicator;
    [SerializeField] GameObject docNonDisponibile;

    //
    [SerializeField] PlacementManager _placeScatolaManager;
    [SerializeField] ARPlaneManager planeManager;
    [SerializeField] SliderMenu _sliderMenu;


    [SerializeField] Text testoSalvataggio;
    [SerializeField] Transform backgroundTesto;

    public List<GameObject> lista1, lista2;

    float ammount;
    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    public void PremoCarosello()
    {
        //spenmo il carosello
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
        backgroundTesto.LeanMove(new Vector3((Screen.width * 65 / 100),testoSalvataggio.transform.position.y), 1).setEaseOutQuart().setOnComplete(TestoBackPosition);
    }

    private void TestoBackPosition()
    {
        LeanTween.scale(backgroundTesto.gameObject, Vector3.one * ammount, 1).setEasePunch();
        backgroundTesto.LeanMove(new Vector3( (Screen.width * 135 / 100), testoSalvataggio.transform.position.y), 1).setEaseInOutQuart().delay = 0.5f;
    }

    public void ApriCaroselloDocumentiRelativo(int numeroFascicolo)
    {
        //ripulire la lista di tutte le slides e accenderle tutte
        _sliderMenu.Slides.Clear();
        docNonDisponibile.SetActive(false);
        foreach (GameObject doc in lista1)
        {
            doc.SetActive(true);
        }
        foreach (GameObject doc in lista2)
        {
            doc.SetActive(true);
        }


        //in base a cosa viene premuto si aggiunge una lista o l'altra
        switch (numeroFascicolo)
        {
            case 0:
                foreach(GameObject doc in lista1)
                {
                    _sliderMenu.Slides.Add(doc);
                }
                foreach (GameObject doc in lista2)
                {
                    doc.SetActive(false);
                }
                break;
            case 1:
                foreach (GameObject doc in lista2)
                {
                    _sliderMenu.Slides.Add(doc);
                }
                foreach (GameObject doc in lista1)
                {
                    doc.SetActive(false);
                }
                break;
            default:
                docNonDisponibile.SetActive(true);
                foreach (GameObject doc in lista1)
                {
                    doc.SetActive(false);
                }
                foreach (GameObject doc in lista2)
                {
                    doc.SetActive(false);
                }
                break;
        }

        //spegnere le slide non utilizzate

    }

    public void SpegniDocNonDisp()
    {
        Invoke("SpegniImage", 0.4f);
    }
    void SpegniImage()
    {
        docNonDisponibile.SetActive(false);
    }
}
