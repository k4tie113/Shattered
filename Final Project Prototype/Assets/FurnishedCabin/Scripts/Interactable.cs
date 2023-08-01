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
    public bool tooFar;
    public string displayMsg;
    private GUIStyle textStyle;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        tooFar = false;
        hasInteracted = false;
        canDisplayText = false;
        displayMsg = "Interacting";
        textStyle = new GUIStyle();
		textStyle.fontSize = 16;
		textStyle.fontStyle = FontStyle.Italic;
		textStyle.normal.textColor = Color.yellow;
    }
    public void hit(Transform playerPOS)
    {
        player = playerPOS;
        tooFar = false;
        float distance = Vector3.Distance(player.position, transform.position);
        if(!canDisplayText) canDisplayText = true;
        Debug.Log(canDisplayText);
        if(distance>radius)
        {
            Invoke("TextCooldown", 1f);
            tooFar = true;
        }
        else
        {
            Invoke("TextCooldown", msgTimer);
            Interact();
            isInteracting = true;
            hasInteracted = true;
        }

    }
    public virtual void Interact()
    {
        Debug.Log("interacting with "+transform.name);
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
        canDisplayText = false;
    }
}
