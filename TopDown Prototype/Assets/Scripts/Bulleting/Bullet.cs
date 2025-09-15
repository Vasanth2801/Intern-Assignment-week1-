using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float speed = 20f;          // Speed of the bullet
    [SerializeField] private float lifeTime = 3f;        // Lifetime of the bullet before it gets deactivated
    private float lifeTimer;                             // Timer to track the lifetime
    int score;
    public TextMeshProUGUI  scoreText;

    [Header("references")]
    Rigidbody2D rb;                            // Reference to the Rigidbody2D component

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();          // Get the Rigidbody2D component
    }

    void Start()
    {
        score = 0;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            score++;
            Debug.Log("You Scored" +  scoreText.text);
            Destroy(collision.gameObject);
            scoreText.text = scoreText.text + score.ToString();
        }
    }
}