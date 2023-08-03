using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresInteract : Interactable
{
   [SerializeField] private GameObject noteCanvas;
   [SerializeField] private TextMeshProUGUI noteText;
   public string[] texts;
   private int index;
   GUIStyle guiStyle;
   private bool isOpen = false;
   void Awake(){
        texts = new string[4];
        index = 0;
      guiStyle = FontManager.guiStyle;
      noteCanvas.SetActive(false);
       texts[0] = "Cleveland Hospital\n\nDate: March 2, 1997\nPatient: Olivia Campbell\nDOB:13 Jan 1984\nMedical Record No:471364";
        texts[1] = "Diagnosis and Recommendations:\n\nDear Parents, Olivia has been diagnosed with Dissociative Amnesia, a condition rooted in memory loss due to traumatic events. Concurrently, the patient displays indications of Post-Traumatic Stress Disorder (PTSD). h    a     f.     aj   on a medicat on   ,  appr ach f    ja  pa thro   out   na   . kindl   not   ah  o t   w t.";
        texts[2] = "diagn sis t me ical in r or t chro ic on eath . pati nt plea e tak ca e of your elf j af wua  mu  jtk please  h a help ki ly";
        texts[3] = "s mp om x mina on d agno s m dical r cords , th ough in ical proce ure. pa ien p ease a ten ively ca e of ou sel es. s c e ly Doctor P erce";
        
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
      GUIManager.actionsEnabled = false;
      noteCanvas.SetActive(true);
   }
   void DisableNote()
   {
      isOpen = false;
      noteCanvas.SetActive(false);
      GUIManager.actionsEnabled = true;
   }
   public override void OnGUI()
   {
      base.OnGUI();
      if(isOpen)
      {
         GUI.Label(new Rect (Screen.width * 0.7f,Screen.height*0.8f,200,50), "[E] to put down",guiStyle);
         if(index<3) GUI.Label(new Rect (Screen.width * 0.1f,Screen.height*0.8f,200,50), "[SPACE] for next page",guiStyle);
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
         else if(index < 3 && Input.GetKeyDown(KeyCode.Space))
         {
            index++;
            noteText.text = texts[index];
         } //get space keycode
      }
   }
}

