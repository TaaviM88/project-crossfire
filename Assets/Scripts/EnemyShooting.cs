using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    public Transform player;
    Vector3 lookVector;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        lookVector = player.transform.position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
	}
}
