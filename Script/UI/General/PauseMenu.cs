using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public  bool isGamePause;
    public GameObject pauseMeunUI;
    public GameObject confirmMenu;
    public void Resume()
    {
        pauseMeunUI.SetActive(false);
        Time.timeScale = 1.0f;
        isGamePause = false;
    }

    public void Pause()
    {
        pauseMeunUI.SetActive(true);
        confirmMenu.SetActive(false);
        Time.timeScale = 0.0f;
        isGamePause = true;
    }

    public void BackToMainMenu()
    {
        pauseMeunUI.SetActive(false);
        confirmMenu.SetActive(true);
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Comfirm()
    {
        LoadScene("Menu");
    }

    public void Cancel()
    {
        pauseMeunUI.SetActive(true);
        confirmMenu.SetActive(false);
    }
    void Start()
    {
        isGamePause = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePause == true)
            {
                isGamePause = false;
            }
            else
            {
                isGamePause = true;
            }
            Debug.Log(isGamePause);
            if (isGamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
