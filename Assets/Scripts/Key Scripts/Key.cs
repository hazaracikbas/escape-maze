using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject collectEffect;

    public PlayerController pc;
    private Vector3 tilt = new Vector3(45, 0, 30);

    private void Start()
    {
        transform.rotation = Quaternion.Euler(tilt);
    }

    //void Update()
    //{
    //    FacePlayer();
    //}

    //public void FacePlayer()
    //{
    //    GameObject player = GameObject.Find("Player");

    //    if (player.transform.position.y > 0)
    //    {
    //        transform.LookAt(player.transform.position);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        CollectKey(other);
        Taptic.Medium();
    }

    public virtual void CollectKey(Collider other)
    {
        //When player collides with a key the key will disappear and added into player inventory

        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

    }
}
