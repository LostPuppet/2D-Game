using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float rocketSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootRocket();
        }
    }

    private void ShootRocket()
    {   GameObject rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * rocketSpeed;
    }
}



