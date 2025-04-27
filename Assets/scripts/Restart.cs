using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        SceneManager.LoadScene("Game"); 
        Destroy(gameObject);
        
    }


}