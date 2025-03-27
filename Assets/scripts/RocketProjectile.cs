using UnityEngine;

public class RocketProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionForce = 1000f;

    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("RocketProjectile: Rigidbody2D is missing!", gameObject);
            return;
        }

        // Move the rocket forward
        rb.linearVelocity = transform.right * speed;  // Corrected 'linearVelocity' to 'velocity'
        Debug.Log($"RocketProjectile: Launched with velocity {rb.linearVelocity}", gameObject);

        // Find the player by tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            Debug.Log("RocketProjectile: Player found successfully.", gameObject);
        }
        else
        {
            Debug.LogWarning("RocketProjectile: No GameObject with tag 'Player' found.", gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"RocketProjectile: Collided with {collision.gameObject.name} (Tag: {collision.tag})", gameObject);

        if (collision.CompareTag("Enemy") || collision.CompareTag("Terrain"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("RocketProjectile: Explosion triggered!", gameObject);

        // Spawn the explosion effect
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Debug.Log("RocketProjectile: Explosion prefab instantiated.", gameObject);
        }
        else
        {
            Debug.LogWarning("RocketProjectile: Explosion prefab is not assigned!", gameObject);
        }

        // Apply force to player if within explosion radius
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            Debug.Log($"RocketProjectile: Distance to player is {distance}", gameObject);

            if (distance <= explosionRadius)
            {
                Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    Vector2 forceDirection = (player.position - transform.position).normalized;
                    playerRb.AddForce(forceDirection * explosionForce, ForceMode2D.Impulse);
                    Debug.Log("RocketProjectile: Explosion force applied to player!", gameObject);
                }
                else
                {
                    Debug.LogWarning("RocketProjectile: Player does not have a Rigidbody2D!", gameObject);
                }
            }
        }
        else
        {
            Debug.LogWarning("RocketProjectile: Player reference is null!", gameObject);
        }

        // Destroy the rocket
        Destroy(gameObject);
    }
}