using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScene;
    public Slider slider;
    public Text progressText;

    public void LodingBar(int sceneIndex)
    {
        StartCoroutine(AsyncLoadBar(sceneIndex));
    }
    IEnumerator AsyncLoadBar(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScene.SetActive(true);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;//0~0.9之間
            slider.value = progress;
            progressText.text = Mathf.FloorToInt(progress * 100f) + "%";
            yield return null;
        }
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);//遊戲開始的場景在哪就填多少
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene(2);//遊戲開始的場景在哪就填多少
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
