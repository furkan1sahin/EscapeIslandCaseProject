using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoMove : DoTweenBase
{
    public override void StartTween()
    {
        transform.DOMove(tweenVector, duration).SetLoops(Loops, loopType).SetEase(easeType).OnComplete(OnCompleteEvent.Invoke); ;
    }
}