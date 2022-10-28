using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDoor : Door
{
    [SerializeField] PlayerController pc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && pc.hasYellowKey)
        {
            UnlockDoor();
            Destroy(gameObject);
            pc.hasYellowKey = false;
        }
    }

    public override void UnlockDoor()
    {
        base.UnlockDoor();
    }
}
