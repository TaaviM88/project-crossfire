using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 3f;
    public float damage = 0f;
    public float destroyTimer = 10f;
    public float FireRate = 0.5f;
    private Vector3 bulletMovement;
    private Vector3 bulletRotation;
    public Transform target;
    Vector3 _direction;
    public Transform _startPosition;
    Rigidbody _rb;
    bool bulletHitWall = false;
    //Vector3 playerOldPosition;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        if (bulletHitWall == false)
        {
            if (target != null)
            {
                //transform.position += _direction * (speed * Time.deltaTime);
                //rigidbody.AddForce(_direction * speed, ForceMode.Impulse);
                _rb.AddForce(_direction * (speed * Time.deltaTime), ForceMode.Impulse);
                //transform.localRotation *= Quaternion.Euler(bulletRotation);
            }
        }
        

    }
    private void OnEnable()
    {
        Invoke("Disable", destroyTimer);
    }

    void Disable()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rb.velocity = Vector3.zero;
        bulletHitWall = false;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Disable();
            return;
        }

        if(other.gameObject.tag == "Enemy")
        {
            Disable();
        }

        /*if (other.gameObject != this)
        {
            Disable();
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9 || collision.gameObject.layer == 11)
        {
            bulletHitWall = true;
            Debug.Log("Osuin " + collision.gameObject.name);
        }
    }
    public void UpdateDirection()
    {
        _direction = (target.transform.position - _startPosition.position).normalized;
        _direction.y = 0;
    }
 
    /*public  Transform GetPlayerLocation(Transform transform)
    {
        //playerOldPosition = new Vector3(transform.transform.position.x, transform.transform.position.y, transform.transform.position.z);
        //transform.rotation = Quaternion.LookRotation(transform.position);
        //Käännetään luoti lähtemään pelaajan suuntaan
        //transform.rotation = Quaternion.LookRotation(target.position);
        return null;
    }*/

   
}
