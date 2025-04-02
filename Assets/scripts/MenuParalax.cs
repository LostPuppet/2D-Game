using UnityEngine;

public class MenuParalax : MonoBehaviour
{
    public float parallaxStrength = 5f; 
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        
        Vector3 mousePosition = Input.mousePosition;
        Vector3 viewportPoint = new Vector3(mousePosition.x / Screen.width, mousePosition.y / Screen.height, 0);

        
        Vector3 parallaxOffset = new Vector3(viewportPoint.x - 0.5f, viewportPoint.y - 0.5f, 0) * -parallaxStrength;

       
        transform.position = startPosition + parallaxOffset;
    }
}
