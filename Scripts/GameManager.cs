using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public GameObject player;
    public bool isGameOver = false;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        Debug.Log("GAME OVER!");
    }



}