using UnityEngine;

public class FpsCalmDown : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 120; // Set the desired FPS (e.g., 60)
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
