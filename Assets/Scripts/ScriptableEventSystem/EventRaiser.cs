using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser : MonoBehaviour
{
    [SerializeField] ScriptableEvent scriptableEvent;

    public void RaiseEvent()
    {
        scriptableEvent.Invoke();
    }

}
