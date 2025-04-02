using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    public void StartGame()
    {
        // Load the Forest and Player scenes additively
        SceneManager.LoadScene("Forest", LoadSceneMode.Additive);
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);

        // Start a coroutine to safely set active scene and unload the menu
        StartCoroutine(SwitchScenes());
    }

    private System.Collections.IEnumerator SwitchScenes()
    {
        // Wait a frame to ensure the new scene is fully loaded
        yield return null;

        // Set "Forest" as the active scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Forest"));

        // Now it's safe to unload the Menu scene
        SceneManager.UnloadSceneAsync("Menu");
    }
}