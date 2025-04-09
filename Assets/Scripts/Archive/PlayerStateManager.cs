using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{

    [HideInInspector]
    public Vector2 movement;
    CharacterController controller;
    public float default_speed = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    // Handle Input //
    void OnMove(InputValue moveVal)
    {
        print("Moving!");
        movement = moveVal.Get<Vector2>();
    }

    //Helper Functions//
    public void MovePlayer(float speed)
    {
        float moveX = movement.x;
        float moveZ = movement.y;

        Vector3 actual_movement = new Vector3( moveX, 0 , moveZ);
        controller.Move(actual_movement * Time.deltaTime * speed);
    }

}
