using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject redirect;

    public void pauseLevel()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void resumeLevel()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        redirect.SetActive(true);
    }
}
