using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private BoxCollider2D collider;

    public bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
