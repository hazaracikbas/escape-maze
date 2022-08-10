using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private FloatingJoystick joyStick;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 offset;


    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        playerRB.velocity = new Vector3(joyStick.Horizontal * speed, playerRB.velocity.y, joyStick.Vertical * speed);

        if (joyStick.Horizontal != 0 || joyStick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(playerRB.velocity);

            //Animation condition
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

    }

}