using UnityEngine;

public class Door : MonoBehaviour
{

    public void OnInteraction()
    {
        Debug.Log("Interaction event triggered!");
        
        transform.position += Vector3.down * 6;
    }
}
