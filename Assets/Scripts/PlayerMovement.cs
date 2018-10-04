using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float dash;
    public float rotate = 1;
    private Rigidbody rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetButton("Fire1"))
        {
            rb.AddForce(movement * dash, ForceMode.Impulse);  
        }

        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
        
        rb.AddTorque(new Vector3(0, rb.velocity.magnitude * rotate, 0));

	}
}
