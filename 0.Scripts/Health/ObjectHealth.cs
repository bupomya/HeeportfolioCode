using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : Health
{
    protected ShotObject shotObject;

    private void Awake()
    {
        shotObject = GetComponent<ShotObject>();
    }

    public override void Hit(int damage, float knockbackForce = 0)
    {
        shotObject.IsHit = true;
    }
}
