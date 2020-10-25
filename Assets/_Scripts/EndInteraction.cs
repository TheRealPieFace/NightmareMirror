using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndInteraction : MonoBehaviour
{
    [SerializeField] Text prompt;
    public bool inRange = false;
    public bool active = false;
    [SerializeField] GameObject endScreen;

    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(1);
            //Debug.Log("hit E");
            //endScreen.SetActive(true);
            //Time.timeScale = 0;
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
