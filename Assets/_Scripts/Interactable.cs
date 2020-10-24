using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum Interaction
    {
        Trigger,
        Toggle
    }

    [SerializeField] Hazard hazard;
    [SerializeField] Interaction interactionType = Interaction.Trigger;
    private bool inRange = false;

    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            hazard.InteractActivate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            if (interactionType == Interaction.Toggle)
            {
                inRange = true;
                //TODO ACTIVATE PROMPT
            }
            else if (interactionType == Interaction.Trigger)
            {
                hazard.TriggerActivate();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            if (interactionType == Interaction.Toggle)
            {
                inRange = false;
                //TODO DEACTIVATE PROMPT
            }
        }
    }
    

}
