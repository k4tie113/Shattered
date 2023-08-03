using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalInteract : Interactable
{
   [SerializeField] private GameObject noteCanvas;
   [SerializeField] private TextMeshProUGUI noteText;
   public string[] texts;
   private int index;
   GUIStyle guiStyle;
   private bool isOpen = false;
   void Awake(){
        texts = new string[8];
        index = 0;
      guiStyle = FontManager.guiStyle;
      noteCanvas.SetActive(false);
       texts[0] = "Patricia's Art Journal. Don't mess it up - put inside my drawer if you find it";
        texts[1] = "August 15, 1997\nIt's been a year since I've written a journal entry. It's already been a year since that day. I can't believe it. I don't think my kids will find this. My job has always been uninteresting to them.";
        texts[2] = "October 9, 1997\nThe doctor says that she has dissociative amnesia. She can't remember anything. Paul might not think so, but I think it's a good thing.";
        texts[3] = "November 25, 1997\nIt's been a month since I've hidden all the family photos. The walls feel so empty. I miss my daughter.";
        texts[4] = "January 13, 1998\nWe're improving. I can feel our lives getting back to normal, little by little. Olivia's condition still limits her memorization, but I can feel that she is going to be a great psychologist when she grows up. Danny still won't talk to me but I'm working on it.";
        texts[5] = "May 10, 1998\nI've been having some nightmares lately about our home. It's nothing to worry about.";
        texts[6] = "May 11, 1998\nI saw her in the mirror today. I wanted to tell her that I miss her. I wanted to tell her that I'm so sorry for what I did to her. I don't deserve to be called a mother. I'm a monster. Help me. She's going to take me with her.";
        texts[7] = "I\'m seeing her face in the windows as well. God help me.";
   }
   public override void Interact()
   {
        index = 0;
        base.Interact();
        noteText.text = texts[index];
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
   public override void OnGUI()
   {
      base.OnGUI();
      if(isOpen)
      {
         GUI.Label(new Rect (Screen.width * 0.7f,Screen.height*0.8f,200,50), "[E] to put down",guiStyle);
         if(index<7) GUI.Label(new Rect (Screen.width * 0.1f,Screen.height*0.8f,200,50), "[SPACE] for next page",guiStyle);
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
         else if(index < 7 && Input.GetKeyDown(KeyCode.Space))
         {
            index++;
            noteText.text = texts[index];
         } //get space keycode
      }
   }
}

