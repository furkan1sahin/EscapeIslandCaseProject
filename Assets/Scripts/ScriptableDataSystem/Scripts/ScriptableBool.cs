using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableData/ScriptableBool")]
public class ScriptableBool : ScriptableData
{
    [SerializeField] bool value;

    public override object Value { get { return value; } protected set { this.value = (bool)value; } }
    public bool GetValue() { return value; }

    public void UpdateValue(bool value)
    {
        this.value = value;
        OnValueUpdated.Invoke();
    }
}
