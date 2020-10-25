using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeMovement : MonoBehaviour
{
    private bool isWalking = false;
    public int speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        PlayWalk();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * speed * Time.deltaTime, 0, 0);
            
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
            
        }

        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            
            StopWalk();
        }
    }

    public void PlayWalk()
    {
        if (!isWalking)
        {
            FindObjectOfType<AudioManager>().Play("Footsteps");
            
        }
    }

    public void StopWalk()
    {
        if (isWalking)
        {
            FindObjectOfType<AudioManager>().Stop("Footsteps");
            isWalking = false;
        }
    }
}
