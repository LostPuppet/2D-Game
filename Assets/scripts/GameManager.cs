using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // This is the static instance for GameManager
    public static GameManager Instance { get; private set; }

    public GameData gameData;
    [SerializeField] private CheckpointDatabase checkpointDatabase;
    [SerializeField] private string playerSceneName = "PlayerScene"; // Player scene name

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (gameData.currentCheckpoint == 0)
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        }
        else
        {
            StartCoroutine(LoadFromCheckpoint(gameData.currentCheckpoint));
        }

        gameData.ResetTime();
    }

    private void Update()
    {
        gameData.Tick(Time.deltaTime);
    }

    private IEnumerator LoadFromCheckpoint(int checkpointID)
{
    Debug.Log("Loading checkpoint: " + checkpointID); // Debug log to check checkpoint ID

    // Get the target scene from the checkpoint database
    string targetScene = checkpointDatabase.GetSceneNameForCheckpoint(checkpointID);
    if (string.IsNullOrEmpty(targetScene))
    {
        Debug.LogError("Scene not found for checkpoint ID: " + checkpointID);
        yield break;
    }

    Debug.Log("Scene to load: " + targetScene); // Debug log to check the scene name

    // Load both the player scene and the target scene
    AsyncOperation asyncLoadTargetScene = SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Additive);
    AsyncOperation asyncLoadPlayerScene = SceneManager.LoadSceneAsync("Player", LoadSceneMode.Additive);  // Player scene

    // Wait for both scenes to finish loading
    while (!asyncLoadTargetScene.isDone || !asyncLoadPlayerScene.isDone)
    {
        yield return null;
    }

    // Wait one frame so all objects initialize
    yield return null;

    // Find the checkpoint in the newly loaded scene
    Checkpoint[] checkpoints = GameObject.FindObjectsOfType<Checkpoint>();
    Checkpoint targetCheckpoint = null;
    
    // Look for the checkpoint with the matching ID
    foreach (var cp in checkpoints)
    {
        Debug.Log("Found checkpoint with ID: " + cp.CheckpointID); // Debug log to check checkpoint IDs in the scene

        if (cp.CheckpointID == checkpointID)
        {
            targetCheckpoint = cp;
            break;
        }
    }

    // If the checkpoint is found, set the player's position to that of the checkpoint
    if (targetCheckpoint != null)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = targetCheckpoint.transform.position;
        }
        else
        {
            // If the player is not found, instantiate the player prefab at the checkpoint position
            GameObject playerPrefab = Resources.Load<GameObject>("Player");
            if (playerPrefab != null)
            {
                player = Instantiate(playerPrefab, targetCheckpoint.transform.position, Quaternion.identity);
            }
        }
    }
    else
    {
        Debug.LogError("Checkpoint not found with ID: " + checkpointID);
    }
}


}
