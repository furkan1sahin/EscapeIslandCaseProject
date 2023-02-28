using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticsManager : MonoBehaviour
{
    [SerializeField] ScriptableBool hapticSettings;

    public void PlayLightHaptic()
    {   
        if (hapticSettings.GetValue())
        Vibration.VibratePop();
    }

    public void PlayMediumHaptic()
    {
        if (hapticSettings.GetValue())
        Vibration.Vibrate();
    }

    public void PlayHeavyHaptic()
    {
        if (hapticSettings.GetValue())
        Vibration.VibratePeek();
    }

    void Start()
    {
        Vibration.Init();
    }
}
