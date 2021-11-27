using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //public Text outputText;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;
    private bool isSwitching=false;

    public float swipeRange;
    public float tapRange;

    Animator faldoni_anim;

    //public GameObject caroselloDocumenti;


    private void Awake()
    {
        faldoni_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            Swipe();
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

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
                    
                    faldoni_anim.SetTrigger("LestSwipe");
                    isSwitching = true;
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    
                    //faldoni_anim.SetTrigger("LestSwipe");
                    stopTouch = true;
                }

            }

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                
                //caroselloDocumenti.SetActive(!caroselloDocumenti.activeSelf);
                //isSwitching = !isSwitching;
            }

        }

    }
        public void ChangeSwitchState()
        {
            isSwitching = false;
        }
}
