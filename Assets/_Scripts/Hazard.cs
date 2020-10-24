using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public void TriggerActivate()
    {
        this.enabled = true;
    }

    public void InteractActivate()
    {
        this.enabled = !this.enabled;
    }
}
