using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointID;

    public int CheckpointID => checkpointID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered");
            GameManager.Instance?.gameData.SetCheckpoint(checkpointID);
        }
    }
}