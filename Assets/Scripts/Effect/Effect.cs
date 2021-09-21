using UnityEngine;

public abstract class Effect : ScriptableObject 
{
    public abstract void Activate(GameObject target, GameObject self);
}