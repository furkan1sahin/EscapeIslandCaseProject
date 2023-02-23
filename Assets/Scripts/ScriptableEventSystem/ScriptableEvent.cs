using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Event")]
public class ScriptableEvent : ScriptableObject
{
    //private List<EventListener> eventListeners = new List<EventListener>();
    HashSet<ScriptableEventListener> eventListeners = new HashSet<ScriptableEventListener>();

    public void Invoke()
    {
        foreach (var globalEventListener in eventListeners)
        {
            globalEventListener.RaiseEvent();
        }
    }

    public void Register(ScriptableEventListener eventListener) => eventListeners.Add(eventListener);

    public void Deregister(ScriptableEventListener eventListener) => eventListeners.Remove(eventListener);
}
