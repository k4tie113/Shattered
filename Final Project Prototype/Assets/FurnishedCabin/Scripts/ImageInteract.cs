using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImageInteract : Interactable
{
   [SerializeField] private GameObject noteCanvas;
   GUIStyle guiStyle;
   private bool isOpen = false;
   void Awake(){
      guiStyle = FontManager.guiStyle;
      noteCanvas.SetActive(false);
   }
   public override void Interact()
   {
        base.Interact();
        
        ShowNote();
   }
   public void ShowNote()
   {
      isOpen = true;
      GUIManager.canMove = false;
      noteCanvas.SetActive(true);
   }
   void DisableNote()
   {
      isOpen = false;
      noteCanvas.SetActive(false);
      GUIManager.canMove = true;
   }
   void OnGUI()
   {
      if(isOpen)
      {
         GUI.Label(new Rect (Screen.width * 0.6f,Screen.height*0.8f,200,50), "[E] to put down",guiStyle);
      }
   }
   private void Update()
   {
      if(isOpen)
      {
         if(Input.GetKeyDown(KeyCode.E))
         {
            DisableNote();
         }
      }
   }
}

