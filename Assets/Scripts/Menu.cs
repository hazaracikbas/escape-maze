using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        int i = SceneManager.GetActiveScene().buildIndex;

        if (i <= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(i + 1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }

}
