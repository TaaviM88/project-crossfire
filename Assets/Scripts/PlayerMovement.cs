using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float rotate = 1;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Update()
    {
        //transform.Rotate(new Vector3(0.0f,1,0.0f), rotate * Time.deltaTime);
    }

    void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        //float rotateHorizontal = Input.GetAxis("Horizontal") * rotate * Time.deltaTime;
        //float rotateVertical = Input.GetAxis("Vertical") * rotate * Time.deltaTime;

        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);

        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed    ;
        }

        /*if (Input.GetButtonDown("Fire1"))
        {
            rotate = 20;

        }

        Debug.Log("ö" + rb.velocity.magnitude);*/

        rb.AddTorque(new Vector3(0, rb.velocity.magnitude * rotate, 0));
        //rb.AddTorque(new Vector3(0, rotateVertical, 0));

        //rb.MovePosition(transform.position + movement);

		
	}
}
