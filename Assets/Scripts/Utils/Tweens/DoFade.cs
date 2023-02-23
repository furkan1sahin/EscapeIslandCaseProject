using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DoFade : DoTweenBase
{

    public override void StartTween()
    {
        GetComponent<Image>().DOFade(tweenVector.x, duration).SetLoops(Loops, loopType).SetEase(easeType).OnComplete(OnCompleteEvent.Invoke);
    }
}
