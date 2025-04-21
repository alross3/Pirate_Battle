using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController4 : MonoBehaviour

{   //Control Variables
    [SerializeField]
    public float playerSpeed = 5.0f;
    public CharacterController controller;
    public Vector3 playerVelocity;
    public Vector2 movementInput = Vector2.zero;
    public float rotationSpeed;
    //Cannon Variables
    [SerializeField]
    GameObject bulletSpawnerRight;
    
    [SerializeField]
    GameObject bulletSpawnerLeft;
    [SerializeField]
    GameObject bullet;
    [SerializeField] public float cannonCooldown = 0.5f;
    private bool canShoot = true;
    public string playerTag;



    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }


    void Update()
    {
        // Horizontal input
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        move.Normalize();
        move = Vector3.ClampMagnitude(move, 1f);

        transform.Translate(move * playerSpeed * Time.deltaTime, Space.World);

        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && canShoot)
        {
            Shoot();
            StartCoroutine(Cooldown());
        }
    }    
    public void Shoot()
        {
            
            Instantiate(bullet,bulletSpawnerRight.transform.position, bulletSpawnerRight.transform.rotation);
            Instantiate(bullet,bulletSpawnerLeft.transform.position, bulletSpawnerLeft.transform.rotation);
            bullet.GetComponent<Bullet2>().shooterTag = playerTag;


        }
    private System.Collections.IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cannonCooldown);
        canShoot = true;
    }
    
}