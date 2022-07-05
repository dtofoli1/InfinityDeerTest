using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public float travelForce;
    public float recoilTime;

    public abstract void Shoot(Transform firePoint);
}
