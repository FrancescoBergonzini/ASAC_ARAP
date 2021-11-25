using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatolaNera_Behaviour : MonoBehaviour
{
    //
    Animator faldoni_anim;

    private void Awake()
    {
       faldoni_anim = this.gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //qua metti input swipe
        if (Input.GetKeyDown(KeyCode.S))
        {
            faldoni_anim.SetTrigger("LestSwipe");
        }
    }
}
