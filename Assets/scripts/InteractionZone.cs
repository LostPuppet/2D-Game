using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class InteractionZone : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp; 
    [SerializeField] private Transform childObject; 
    [SerializeField] private UnityEvent onInteract; 

    private bool playerInZone = false;

    private void Start()
    {
        if (tmp != null)
            tmp.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            if (tmp != null)
                tmp.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            if (tmp != null)
                tmp.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.F))
        {
            if (childObject != null)
                childObject.position += Vector3.right;

            onInteract?.Invoke();
            Destroy(gameObject); 
        }
    }
}
