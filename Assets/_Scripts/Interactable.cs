using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public enum Interaction
    {
        Trigger,
        Toggle,
        Interact
    }

    [SerializeField] List<Hazard> hazards;
    [SerializeField] Interaction interactionType = Interaction.Trigger;
    private bool inRange = false;
    private GameObject prompt;

    private void Start()
    {
        if (gameObject.GetComponent<BoxCollider2D>() == null && gameObject.GetComponent<CircleCollider2D>() == null)
        {
            Debug.LogError($"{gameObject.name} is missing Collider");
        }

        prompt = GameObject.FindGameObjectWithTag("Prompt");
    }

    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (interactionType == Interaction.Toggle)
            {
                foreach (var hazard in hazards)
                {
                    hazard.InteractActivate();
                }
            } 
            else if (interactionType == Interaction.Interact)
            {
                foreach(var hazard in hazards)
                {
                    hazard.TriggerActivate();
                }
            }
            
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (interactionType == Interaction.Toggle || interactionType == Interaction.Interact)
            {
                inRange = true;
                prompt.GetComponent<Text>().enabled = true;
            }
            else if (interactionType == Interaction.Trigger)
            {
                foreach (var hazard in hazards)
                {
                    hazard.TriggerActivate();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            if (interactionType == Interaction.Toggle || interactionType == Interaction.Interact)
            {
                inRange = false;
                prompt.GetComponent<Text>().enabled = false;
            }
        }
    }
    

}
