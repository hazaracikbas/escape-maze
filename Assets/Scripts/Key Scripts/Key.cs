using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private ParticleSystem poof;
    public PlayerController pc;

    private void OnTriggerEnter(Collider other)
    {
        CollectKey(other);
    }

    public virtual void CollectKey(Collider other)
    {
        //When player collides with a key the key will disappear and added into player inventory

        if (other.gameObject.CompareTag("Player"))
        {
            poof.Play();
            Destroy(gameObject);
        }

    }
}
