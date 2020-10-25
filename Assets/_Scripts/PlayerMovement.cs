using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    public float moveSpeed = 1f;
    Animator myAnimator;
    Collider2D myCollider;
    public bool isGrounded = true;
    public float jumpSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0,0) * Time.deltaTime * moveSpeed;

        //transform.localScale = new Vector2(Mathf.Sign(movement * -1), 1f);

        //check if player is moving.
        if (movement != 0)
        {
            myAnimator.SetBool("walking", true);
        }
        if (movement == 0)
        {
            myAnimator.SetBool("walking", false);

        }

        //if the state of left shift is down run is true only when moving.
        if (Input.GetKey("left shift") == true & movement != 0)
        {
            moveSpeed = 5f;
            myAnimator.SetBool("running", true);
            print("space key was pressed");
        }

        //if left shift is up or player not moving, dont run.
        if (Input.GetKeyUp("left shift") == true || movement == 0)
        {
            moveSpeed = 1f;
            myAnimator.SetBool("running", false);
        }

        if (Input.GetButtonDown("Jump") == true & myCollider.IsTouchingLayers(LayerMask.GetMask("floor")))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocity;
            
        }

        if (myRigidBody.velocity.y != 0)
        {
            myAnimator.SetBool("jumping", true);
            
        }

        if (myRigidBody.velocity.y < .1 & myRigidBody.velocity.y > -.1)
        {
            myAnimator.SetBool("jumping", false);
            myAnimator.SetBool("falling", false);
        }

        if (myRigidBody.velocity.y < -.1)
        {
            myAnimator.SetBool("falling", true);

        }


        //check and change direction of player
        if (movement < 0)//player is moving left.
        {
            transform.localScale = new Vector2(1f, 1f);
        }

        if (movement > 0)// player is moving right
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        
    }

    

    }
