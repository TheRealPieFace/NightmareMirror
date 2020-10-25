using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shade : MonoBehaviour
{
    private GameObject player;
    private GameManager gameManager;
    [SerializeField] float speed = 4.5f;
    [SerializeField] int damage = 1;
    [SerializeField] GameObject spookBoundary;
    private bool inRange = false;
    private bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
        FindObjectOfType<AudioManager>().Play("DemonSuc");
        gameManager.gameState = GameManager.GameState.Chase;
        spookBoundary.layer = LayerMask.NameToLayer("shadeStopper");
        gameManager.SwapChairSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        if (inRange)
        {
            gameManager.TakeDamange(damage);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Prompt")
        {
            moving = false;
        }
    }
}
