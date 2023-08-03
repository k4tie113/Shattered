using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : Interactable
{
    private Renderer objectRenderer;
    private Collider objectCollider;
    public override void Interact()
    {
        base.Interact();
        Invoke("ToggleObjectVisibility",msgTimer);
        GUIManager.gotKey = true;
        GUIManager.keyEnabled = false;
    }
    void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        objectCollider = GetComponent<Collider>();
    }

    public void ToggleObjectVisibility()
    {
        gameObject.SetActive(false);
        /*if (objectRenderer != null)
            objectRenderer.enabled = isVisible;

        if (objectCollider != null)
            objectCollider.enabled = isVisible;*/
    }
}
