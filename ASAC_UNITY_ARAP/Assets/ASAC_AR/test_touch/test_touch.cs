using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
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
