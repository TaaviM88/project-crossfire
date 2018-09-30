using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    private Transform player;
    Vector3 lookVector;
    //public GameObject bullet;   
    float bulletSpeed =  500;
    bool playerIsOnArea;
    public float coolDown = 3;
    public float firerate = 0.07f;
    public float nextfire = 0.0f;
    private const float _spawnBulletDistance= 2.5f;
    public static EnemyShooting current;
    
    // Use this for initialization
    void Awake ()
    {
        current = this;
	}
	
	// Update is called once per frame
	void Update () {

        if(playerIsOnArea == true)
        {
            lookVector = player.transform.position - transform.position;
            lookVector.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.5f);

            if(Time.time > nextfire)
            {
                nextfire = Time.time + firerate;
                Fire();
                //StartCoroutine(Attack());
            }      
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsOnArea = true;
            player = other.transform;           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsOnArea = false;
            player = null;          
        }
    }

    public void Fire()
    {
        GameObject bullet = PoolManager.current.GetBullet();

        if (bullet == null) return;

        bullet.transform.position = transform.position; //+ Vector3.forward + new Vector3(transform.position.x, transform.position.y ,transform.position.z);
        bullet.transform.rotation = transform.rotation;
        bullet.gameObject.GetComponent<Bullet>().target = player.transform;
        bullet.gameObject.GetComponent<Bullet>()._startPosition = this.transform;
        bullet.gameObject.GetComponent<Bullet>().UpdateDirection();
        //bullet.gameObject.GetComponent<Bullet>().GetPlayerLocation(player.transform);
        bullet.SetActive(true);
        
    }

   /* public IEnumerator Attack()
    {
        yield return new WaitForSeconds(coolDown);
        //Instantiate(bullet, transform.position + _spawnBulletDistance * transform.forward, transform.rotation);
        GameObject bullet = PoolManager.current.GetBullet();
        if (bullet == null) yield return new WaitForSeconds(coolDown);
    }*/

}
