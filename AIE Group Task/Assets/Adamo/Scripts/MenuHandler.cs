using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Default");
    }

    public void GoBack()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Ragebaited");
        Application.Quit();
    }
}
