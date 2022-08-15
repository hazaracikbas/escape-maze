using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKey : Key
{
    public override void CollectKey(Collider other)
    {
        base.CollectKey(other);
        pc.hasBlueKey = true;
    }
}
