using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticsManager : MonoBehaviour
{
    public void PlayLightHaptic()
    {
        Vibration.VibratePop();
    }

    public void PlayMediumHaptic()
    {
        Vibration.Vibrate();
    }

    public void PlayHeavyHaptic()
    {
        Vibration.VibratePeek();
    }

    void Start()
    {
        Vibration.Init();
    }
}
