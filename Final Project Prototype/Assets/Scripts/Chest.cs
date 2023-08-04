using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] GameObject openedChest;
    public StoryManager story;
    public AudioSource open;
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
            if(GUIManager.memory<160)
            {
                story.askToLook();
                return;
            }
            openedChest.SetActive(true);
            open.Play();
            gameObject.SetActive(false);
        }
    }
}
