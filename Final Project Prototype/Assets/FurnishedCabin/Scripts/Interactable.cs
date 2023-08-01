using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public bool hasInteracted;
    public bool isInteracting;
    public bool tooFar;
    public string displayMsg;
    private GUIStyle textStyle;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        tooFar = false;
        hasInteracted = false;
        displayMsg = "";
        textStyle = new GUIStyle();
		textStyle.fontSize = 16;
		textStyle.fontStyle = FontStyle.Italic;
		textStyle.normal.textColor = Color.yellow;
    }
    public void hit(Transform playerPOS)
    {
        player = playerPOS;
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance<radius)
        {
            tooFar = false;
            Interact();
            isInteracting = true;
            hasInteracted = true;
        }
        tooFar = true;
    }
    public virtual void Interact()
    {
        Debug.Log("interacting with "+transform.name);
    }

    void OnGUI()
    {
        if(tooFar)
        {
            GUI.Label(new Rect (50,Screen.height - 50,200,50), "walk closer to interact",textStyle);
        }
    }
}
