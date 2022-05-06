using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isAvailable;

    void Start()
    {
        isAvailable = true;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        isAvailable = false;
    }
    void OnTriggerStay2D(Collider2D hit)
    {
        isAvailable = false;
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        isAvailable = true;
    }
}
