using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPLayer : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    
    private Rigidbody2D body;

    [SerializeField] private GroundSensor groundSensor;
    // Start is called before the first frame update
    private float movement = 0;
    private bool jump = false;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&groundSensor.isGrounded==true)  
        {
            body.AddForce(new Vector2(0,5f),ForceMode2D.Impulse);
        }

        movement += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
    }
    
    private void FixedUpdate()
    {
        body.velocity = new Vector2(movement, body.velocity.y);
        movement = 0;
    }
}
