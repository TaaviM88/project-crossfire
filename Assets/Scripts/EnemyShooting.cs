using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    private Transform _player;
    public Transform bulletStartingPoint;
    Vector3 lookVector;

    bool playerIsOnArea;
    public float coolDown = 3;
    public float firerate = 0.07f;
    public float nextfire = 0.0f;
    private const float _spawnBulletDistance = 2.5f;

    public float colorChangeDuration = 5f;
    private float _colorChangeTime = 0;
    
    public static EnemyShooting current;
    [SerializeField] bool enemyOnlyRotates = false;
    //Animation _anime;
    Animator _animerator;
    Renderer rend;
    Color originalColor;
    public Color newColor = Color.red;

    bool _isEnemyAlive = true;
    // Use this for initialization
    void Awake ()
    {
        current = this;
        _isEnemyAlive = true;
        rend = GetComponentInChildren<Renderer>();
        originalColor = rend.material.GetColor("_Color");

        if (rend == null)
            Debug.Log("Not found " + rend + " " + rend.name);

        _animerator = GetComponent<Animator>();
        if(_animerator == null)
        {
            Debug.Log(" Not found " + _animerator + " " + _animerator.name);
            return;
        }
        _animerator.SetBool("EnemyHit", false);
    }
	
	// Update is called once per frame
	void Update () {
        if(_isEnemyAlive)
        {
            if (playerIsOnArea == true)
            {
                //rend.material.shader = Shader.Find("_Color");
                //rend.material.SetColor("_Color", Color.red);
                rend.material.color = Color.Lerp(originalColor, Color.red, _colorChangeTime);
                lookVector = _player.transform.position - transform.position;
                lookVector.y = transform.position.y;
                Quaternion rot = Quaternion.LookRotation(lookVector);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.5f);
            }
            else
            {
                //00FFDB
                //_colorChangeTime = 0;
                rend.material.color = Color.Lerp(Color.red, originalColor, _colorChangeTime);

                //rend.material.SetColor("_Color", originalColor);
            }

            if (_colorChangeTime < 1)
            {
                _colorChangeTime += Time.deltaTime / colorChangeDuration;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(_isEnemyAlive)
        {
            if (other.gameObject.tag == "Player")
            {
                playerIsOnArea = true;
                _animerator.SetBool("PlayerIsOnAreaAnimator", true);
                _player = other.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isEnemyAlive)
        {
            if (other.gameObject.tag == "Player")
            {
                playerIsOnArea = false;
                _animerator.SetBool("PlayerIsOnAreaAnimator", false);
                //player = null;
            }
        }
    }

    public void Fire()
    {
        if(_isEnemyAlive)
        {
            GameObject bullet = PoolManager.current.GetBullet();
            if (bullet == null) return;
            if (Time.time > nextfire && enemyOnlyRotates == false)
            {
                nextfire = Time.time + firerate;
                //bullet.transform.position = transform.position; //+ Vector3.forward + new Vector3(transform.position.x, transform.position.y ,transform.position.z);
                bullet.transform.position = bulletStartingPoint.position; //transform.position + Vector3.forward;
                bullet.transform.rotation = transform.rotation;
                bullet.gameObject.GetComponent<Bullet>().target = _player.transform;
                bullet.gameObject.GetComponent<Bullet>()._startPosition = bulletStartingPoint; //this.transform;
                bullet.gameObject.GetComponent<Bullet>().UpdateDirection();
                //bullet.gameObject.GetComponent<Bullet>().GetPlayerLocation(player.transform);
                bullet.SetActive(true);
                //StartCoroutine(Attack());
            }
        }
    }

    public void EnemyHit()
    {
        if(_isEnemyAlive)
        {
            _animerator.SetBool("EnemyHit", true);
            _isEnemyAlive = false;
        }
    }

    public void DestroyEnemy()
    {
        Debug.Log("Enemy destroyed " + gameObject.name);
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
