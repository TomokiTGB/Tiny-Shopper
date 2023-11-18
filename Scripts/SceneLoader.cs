using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneName;

    public void NextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
