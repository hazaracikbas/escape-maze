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
    [SerializeField] private GameManager gameManager;

    // ENCAPSULATION
    public bool hasRedKey { get; set; }
    public bool hasBlueKey { get; set; }
    public bool hasYellowKey { get; set; }
    public bool hasGreenKey { get; set; }

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    // ABSTRACTION
    void PlayerMovement()
    {
        playerRB.velocity = new Vector3(joyStick.Horizontal * speed, playerRB.velocity.y, joyStick.Vertical * speed);

        if (joyStick.Horizontal != 0 || joyStick.Vertical != 0)
        {
            if(playerRB.velocity != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(playerRB.velocity);
            }

            //Running animation condition
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Collecting gems
        if(other.CompareTag("Diamond"))
        {
            gameManager.CollectGems();
            Destroy(other.gameObject);
        }

        // Reaching finish line
        if (other.CompareTag("Finish"))
        {
            animator.SetBool("levelComplete", true);
            playerRB.constraints = RigidbodyConstraints.FreezePosition;
            gameManager.LevelComplete();
        }
    }

}
