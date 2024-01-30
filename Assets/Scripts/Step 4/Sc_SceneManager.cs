using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_SceneManager : MonoBehaviour
{
    public void LoadSceneAdditive(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        else
            SceneManager.UnloadSceneAsync(sceneName);

              
    }
}
