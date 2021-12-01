using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFaldoni : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
      this.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward, Camera.main.transform.up);
            
    }
}
