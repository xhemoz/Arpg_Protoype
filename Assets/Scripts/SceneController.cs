using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //[SerializeField]
    public List<Scene> sceneList;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SceneTransition"))
        {
            DontDestroyOnLoad(gameObject);
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene < sceneList.Count)
            SceneManager.LoadScene(sceneList[currentScene + 1].buildIndex);
        else
            print("This is the last scene");
    }
}
