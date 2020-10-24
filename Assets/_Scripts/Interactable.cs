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

    [SerializeField] List<Hazard> hazards;
    [SerializeField] Interaction interactionType = Interaction.Trigger;
    private bool inRange = false;

    private void Start()
    {
        if (gameObject.GetComponent<BoxCollider2D>() == null && gameObject.GetComponent<CircleCollider2D>() == null)
        {
            Debug.LogError($"{gameObject.name} is missing Collider");
        }
    }

    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            foreach(var hazard in hazards)
            {
                hazard.InteractActivate();
            }
            
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
                foreach (var hazard in hazards)
                {
                    hazard.InteractActivate();
                }
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
