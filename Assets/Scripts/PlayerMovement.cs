using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;

    public float baseSpeed;
    public float speed;
    public float dash;
    public float rotate = 1;

    public float dashTime;
    private float currentDashTime = 0f;
    public float dashDelay;
    public float currentDashDelayTime = 0f;
    public float time;
    public bool hasDashed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentDashTime = 0f;
        currentDashDelayTime = 0f;
        speed = baseSpeed;
    }

    void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);

        if (rb.velocity.magnitude > speed) 
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
        
        rb.AddTorque(new Vector3(0, rb.velocity.magnitude * rotate, 0)); //Adds y-axis rotation

        if (Input.GetButton("Fire1") && !hasDashed && Time.time > currentDashDelayTime)
        {
            currentDashTime = Time.time + dashTime; //Starting the timer for dash
            hasDashed = true;
            //rb.AddForce(movement * dash, ForceMode.Impulse);  
        }

        if ((Time.time > currentDashTime) && hasDashed) //Am I dashing or has the dash timer expired?
        {
            hasDashed = false;
            currentDashDelayTime = Time.time + dashDelay;
        }

        if (hasDashed)
        {
            speed = dash;
        }

        if (!hasDashed)
        {
            speed = baseSpeed;
        }
    }
}
