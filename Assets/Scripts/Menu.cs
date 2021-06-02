using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject logoScreen;

    private float time = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    bool timeCountDown()
    {

        if (time > 0.0f)
        {
            time -= Time.deltaTime;
            return false;
        }
        else
        {
            time = 5.0f;
            return true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        bool byeLogo = false;

        while (byeLogo == false) {
            timeCountDown();
        }

        if (byeLogo == true)
        {
            logoScreen.SetActive(false);
        }
    }

    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void openFacebook()
    {
        Application.OpenURL("https://www.linkedin.com/in/cesar-gouveia-531a3866/");
    }

}
