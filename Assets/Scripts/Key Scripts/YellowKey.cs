using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowKey : Key
{
    public override void CollectKey(Collider other)
    {
        base.CollectKey(other);
        pc.hasYellowKey = true;
    }
}
