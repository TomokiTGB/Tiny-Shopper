using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShow : MonoBehaviour
{
    public GameObject text;
    public bool isRange;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isRange)
        {
            text.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //check if player collides to an object
        {
            isRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //check if player collides to an object
        {
            isRange = false;
            text.SetActive(false);
        }
    }
}
