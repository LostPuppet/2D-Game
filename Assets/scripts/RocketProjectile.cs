using UnityEngine;

public class RocketProjectile : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionForce = 1000f;

    private Rigidbody2D rb;
    private Transform player;
    private bool hasExploded = false; // Added this

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed; 

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasExploded) return; // Prevent multiple explosions

        if (collision.CompareTag("Enemy") || collision.CompareTag("Terrain"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        hasExploded = true; // Mark as exploded

        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= explosionRadius)
            {
                Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    Vector2 forceDirection = (player.position - transform.position).normalized;
                    playerRb.AddForce(forceDirection * explosionForce, ForceMode2D.Impulse);
                }
            }
        }

        Destroy(gameObject);
    }
}