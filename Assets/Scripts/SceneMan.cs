using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneMan : MonoBehaviour
{
    public Button startButton;
    public Text m_Text;
    public GameObject panel;
    public Slider slider;
    public AudioSource audioS;
    public AudioClip audioC;

    public void LoadSceneHospital()
    {
        Debug.Log("Load");
        audioS.PlayOneShot(audioC,1);
        panel.SetActive(true);
        StartCoroutine(LoadScene());
    }

    //IEnumerator LoadScene()
    //{
    //    yield return null;
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            slider.value = asyncOperation.progress;
            m_Text.text = "ローディング中..." + (asyncOperation.progress * 100) + "%完了";


            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                slider.value = 1f;
                m_Text.text = "画面タップしてください";
                //Wait to you press the space key to activate the Scene
                if (Input.anyKeyDown)
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}