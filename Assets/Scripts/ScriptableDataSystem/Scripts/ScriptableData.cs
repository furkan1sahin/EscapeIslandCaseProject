using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ScriptableData : ScriptableObject
{
    public abstract object Value { get; protected set; }
    public UnityEvent OnValueUpdated;

    public virtual void UpdateValue(object value)
    {
        Value = value;
    }
}
