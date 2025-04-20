using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level1End : MonoBehaviour
{
    public GameData gameData;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(HandleSceneTransition(other.gameObject));
        }
    }

    private IEnumerator HandleSceneTransition(GameObject player)
    {
        yield return new WaitForSeconds(1f);

        
        player.transform.position = Vector2.zero;
        gameData.SetCheckpoint(2);
        SceneManager.UnloadSceneAsync("Forest");
        SceneManager.LoadSceneAsync("Forest2", LoadSceneMode.Additive);
    }
}