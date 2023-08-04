using UnityEngine;
using UnityEngine.SceneManagement;

public class Warning : MonoBehaviour
{
    public string Instructions;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Instructions");
        }
    }
}
