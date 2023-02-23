using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableEventListener : MonoBehaviour
{
    [SerializeField] ScriptableEvent scriptableEvent;
    [SerializeField] UnityEvent unityEvent;

    void Awake() => scriptableEvent.Register(this);

    void OnDestroy() => scriptableEvent.Deregister(this);

    public void RaiseEvent() => unityEvent.Invoke();
}
