using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : Interactable
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
        if(invoking) GUI.Label(new Rect (25,Screen.height*0.8f,200,50), "[E] to move",guiStyle);
    }
    void Update()
    {
        if(invoking && !moved && Input.GetKeyDown(KeyCode.E))
        {
            transform.position += new Vector3(xChange, yChange, zChange);
            moved = true;
        }
    }
}
