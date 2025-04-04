using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void Hit(int damage, float knockbackForce = 0);
}
