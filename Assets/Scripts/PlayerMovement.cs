using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;
    PlayerManager playerManager;

    public float baseSpeed;
    public float speed;
    public float dash;
    public float rotate = 1;

    public float dashTime;
    private float currentDashTime = 0f;
    public float dashDelay;
    public float currentDashDelayTime = 0f;
    public float time; //Not in use!?!?!?!?!?!?!?!? DELETE THIS!
    public bool hasDashed = false;
    //Barrier stuff
    public float barrierTime;
    private float currentBarrierTime = 0f;
    public float barrierDelay;
    public float currentBarrierDelayTime = 0f;
    public bool barrier = false;

    bool canMove;
    private void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody>();
        playerManager = GetComponent<PlayerManager>();

        currentDashTime = 0f;
        currentDashDelayTime = 0f;

        currentBarrierTime = 0f;
        currentBarrierDelayTime = 0f;

        speed = baseSpeed;
    }

    void FixedUpdate () {

        if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

            rb.AddForce(movement * speed);

            if (rb.velocity.magnitude > speed)
            {
                rb.velocity = rb.velocity.normalized * speed;
            }

            if (movement.magnitude > 0)
            {
                playerManager.PlayerMove(true);
            }
            else
                playerManager.PlayerMove(false);

            rb.AddTorque(new Vector3(0, rb.velocity.magnitude * rotate, 0)); //Adds y-axis rotation

            if (Input.GetButtonDown("Fire1") && !hasDashed && Time.time > currentDashDelayTime)
            {
                currentDashTime = Time.time + dashTime; //Starting the timer for dash
                hasDashed = true;
                //rb.AddForce(movement * dash, ForceMode.Impulse);  
            }

            if (Input.GetButtonDown("Fire2") && !barrier && Time.time > currentBarrierDelayTime)
            {
                ActiveBarrier();
            }

            if (Time.time > currentBarrierTime && barrier)
            {
                DisableBarrier();
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

    public void ActiveBarrier()
    {
        playerManager.ActivateBarrier();
        currentBarrierTime = Time.time + barrierTime;
        barrier = true;
    }

    public void DisableBarrier()
    {
        playerManager.DisableBarrier();
        barrier = false;
        currentBarrierDelayTime = Time.time + barrierDelay;
    }

    public bool EnablePlayeMovement(bool move)
    {
        canMove = move;
        return move;
    }
    public void RBKinematic()
    {
        rb.isKinematic = true;
    }
}
