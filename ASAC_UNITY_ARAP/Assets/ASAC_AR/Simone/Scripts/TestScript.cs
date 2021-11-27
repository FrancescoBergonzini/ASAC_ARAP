using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
        //Ho inserito una variabile nel codice originale per tener conto di quale sia la slider attiva
    public SliderMenu sliderMenu;
    [SerializeField] Text debugText_up;
    [SerializeField] Text debugText_down;

    private void Update()
    {
        //Controllo che la slide attiva abbia il component button attivato mentre le altre no
        foreach(var slide in sliderMenu.Slides)
        {
            if (slide == sliderMenu.slideAttiva)
            {
                slide.GetComponent<Button>().enabled = true;
                ChangeText(slide);

                
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

    public void GotoScene(int scena)
    {
        SceneManager.LoadScene(scena);
    }

    private void ChangeText(GameObject slider)
    {
        debugText_up.text = $"{slider.gameObject.name}_testo in alto";
        debugText_down.text = $"{slider.gameObject.name}_testo in basso";
    }

}
