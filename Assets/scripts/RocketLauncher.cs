using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float rocketSpeed = 10f;
    [SerializeField] private float fireCooldown = 1f; // Default cooldown of 1 second

    private float lastFireTime = 0f; // Tracks the last time a rocket was fired

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= lastFireTime + fireCooldown)
        {
            ShootRocket();
            lastFireTime = Time.time; // Update the last fired time
        }
    }

    private void ShootRocket()
    {
        GameObject rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * rocketSpeed;
    }
}