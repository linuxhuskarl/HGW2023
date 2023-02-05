using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MENU_START : MonoBehaviour
{
    // Start is called before the first frame update
    public static void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public static void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void PlayTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
