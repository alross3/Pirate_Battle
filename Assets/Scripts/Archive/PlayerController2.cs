using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    
    [SerializeField]
    GameObject bulletSpawnerRight;
    
    [SerializeField]
    GameObject bulletSpawnerLeft;
    [SerializeField]
    GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        
    }
    
    void OnAttack()
        {
            Instantiate(bullet,bulletSpawnerRight.transform.position, bulletSpawnerRight.transform.rotation);
            Instantiate(bullet,bulletSpawnerLeft.transform.position, bulletSpawnerLeft.transform.rotation);
        }
        
}
