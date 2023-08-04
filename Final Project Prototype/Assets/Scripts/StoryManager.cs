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

    void displayMessage(string msg, float sec)
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
        if(GUIManager.memory>=1160)
        {
            GUIManager.memory = -1000;
            StartCoroutine(Ending());  
        }
    }
    IEnumerator Ending()
    {
        displayMessage("my memories of Jessica are flooding back.. ", 3f);
        yield return new WaitForSeconds(3.0f);
        displayMessage("i remember my sister now. Jessica.", 3f);
        yield return new WaitForSeconds(3.0f);
        displayMessage("after all these years, i finally know the truth.", 3f);
        yield return new WaitForSeconds(3.0f);
        displayMessage("I've been freed. It's time to go back.", 5f);
        end();
    }
    IEnumerator ExecuteWithDelay()
    {
        GUIManager.actionsEnabled = false;
        displayMessage("my name is Olivia Campbell. i am a psychology student from Ohio",  4f);
        yield return new WaitForSeconds(4f);
        displayMessage("i recently visited my mother, who was very ill", 3f);
        yield return new WaitForSeconds(3f);
        displayMessage("before she passed away, she had a very strange request", 3f);
        yield return new WaitForSeconds(3f);
        displayMessage("she asked me to go back to our old, abandoned house to look for something important", 3f);
        yield return new WaitForSeconds(3f);
        displayMessage("she refused to tell me what it was, but i had to agree", 3f);
        yield return new WaitForSeconds(3f);
        displayMessage("so here I am, back home. looks like the electricity no longer works.", 3f);
        GUIManager.actionsEnabled = true;
    }
    public void backOff()
    {
        displayMessage("i bet there's still more to explore in this room",2f);
    }
    
    public void askToLook()
    {
        displayMessage("i'll open the chest after i find some more stuff", 3f);
    }

    //GRACE YOU CAN DO WHATEVER ENDING CODE YOU NEED DOWN HERE IN THE END FUNCTION
    void end()
    {

    }
}