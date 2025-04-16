using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet2 : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private float lifetime = 3f;

    [SerializeField] private float forwardForce = 50f;
    [SerializeField] private float upwardForce = 5f;
    [SerializeField] private ForceMode forceMode = ForceMode.Impulse;

    private Rigidbody rb;

    //Tags
    public string shooterTag;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Apply force when spawned
        Vector3 force = transform.forward * forwardForce + Vector3.up * upwardForce;
        rb.AddForce(force, forceMode);
        
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag(shooterTag)) return;

        if (other.CompareTag("Environment"))
        {
            Destroy(gameObject);
            return;
        }
        // Check if hit object can take damage
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
        
    }

}