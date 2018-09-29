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
    private int direction = 1;
    public Transform target;
    Vector3 playerOldPosition;
	
	// Update is called once per frame
	void Update ()
    {
        if(target != null)
        {

            transform.position += transform.forward * speed * Time.deltaTime;

            //transform.position = Vector3.MoveTowards(transform.position, playerOldPosition, speed);
            //transform.position += direction * bulletMovement;
            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

            transform.localRotation *= Quaternion.Euler(bulletRotation);
        }
        
	}
    private void OnEnable()
    {
        Invoke("Disable", destroyTimer);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Disable();
        }
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
