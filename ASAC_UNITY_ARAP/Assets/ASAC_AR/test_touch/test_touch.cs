using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class test_touch : MonoBehaviour
{
    [SerializeField] Button test_button;
    public Text text_1, text2;

    int contatoreUI, contatoreSchermo;

    private void Update()
    {
        CheckTouchSchermo();   
    }

    void CheckTouchSchermo()
    {
        var tocco = Input.GetTouch(0);
        
        if (Input.touchCount > 0 && tocco.phase == TouchPhase.Began)
        {
            int id = tocco.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                return;
            }

            //
            contatoreSchermo++;
            text2.text = $"Contatore schermo: {contatoreSchermo}";
        }
    }

    public void BottoneAumenta()
    {
        contatoreUI++;
        text_1.text = $"Contatore UI: {contatoreUI}";
    }
}
