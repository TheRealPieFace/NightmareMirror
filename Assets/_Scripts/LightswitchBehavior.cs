using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightswitchBehavior : MonoBehaviour
{
    private bool inRange = false;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            sprite.flipY = !sprite.flipY;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
