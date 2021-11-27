using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AperturaScript : MonoBehaviour
{
    [SerializeField] GameObject faldoni;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFaldoniAnim()
    {
        faldoni.GetComponent<Animator>().SetTrigger("AlzaFaldoni");
        faldoni.GetComponent<Player>().enabled = true;
    }
}
