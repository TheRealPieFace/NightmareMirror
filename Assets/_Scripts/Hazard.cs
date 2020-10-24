using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public void TriggerActivate()
    {
        this.gameObject.SetActive(true);
    }

    public void InteractActivate()
    {
        this.gameObject.SetActive(!gameObject.activeSelf);
    }
}
