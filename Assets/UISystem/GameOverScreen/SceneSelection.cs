using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{

    public Scene Scene;
    public string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }


    public void goToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void restartScene()
    {
        SceneManager.LoadScene(currentScene);
    }
}
