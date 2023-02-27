using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pathway : MonoBehaviour
{
    [SerializeField] PathBlock[] PathBlocks;

    public void CreatePath(Vector3[] pathPoints)
    {
        for (int i = 0; i < pathPoints.Length; i++)
        {
            pathPoints[i].y = pathPoints[0].y;
        }
        for (int i = 0; i < PathBlocks.Length; i++)
        {
            PathBlocks[i].transform.position = pathPoints[i];
            PathBlocks[i].transform.LookAt(pathPoints[i+1]);
            PathBlocks[i].SetRoadLength(Vector3.Distance(pathPoints[i], pathPoints[i+1]));
        }
    }

    public void CreatePath(Island island1, Island island2)
    {
        transform.position = island1.PathConnect.position;
        transform.LookAt(island1.PathHandle);

        SetPathBlock(0, island1.PathConnect.position, island1.PathHandle.position);
        SetPathBlock(1, island1.PathHandle.position, island2.PathHandle.position);
        SetPathBlock(2, island2.PathHandle.position, island2.PathConnect.position);

    }

    void SetPathBlock(int index, Vector3 position, Vector3 targetPos)
    {
        position.y = 1;
        targetPos.y = 1;

        PathBlocks[index].transform.position = position;
        PathBlocks[index].transform.LookAt(targetPos);
        PathBlocks[index].SetRoadLength(Vector3.Distance(position, targetPos));
    }
}
