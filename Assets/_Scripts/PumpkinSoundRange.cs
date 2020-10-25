using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinSoundRange : MonoBehaviour
{
    PumpkinSoundPlayer[] players;

    private void Start()
    {
        players = GetComponentsInChildren<PumpkinSoundPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            foreach(var player in players)
            {
                player.inRange = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var player in players)
            {
                player.inRange = false;
            }
        }
    }
}
