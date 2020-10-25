using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndInteraction : MonoBehaviour
{
    [SerializeField] Text prompt;
    private bool inRange = false;
    public bool active = false;
    [SerializeField] GameObject endScreen;

    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
            endScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(active && collision.gameObject.tag == "Player")
        {
            prompt.enabled = true;
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            prompt.enabled = false;
            inRange = false;
        }
    }
}
