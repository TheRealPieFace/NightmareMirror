using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (GetComponentInParent<BookBehavior>().state == BookBehavior.BookState.Idle)
            {
                GetComponentInParent<BookBehavior>().target = collision.transform.position;
                GetComponentInParent<BookBehavior>().state = BookBehavior.BookState.Attacking;
            }
        }
    }
}
