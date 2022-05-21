using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneManager : MonoBehaviour
{
    public Button startButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startButton.onClick.AddListener(LoadSceneHospital);
    }

    private void LoadSceneHospital()
    {
        Debug.Log("Load");
    }
}
