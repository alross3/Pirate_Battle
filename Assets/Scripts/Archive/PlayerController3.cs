using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Example : MonoBehaviour
{
    // Controller Variables
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Vector3 playerVelocity;
    
    [SerializeField]
    private float playerSpeed = 2.0f;
    private Vector2 movementInput = Vector2.zero;
    //private float gravityValue = -9.81f;
    private bool groundedPlayer;
        [SerializeField]
    //Cannon Variables
    GameObject bulletSpawnerRight;
    
    [SerializeField]
    GameObject bulletSpawnerLeft;
    [SerializeField]
    GameObject bullet;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }


    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Horizontal input
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1f); // Optional: prevents faster diagonal movement

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }
    void OnAttack()
        {
            Instantiate(bullet,bulletSpawnerRight.transform.position, bulletSpawnerRight.transform.rotation);
            Instantiate(bullet,bulletSpawnerLeft.transform.position, bulletSpawnerLeft.transform.rotation);
        }
}