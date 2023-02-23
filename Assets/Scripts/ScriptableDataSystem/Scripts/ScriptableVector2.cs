using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableData/ScriptableVector2")]
public class ScriptableVector2 : ScriptableData
{
    [SerializeField] Vector2 value;

    public override object Value { get { return value; } protected set { this.value = (Vector2)value; } }
    public Vector2 GetValue() { return value; }

    public void UpdateValue(Vector2 value)
    {
        this.value = value;
        OnValueUpdated.Invoke();
    }
}
