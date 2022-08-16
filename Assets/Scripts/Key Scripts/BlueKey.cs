using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class BlueKey : Key
{
    // POLYMORPHISM
    public override void CollectKey(Collider other)
    {
        base.CollectKey(other);
        pc.hasBlueKey = true;
    }
}
