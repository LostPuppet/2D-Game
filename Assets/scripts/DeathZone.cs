using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Restart restartReference; // Store the reference to the Restart script
    private GameObject managerObject;

    private void Start()
    {
        // Find the GameManager object by its tag
        managerObject = GameObject.FindGameObjectWithTag("GameManager");

        // Get the Restart script from the GameManager object
        restartReference = managerObject.GetComponent<Restart>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Test");

            // Call RestartGame from the Restart script
            restartReference.RestartGame();
        }
    }
}