using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBlock : MonoBehaviour
{
    [SerializeField] Transform roadObject;

    public void SetRoadLength(float length)
    {
        roadObject.localScale = new Vector3(roadObject.localScale.x, roadObject.localScale.y, length);
    }
}
