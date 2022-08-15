using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDoor : Door
{
    [SerializeField] PlayerController pc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && pc.hasGreenKey)
        {
            UnlockDoor();
            Destroy(gameObject);

        }
    }

    public override void UnlockDoor()
    {
        base.UnlockDoor();
    }


}
