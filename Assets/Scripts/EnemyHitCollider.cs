using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitCollider : MonoBehaviour {

    EnemyShooting _parent;

	// Use this for initialization
	void Start () {
        _parent = GetComponentInParent<EnemyShooting>();
        if(_parent == null)
        {
            Debug.Log("Can't find " + _parent + " " + _parent.name);
        }
	}
	

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            _parent.EnemyHit();
        }
    }
}
