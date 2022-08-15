using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Animator doorAnim;
    [SerializeField] ParticleSystem unlockEffect;

    public virtual void UnlockDoor()
    {
        unlockEffect.Play();
        doorAnim.SetBool("isUnlocked", true);
    }

}
