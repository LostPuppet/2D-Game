using System.Collections;
using UnityEngine;

public class KillAfterTime : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 5f; 

    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {

        yield return new WaitForSeconds(timeToDestroy);
        

        Destroy(gameObject);
    }
}
