using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StickmanController : MonoBehaviour
{
    [SerializeField] Renderer myRenderer;
    [SerializeField] Animator myAnimator;
    [SerializeField] string animatorKey = "Moving";

    ColorStackItem currentStack;
    float StickmanSpeed = 8f;
    public void InitializeSticman(ColorStackItem stack)
    {
        currentStack = stack;
        myRenderer.material = currentStack.itemData.material;
    }

    public void MoveToDestination(Vector3[] path)
    {
        Sequence movementSequence = DOTween.Sequence();

        Vector3 lastPos = transform.position;

        for (int i = 0; i < path.Length; i++)
        {
            path[i].y = 1;
            float movementTime = Vector3.Distance(lastPos, path[i])/StickmanSpeed;
            lastPos = path[i];
            movementSequence.Append(transform.DOMove(path[i], movementTime).SetEase(Ease.Linear));
            movementSequence.Join(transform.DOLookAt(path[i], 0.2f));
        }
        movementSequence.AppendCallback(OnMovementFinished);
        myAnimator.SetBool(animatorKey, true);
    }

    void OnMovementFinished()
    {
        transform.parent = currentStack.transform;
        transform.DOLocalRotate(Vector3.zero, 0.3f).OnComplete(currentStack.CompleteMigration);
        myAnimator.SetBool(animatorKey, false);
    }
}
