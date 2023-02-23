using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoPunchScale : DoTweenBase
{
    [SerializeField] int vibrato = 10;
    [SerializeField] float elasticity = 1;

    public override void StartTween()
    {
        transform.DOPunchScale(tweenVector, duration, vibrato, elasticity).OnComplete(OnCompleteEvent.Invoke);
    }
}
