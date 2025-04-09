using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float projectileSpeed;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * projectileSpeed);
    }
    // This checks what the bullet collided with, if it is tagged Enemy, the bullet is destroyed
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
        
    
}