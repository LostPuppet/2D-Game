using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private Transform cam;    
    [SerializeField] private float smoothSpeed = 5f; 

    void FixedUpdate()
    {
        
        Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, cam.position.z);
        cam.position = Vector3.Lerp(cam.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
