using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
        //Ho inserito una variabile nel codice originale per tener conto di quale sia la slider attiva
    public SliderMenu sliderMenu;


    private void Update()
    {
        //Controllo che la slide attiva abbia il component button attivato mentre le altre no
        foreach(var slide in sliderMenu.Slides)
        {
            if (slide == sliderMenu.slideAttiva)
            {
                slide.GetComponent<Button>().enabled = true;
            }
            else
            {
                slide.GetComponent<Button>().enabled = false;
            }
        }

        
    }


    // Metodo per stampare un valore a schermo
    public void StampaValore(int i)
    {
        Debug.Log(i);
    }
}
