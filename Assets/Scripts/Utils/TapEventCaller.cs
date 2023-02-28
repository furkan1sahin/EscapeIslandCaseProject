using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TapEventCaller : MonoBehaviour
{
    [SerializeField] UnityEvent OnTap;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { OnTap.Invoke(); }
    }
}
