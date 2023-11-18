using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScene : MonoBehaviour
{
    public int sceneName;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //check if player collides to an object
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
