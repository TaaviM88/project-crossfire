using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    private Transform player;
    Vector3 lookVector;
    public GameObject bullet;   
    float bulletSpeed =  500;
    bool playerIsOnArea;
    public float coolDown = 3;
    private const int _spawnBulletDistance= 5;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(playerIsOnArea == true)
        {
            lookVector = player.transform.position - transform.position;
            lookVector.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.5f);
            StartCoroutine(Attack());
        }
        
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsOnArea = true;
            player = other.transform;
            Debug.Log("Pelaaja on alueella");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsOnArea = false;
            player = null;
            Debug.Log("Pelaaja lähti alueelta");
        }
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(_spawnBulletDistance);
        Instantiate(bullet, transform.position + _spawnBulletDistance * transform.forward, transform.rotation);
    }

}
