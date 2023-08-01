using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public float msgTimer = 3f;
    public bool hasInteracted;
    public bool isInteracting;
    public bool canDisplayText;
    public bool invoking;
    public bool tooFar;
    public string displayMsg;
    private GUIStyle textStyle;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        invoking = false;
        tooFar = false;
        hasInteracted = false;
        canDisplayText = false;
        textStyle = new GUIStyle();
		textStyle.fontSize = 16;
		textStyle.fontStyle = FontStyle.Italic;
		textStyle.normal.textColor = Color.yellow;
    }
    public void hit(Transform playerPOS)
    {
        if(GUIManager.isInteracting) return;
        player = playerPOS;
        tooFar = false;
        float distance = Vector3.Distance(player.position, transform.position);
        if(!canDisplayText) canDisplayText = true;
        
        if(distance>radius)
        {
            if(!invoking){ 
                Invoke("TextCooldown", 1f);
                GUIManager.isInteracting = true;
                invoking = true;
            }
            tooFar = true;
        }
        else
        {
            if(!invoking){
                Invoke("TextCooldown", msgTimer);
                GUIManager.isInteracting = true;
                invoking = true;
            }
            Interact();
            hasInteracted = true;
        }

    }

    public virtual void Interact()
    {
        //Debug.Log("interacting with "+transform.name);
    }

    void OnGUI()
    {
        if(!canDisplayText) return;
        if(tooFar)
        {
            GUI.Label(new Rect (50,Screen.height - 50,200,50), "walk closer to interact",textStyle);
        }
        else
        {
            GUI.Label(new Rect (50,Screen.height - 50,200,50), displayMsg,textStyle);
        }
    }
    void TextCooldown()
    {
        invoking = false;
        canDisplayText = false;
        GUIManager.isInteracting = false;
        isInteracting = false;
    }

    
}
