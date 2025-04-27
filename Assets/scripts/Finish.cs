using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameData gameData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        {gameData.SetCheckpoint(0);
            restartReference.RestartGame();
        
        }
    }
}
