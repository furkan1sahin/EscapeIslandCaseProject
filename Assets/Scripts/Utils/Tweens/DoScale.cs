using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoScale : DoTweenBase
{
    public override void StartTween()
    {
        transform.DOScale(tweenVector, duration).SetLoops(Loops, loopType).SetEase(easeType).OnComplete(OnCompleteEvent.Invoke); ;
    }
}
