using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    private Transform player;
    public Transform bulletStartingPoint;
    Vector3 lookVector;
    //public GameObject bullet;   
    float bulletSpeed =  500;
    bool playerIsOnArea;
    public float coolDown = 3;
    public float firerate = 0.07f;
    public float nextfire = 0.0f;
    private const float _spawnBulletDistance= 2.5f;
    public static EnemyShooting current;
    [SerializeField] bool enemyOnlyRotates = false;
    Animation _anime;
    Animator _animerator;
    // Use this for initialization
    void Awake ()
    {
        current = this;
        
        _animerator = GetComponent<Animator>();
        if(_animerator == null)
        {
            Debug.Log("Ei löydy");
            return;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(playerIsOnArea == true)
        {
            lookVector = player.transform.position - transform.position;
            lookVector.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.5f);
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsOnArea = true;
            _animerator.SetBool("PlayerIsOnAreaAnimator", true);
            player = other.transform;           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsOnArea = false;
            _animerator.SetBool("PlayerIsOnAreaAnimator", false);
            //player = null;          
        }
    }

    public void Fire()
    {
        GameObject bullet = PoolManager.current.GetBullet();

        if (bullet == null) return;
        if (Time.time > nextfire && enemyOnlyRotates == false)
        {
            nextfire = Time.time + firerate;
            

            //bullet.transform.position = transform.position; //+ Vector3.forward + new Vector3(transform.position.x, transform.position.y ,transform.position.z);
            bullet.transform.position = bulletStartingPoint.position; //transform.position + Vector3.forward;
            bullet.transform.rotation = transform.rotation;
            bullet.gameObject.GetComponent<Bullet>().target = player.transform;
            bullet.gameObject.GetComponent<Bullet>()._startPosition = bulletStartingPoint; //this.transform;
            bullet.gameObject.GetComponent<Bullet>().UpdateDirection();
            //bullet.gameObject.GetComponent<Bullet>().GetPlayerLocation(player.transform);
            bullet.SetActive(true);
            //StartCoroutine(Attack());
        }
       
        
    }

   /* public IEnumerator Attack()
    {
        yield return new WaitForSeconds(coolDown);
        //Instantiate(bullet, transform.position + _spawnBulletDistance * transform.forward, transform.rotation);
        GameObject bullet = PoolManager.current.GetBullet();
        if (bullet == null) yield return new WaitForSeconds(coolDown);
    }*/

}
