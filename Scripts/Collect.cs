using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject text;
    public bool collected;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //check if player collides to an object
        {
            Destroy(gameObject);
            collected = true;
        }
    }
}
