using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBehavior : MonoBehaviour
{
    public enum BookState
    {
        Idle,
        Attacking,
        Line,
        Returning
    }

    private Animator anim;
    private float direction = 1;
    [SerializeField] float speed = 1;
    public BookState state = BookState.Idle;

    private float startingHeight;
    private bool attacking;
    public Vector3 target;

    private void Start()
    {
        anim = GetComponent<Animator>();
        startingHeight = transform.position.y;
    }

    private void Update()
    {
        if (state == BookState.Idle)
        {
            transform.Translate(1 * direction * speed * Time.deltaTime, 0, 0);
        }
        if(state == BookState.Attacking)
        {
            state = BookState.Line;
            StartCoroutine(Attack());
        }
        if (attacking)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * 1.5f * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                attacking = false;
                state = BookState.Returning;
            }
        }
        if(state == BookState.Returning)
        {
            transform.Translate(0, 1 * speed * 1.5f * Time.deltaTime, 0);
            if(transform.position.y >= startingHeight)
            {
                state = BookState.Idle;
            }
        }

    }

    public void Turn()
    {
        direction = direction * -1;
        anim.SetTrigger("Turn");
        StartCoroutine(Flip());
    }

    IEnumerator Flip()
    {
        yield return new WaitForSeconds(.1f);
        transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(.5f);
        attacking = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            attacking = false;
            state = BookState.Returning;
        }
    }
}
