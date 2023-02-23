using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableData/ScriptableFloat")]
public class ScriptableFloat : ScriptableData
{
    [SerializeField] float value;

    public override object Value { get { return value; } protected set { this.value = (float)value; } }
    public float GetValue() { return value; }

    public void UpdateValue(float value)
    {
        this.value = value;
        OnValueUpdated.Invoke();
    }
}
