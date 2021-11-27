using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScatolaInScena : MonoBehaviour
{
    public GameObject activeBox;
    bool aperta = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activeBox != null && !aperta)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                activeBox.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Open");
                aperta = true;
            }
        }
    }
}
