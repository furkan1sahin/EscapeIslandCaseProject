using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoRotate : DoTweenBase
{
    public override void StartTween()
    {
        transform.DOLocalRotate(tweenVector, duration).SetLoops(Loops, loopType).SetEase(easeType).OnComplete(OnCompleteEvent.Invoke); ;
    }
}
