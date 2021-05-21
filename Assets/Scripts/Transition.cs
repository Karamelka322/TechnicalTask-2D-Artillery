using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    public bool NeedTransit { get; protected set; }

    protected void OnEnable()
    {
        NeedTransit = false;
        Enable();
    }

    public virtual void Enable() { }
}
