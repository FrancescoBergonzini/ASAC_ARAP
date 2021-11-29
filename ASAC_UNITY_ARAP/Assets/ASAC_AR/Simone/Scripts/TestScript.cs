using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestiDescrizioneScatole
{
    public const string t1_sopra = "Esposizione internazionale d’arte del 1895. Lavoro preliminare - 1893-1895";
    public const string t1_sotto = "Fascicoli: 22\n Documenti: 189";

    public const string t2_sopra = "Esposizione internazionale d’arte del 1895. Corrispondenza (P-Z) - spedizioni - 1894-1895";
    public const string t2_sotto = "Fascicoli: 11\n Documenti: 94";

    public const string t3_sopra = "Esposizione internazionale d’arte del 1895. Premi - Vendite - Assicurazioni - Spedizioni - Pubblicità - 1894-1896";
    public const string t3_sotto = "Fascicoli: 10n Documenti: 86";

    public const string t4_sopra = "4444444";
    public const string t4_sotto = "Fascicoli: 22\n Documenti: 189";

    public const string t5_sopra = "555555";
    public const string t5_sotto = "Fascicoli: 22\n Documenti: 189";
}

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
        switch (slider.name)
        {
            case "b. 001": debugText_up.text = TestiDescrizioneScatole.t1_sopra;
                           debugText_down.text = TestiDescrizioneScatole.t1_sotto;
                break;
            case "b. 002": debugText_up.text = TestiDescrizioneScatole.t2_sopra;
                           debugText_down.text = TestiDescrizioneScatole.t2_sotto;
                break;
            case "b. 003": debugText_up.text = TestiDescrizioneScatole.t3_sopra;
                           debugText_down.text = TestiDescrizioneScatole.t3_sotto;
                break;
            case "b. 004": debugText_up.text = TestiDescrizioneScatole.t4_sopra;
                           debugText_down.text = TestiDescrizioneScatole.t4_sotto;
                break;
            case "b. 005": debugText_up.text = TestiDescrizioneScatole.t5_sopra;
                          debugText_down.text = TestiDescrizioneScatole.t5_sotto;
                break;
        }
    }

}
