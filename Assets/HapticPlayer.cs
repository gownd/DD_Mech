using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class HapticPlayer : MonoBehaviour
{
    public void PlayHaptic(HapticTypes type)
    {
        MMVibrationManager.Haptic(type);
    }
}
