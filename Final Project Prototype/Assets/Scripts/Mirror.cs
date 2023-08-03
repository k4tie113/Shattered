using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Interactable
{
    public float xChange, yChange, zChange;
    GUIStyle guiStyle;
    bool moved = false;
    public override void Interact()
    {
        guiStyle = FontManager.guiStyle;
    }
    
    public override void OnGUI(){
        base.OnGUI();
        if(invoking && !moved && GUIManager.keyEnabled) GUI.Label(new Rect (25,Screen.height*0.8f,200,50), "[E] to move",guiStyle);
    }
    void Update()
    {
        if(GUIManager.keyEnabled) displayMsg = "this must be the mirror mom shattered";
        if(invoking && !moved && GUIManager.keyEnabled && Input.GetKeyDown(KeyCode.E))
        {
            transform.position += new Vector3(xChange, yChange, zChange);
            moved = true;
        }
    }
}
