using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private bool isActive = false;

    public void TriggerActivate()
    {
        if (!isActive)
        {
            this.gameObject.SetActive(!gameObject.activeSelf);
            isActive = true;
        }
        
    }

    public void InteractActivate()
    {
        this.gameObject.SetActive(!gameObject.activeSelf);
    }
}
