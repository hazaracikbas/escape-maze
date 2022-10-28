using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Animator doorAnim;
    [SerializeField] GameObject unlockEffect;

    public virtual void UnlockDoor()
    {
        Instantiate(unlockEffect, transform.position, Quaternion.identity);

        Taptic.Heavy();

        doorAnim.SetBool("isUnlocked", true);
    }

}
