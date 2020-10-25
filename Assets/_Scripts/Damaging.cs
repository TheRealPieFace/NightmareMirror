using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    [SerializeField] int damage = 1;
    private GameManager gameManager;

    private void Start()
    {
        if (gameObject.GetComponent<BoxCollider2D>() == null && gameObject.GetComponent<CircleCollider2D>() == null)
        {
            Debug.LogError($"{gameObject.name} is missing Collider");
        }
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            gameManager.TakeDamange(damage);
        }
    }


}
