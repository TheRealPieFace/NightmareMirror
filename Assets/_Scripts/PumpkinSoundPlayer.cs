using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinSoundPlayer : MonoBehaviour
{
    AudioManager audioManager;
    public bool inRange = false;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pumpkin" && inRange)
        {
            audioManager.Play("Pumpkin");
        }
    }
}
