using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    [SerializeField] int damage = 1;

    private void Start()
    {
        if (gameObject.GetComponent<BoxCollider2D>() == null && gameObject.GetComponent<CircleCollider2D>() == null)
        {
            Debug.LogError($"{gameObject.name} is missing Collider");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log(damage + " Damage");
            //collision.gameObject.GetComponent(Player).DealDamage(damage);
        }
    }

}
