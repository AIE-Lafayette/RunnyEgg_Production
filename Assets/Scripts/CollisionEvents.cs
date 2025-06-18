using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvents : MonoBehaviour
{
    // test

    public UnityEvent<Collision> OnCollisionEnterEvent;
    public UnityEvent<Collision> OnCollisionStayEvent;
    public UnityEvent<Collision> OnCollisionExitEvent;

    /*
    public UnityEvent<Collider> OnTriggerEnterEvent;
    public UnityEvent<Collider> OnTriggerStayEvent;
    public UnityEvent<Collider> OnTriggerExitEvent;
    */

    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionEnterEvent.Invoke(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        OnCollisionStayEvent.Invoke(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        OnCollisionExitEvent.Invoke(collision);
    }



    private void OnTriggerEnter(Collider other)
    {
        //OnTriggerEnterEvent.Invoke(other);
        Debug.Log("Trigger entered for some reason?");
    }

    private void OnTriggerStay(Collider other)
    {
        // OnTriggerStayEvent.Invoke(other);
        Debug.Log("Trigger stayed for some reason?");
    }

    private void OnTriggerExit(Collider other)
    {
        //OnTriggerExitEvent.Invoke(other);
        Debug.Log("Trigger exited for some reason?");
    }
}
