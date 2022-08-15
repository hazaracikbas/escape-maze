using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenKey : Key
{
    public override void CollectKey(Collider other)
    {
        base.CollectKey(other);
        pc.hasGreenKey = true;
    }
}
