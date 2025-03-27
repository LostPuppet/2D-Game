using UnityEngine;
using TMPro;  // Make sure to include the TMPro namespace for TextMeshPro

public class Stats : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;      // Reference to the player's Rigidbody2D
    [SerializeField] private TMP_Text velocityText; // Reference to the TMP Text component where we will display the velocity

    // Public variables to store and access velocity values elsewhere
    public float PlayerXVelocity { get; private set; }
    public float PlayerYVelocity { get; private set; }
    public float PlayerTotalVelocity { get; private set; }

    void Update()
    {
        // Get the current x and y velocities
        PlayerXVelocity = rb.linearVelocity.x;
        PlayerYVelocity = rb.linearVelocity.y;

        // Calculate the total velocity (positive sum of x and y)
        PlayerTotalVelocity = Mathf.Abs(PlayerXVelocity) + Mathf.Abs(PlayerYVelocity);

        // Update the TextMeshPro text with the velocity values
        velocityText.text = $"X Velocity: {PlayerXVelocity:F2}\nY Velocity: {PlayerYVelocity:F2}\nTotal Velocity: {PlayerTotalVelocity:F2}";
    }
}
