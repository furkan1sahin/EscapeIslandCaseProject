using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] string CheckForTag = "";
    [SerializeField] UnityEvent OnTriggerEnterEvent;
    [SerializeField] UnityEvent OnTriggerStayEvent;
    [SerializeField] UnityEvent OnTriggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (CheckForTag.Length == 0 || other.gameObject.CompareTag(CheckForTag)) OnTriggerEnterEvent.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (CheckForTag.Length == 0 || other.gameObject.CompareTag(CheckForTag)) OnTriggerStayEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckForTag.Length == 0 || other.gameObject.CompareTag(CheckForTag)) OnTriggerExitEvent.Invoke();
    }
}
