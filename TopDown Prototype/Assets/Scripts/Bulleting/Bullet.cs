using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float speed = 20f;          // Speed of the bullet
    [SerializeField] private float lifeTime = 2f;        // Lifetime of the bullet before it gets deactivated
    private float lifeTimer;                             // Timer to track the lifetime

    [Header("references")]
    Rigidbody2D rb;                            // Reference to the Rigidbody2D component

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();          // Get the Rigidbody2D component
    }

    void OnEnable()
    {
        lifeTimer = lifeTime;                     // Reset the lifetime timer

        if(rb != null)
        {
            rb.linearVelocity = transform.up * speed; // Set the velocity of the bullet
        }
    }

    void Update()
    {
        lifeTimer -= Time.deltaTime;              // Decrease the timer
        if (lifeTimer <= 0f)
        {
            gameObject.SetActive(false);          // Deactivate the bullet when lifetime is over
        }
    }
}
