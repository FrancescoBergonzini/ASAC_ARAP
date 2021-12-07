using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //public Text outputText;

    private Vector2 startTouchPosition, currentPosition, endTouchPosition;
    private bool stopTouch = false, isSwitching=false;

    public float swipeRange, tapRange;

    Animator faldoni_anim;

    public GameObject caroselloDocumenti;
    UIManager _uiManager;

    //
    public List<Animator> AnimatoriAperturaFaldoni;
    int contatore = 0;
    bool apriono;

    //
    private Button _bottoneSpegniCarosello;


    private void Awake()
    {
        faldoni_anim = GetComponent<Animator>();
        caroselloDocumenti = GameObject.Find("CaroselloDocumenti");
        _uiManager = GameObject.Find("Manager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
        Touch();
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position; //posizione iniziale
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            //tipo di swipe
            if (!stopTouch)
            {

                if (Distance.x < -swipeRange)
                {
                    //faldoni_anim.SetTrigger("LestSwipe");
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    
                    //faldoni_anim.SetTrigger("LestSwipe");
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange && !isSwitching)
                {
                    //qua verso alto
                    faldoni_anim.SetTrigger("LestSwipe");
                    isSwitching = true;
                    stopTouch = true;

                    //
                    contatore++;
                    if(contatore > 3)
                    {
                        contatore = 0;
                    }
                }
                else if (Distance.y < -swipeRange)
                {
                    
                    //faldoni_anim.SetTrigger("LestSwipe");
                    stopTouch = true;
                }

            }

        }    
    }

    public void Touch()
    {
        //metodi touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                if (apriono)
                    return;
                //premuto apriono diventa vero
                AttivaCarosello();

            }

        }
    }

    private void AttivaCarosello()
    {
        //attivare il trigger nell'animazione
        AnimatoriAperturaFaldoni[contatore].SetTrigger("Apertura");

        //da sistemare
        AccendiOSpegniCarosello(apriono);
        //
        Invoke("AssegnaBottoneDiSpegnimento", 2f);
    }

    private void AssegnaBottoneDiSpegnimento()
    {
        if (!apriono)
            return;
        //
        var objButtone = GameObject.FindGameObjectWithTag("SpegniCar");
        _bottoneSpegniCarosello = objButtone.GetComponent<Button>();
        _bottoneSpegniCarosello.onClick.AddListener(SpegniCarosello);
    }

    private void SpegniCarosello()
    {
        //attivare il trigger nell'animazione
        AnimatoriAperturaFaldoni[contatore].SetTrigger("Apertura");

        //da sistemare
        AccendiOSpegniCarosello(apriono);

        var objButtone = GameObject.FindGameObjectWithTag("SpegniCar");
        _bottoneSpegniCarosello = objButtone.GetComponent<Button>();
        _bottoneSpegniCarosello.onClick.RemoveAllListeners();
    }

    private void AccendiOSpegniCarosello(bool apri)
    {
        float tempo;
        tempo = (apri == false ? 1.5f : 0.1f);  

        Invoke("ApriCaroselloDocumenti", tempo);
        
    }

    private void ApriCaroselloDocumenti()
    {
        //apro il carosello e setto le dimensioni in base alla lista di documenti del fascicolo premuto
        _uiManager.ApriCaroselloDocumentiRelativo(contatore);
        //qua attivo carosello quando finisce animazione
        caroselloDocumenti.transform.GetChild(0).gameObject.SetActive(!caroselloDocumenti.transform.GetChild(0).gameObject.activeSelf);


        isSwitching = !isSwitching;

        apriono = !apriono;
    }

    public void ChangeSwitchState()
        {
            isSwitching = false;
        }
}
