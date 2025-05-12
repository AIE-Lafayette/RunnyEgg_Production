using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvents : MonoBehaviour
{
    public UnityEvent OnCollisionEnterEvent;
    public UnityEvent OnCollisionStayEvent;
    public UnityEvent OnCollisionExitEvent;

    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent OnTriggerStayEvent;
    public UnityEvent OnTriggerExitEvent;

    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionEnterEvent.Invoke();
    }

    private void OnCollisionStay(Collision collision)
    {
        OnCollisionStayEvent.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        OnCollisionExitEvent.Invoke();
    }



    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerStayEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExitEvent.Invoke();
    }
}
