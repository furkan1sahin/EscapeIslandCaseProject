using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSetBool : MonoBehaviour
{
    Animator animator;
    [SerializeField] string PropertyName;
    bool value;

    void Start()
    {
        animator = GetComponent<Animator>();
        value = animator.GetBool(PropertyName);
    }

    public void SetBoolTrue()
    {
        SetBool(true);
    }

    public void SetBoolFalse()
    {
        SetBool(false);
    }

    public void SwitchBool()
    {
        SetBool(!value);
    }

    public void SetBool(bool valueToSet)
    {
        value = valueToSet;
        animator.SetBool(PropertyName, valueToSet);
    }
}
