using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndInteraction : MonoBehaviour
{
    [SerializeField] Text prompt;
    public bool active = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(active && collision.gameObject.tag == "Player")
        {
            prompt.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            prompt.enabled = false;
        }
    }
}
