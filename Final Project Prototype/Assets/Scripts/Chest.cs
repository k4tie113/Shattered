using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] GameObject openedChest;
    void Awake()
    {
        openedChest.SetActive(false);
    }
    public override void Interact()
    {
        base.Interact();
        GUIManager.keyEnabled = true;
        if(GUIManager.gotKey)
        {
            openedChest.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
