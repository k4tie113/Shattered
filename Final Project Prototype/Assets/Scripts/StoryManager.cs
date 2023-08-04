using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class StoryManager:MonoBehaviour
{
    public string displayMsg;
    public bool displaying = false;
    GUIStyle style;
    void Awake()
    {
        displayMsg = "";
        style = FontManager.yellowStyle;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnGUI()
    {
        GUI.Label(new Rect (25,Screen.height*0.9f,200,50), displayMsg,style);
    }

    public void displayMessage(string msg, float sec)
    {
        GUIManager.isInteracting = true;
        Debug.Log("displaying: "+msg);
        displayMsg = msg;
        displaying = true;
        Invoke("quitMessage",sec);
    }
   
    private void quitMessage()
    {
        displayMsg = "";
        displaying = false;
        GUIManager.isInteracting = false;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(ExecuteWithDelay());
        // This code will run when the specific target scene is loaded
        // Perform any necessary actions here
    }
    void Update()
    {
        Debug.Log(GUIManager.memory);
        if(GUIManager.memory>=1180)
        {
            GUIManager.memory = -1000;
            StartCoroutine(Ending());  
        }
    }
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(4f);
        displayMessage("I've always had the feeling that something was missing from my life.", 4f);
        yield return new WaitForSeconds(4f);
        displayMessage("My memories of her are flooding back.. ", 3f);
        yield return new WaitForSeconds(3.0f);
        displayMessage("I remember my sister now. Jessica.", 3f);
        yield return new WaitForSeconds(3.0f);
        displayMessage("After all these years, I finally know the truth.", 3f);
        yield return new WaitForSeconds(3.0f);
        displayMessage("I've been freed. It's time to go back.", 5f);
        yield return new WaitForSeconds(5.0f);
        end();
    }
    IEnumerator ExecuteWithDelay()
    {
        GUIManager.actionsEnabled = false;
        displayMessage("My name is Olivia Campbell. I am a psychology student from Ohio.",  4f);
        yield return new WaitForSeconds(4f);
        displayMessage("I recently visited my mother, who was very ill.", 3f);
        yield return new WaitForSeconds(3f);
        displayMessage("Before she passed away, she had a very strange request.", 3f);
        yield return new WaitForSeconds(3f);
        displayMessage("She asked me to go back to our old, abandoned house to look for something important.", 3f);
        yield return new WaitForSeconds(3f);
        displayMessage("She refused to tell me what it was, but I had to agree.", 3f);
        yield return new WaitForSeconds(3f);
        displayMessage("...So here I am, back home. Looks like the electricity no longer works.", 3f);
        GUIManager.actionsEnabled = true;
    }
    public void backOff()
    {
        displayMessage("I bet there's still more to explore in this room...",2f);
    }
    
    public void askToLook()
    {
        displayMessage("I'll open the chest after I find some more things.", 3f);
    }

    void end()
    {
        SceneManager.LoadScene("Ending1");
    }
}