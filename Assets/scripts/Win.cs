using UnityEngine;
using UnityEngine.Events;

public class Win : MonoBehaviour
{
    [SerializeField] private UnityEvent winEvent; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            winEvent?.Invoke(); 
        }
    }
}
