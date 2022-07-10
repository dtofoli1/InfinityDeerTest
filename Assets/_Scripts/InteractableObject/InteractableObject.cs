using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public abstract void Disable();

    public abstract void Interaction(int value = 0);

    public abstract void OnEnable();
    

    public virtual void OnDisable()
    {
        Disable();
    }
}
