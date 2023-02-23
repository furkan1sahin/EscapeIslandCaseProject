using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoTweenBase : MonoBehaviour
{
    [SerializeField] protected bool AutoStart = false;
    [SerializeField] protected Vector3 tweenVector;
    [SerializeField] protected float duration;
    [SerializeField] protected int Loops = 0;
    [SerializeField] protected LoopType loopType;
    [SerializeField] protected Ease easeType = Ease.OutSine;

    [SerializeField] protected UnityEvent OnCompleteEvent;

    void Start()
    {
        if (AutoStart) StartTween();
    }

    public virtual void StartTween()
    {
        
    }
}
