using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Transform player; // Reference to the player's transform
    [SerializeField] private float parallaxFactor = 0.25f; // Percentage of the player's position for parallax effect
    [SerializeField] private Vector2 offset; // Offset for x and y positions

    [SerializeField] private float lerpSpeed = 5f; // Speed at which the background moves (lerps)

    void Start()
    {
        // Find the player object by tag (make sure the player has the "Player" tag)
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // Calculate the target position based on the player's position and the parallax factor, with offsets
            Vector3 targetPosition = new Vector3(player.position.x * parallaxFactor + offset.x, 
                player.position.y * parallaxFactor + offset.y, 
                transform.position.z);

            // Smoothly move (lerp) to the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
        }
    }
}