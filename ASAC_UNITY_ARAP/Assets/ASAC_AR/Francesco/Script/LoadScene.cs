using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    //[SerializeField] IntroCanvasController introref;
    public void GotoSceneScatola()
    {
        //chiama on disable altro script
        //introref.enabled = false;
        SceneManager.LoadScene(1);
    }

    
}
