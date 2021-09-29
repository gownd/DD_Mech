using UnityEngine;
using System;

namespace DD.Effects
{
    public abstract class Effect : ScriptableObject
    {
        public abstract void Activate(GameObject target, GameObject self);

        // public event Action onActivate;
    }
}
