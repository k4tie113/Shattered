using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightFollow : MonoBehaviour
{
    public GameObject flashlight;

    //public AudioSource turnOn;
    //public AudioSource turnOff;

    public bool state;
    GUIStyle style;



    void Start()
    {
        style = FontManager.guiStyle;
        state = false;
        flashlight.SetActive(state);
    }

    void OnGUI()
    {
        if(!GUIManager.actionsEnabled) return;
        GUI.Label(new Rect (Screen.width * 0.7f,Screen.height*0.1f,200,50), "[F] to toggle Flashlight",style);
    }


    void Update()
    {
        if(!GUIManager.actionsEnabled) return;
        if(Input.GetKeyDown(KeyCode.F))
        {
            state = !state;
            flashlight.SetActive(state);
            
        }
        
    }
}