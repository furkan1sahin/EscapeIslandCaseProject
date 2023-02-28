using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableData/ScriptableInt")]
public class ScriptableInt : ScriptableData
{
    [SerializeField] int value;

    public override object Value { get { return value; } protected set { this.value = (int)value; } }
    public int GetValue() { return value; }

    public void UpdateValue(int value)
    {
        this.value = value;
        OnValueUpdated.Invoke();
    }
}