using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : Key
{
    public override void CollectKey(Collider other)
    {
        base.CollectKey(other);
        pc.hasRedKey = true;
    }
}
